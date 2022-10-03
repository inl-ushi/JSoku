using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;


namespace JSoku
{
    public partial class MainForm : Form
    {
        JikoInfo _JikoInfo = new JikoInfo();
        public Boolean modeFlg;
        public string slUserName;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            // ゴミファイル削除
            DirectoryInfo tempDir = new DirectoryInfo(Func.GetTempFolder());
            if (this.docb部門() >= 1)
            {
                foreach (FileInfo s in tempDir.GetFiles())
                {
                    try
                    {
                        s.IsReadOnly = false;
                        s.Delete();
                    }
                    catch
                    {
                        // 削除エラーは無視する
                    }
                }
                //*事故速報報告書では、ログインを行わない。
                this.Reload();

                //ステータス表示
                this.sl接続先.Text = DB.GetSchemaName();
                this.sl接続先.ForeColor = DB.GetSchemaColor();

                //コマンドライン引数を配列で取得する
                string[] cmds = System.Environment.GetCommandLineArgs();
                string[] arr = cmds[1].Split('@');

                //Environment.MachineName

                this.slユーザ名.Text = cmds[1];

            }
            else
            {
                Msg.Info("使用権限がありません。確認してください。");
                this.Close();
            }
        }

        private int docb部門()
        {
            try
            {
                MySqlConnection myconn = DB.GetConnection();

                //コマンドライン引数を配列で取得する
                string[] cmds = System.Environment.GetCommandLineArgs();
                int i = 0;
                if (cmds.Length > 1)
                {

                    String query = $"SELECT DISTINCT 部門CD,部門名,権限CD FROM `m_管理ユーザー`t1,`m_所属部門`t2,`m_部門`t3";
                    query = query + $" WHERE t1.Email = t2.Email AND t1.Email = '{cmds[1]}' AND t2.部門CD = t3.部門コード order by 部門CD ASC ";
                    MySqlDataReader rs;
                    rs = DB.GetReader(myconn, query);

                    this.cb部門.Items.Clear();
                    var _jikoInfo = new JikoInfo();
                    while (rs.Read())
                    {
                        _jikoInfo = new JikoInfo();
                        _jikoInfo.item1 = DB.NVL(rs["部門名"]).ToString();
                        _jikoInfo.item2 = DB.NVL(rs["部門CD"]).ToString();
                        _jikoInfo.item3 = DB.NVL(rs["権限CD"]).ToString();
                        this.cb部門.Items.Add(_jikoInfo);
                        i++;
                    }

                    this.cb部門.Refresh();
                    this.cb部門.SelectedIndex = 0;


                    rs.Close();

                }
                return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void txFromYMD_TextChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }
        private void doFilterCB営業所()
        {
            MySqlConnection myconn = DB.GetConnection();

            String query = "select 部門名 from m_部門 where 部門コード not in('99','8')";
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            List<string> list = new List<string>();
            list.Add("");
            while (rs.Read())
            {
                list.Add(rs.GetString("部門名"));
            }

            cb営業所.DataSource = list.ToArray();
            cb営業所.Refresh();
        }
        private void doFilterCB()
        {
            MySqlConnection myconn = DB.GetConnection();

            String query = String.Format(" select 氏名 from v_g_社員list where カナ like {0} and not ISNULL(氏名) and (退職年月日 is NULL OR DATE_ADD(退職年月日,INTERVAL 1 MONTH) > CURRENT_DATE())", DB.Escape('%'+this.txDriverKana.Text+ '%'));
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            List<string> list = new List<string>();
            list.Add("");
            while (rs.Read())
            {
                list.Add(rs.GetString("氏名"));
            }

            cbDriverName.DataSource = list.ToArray();
            cbDriverName.Refresh();

        }
        private void doFilter()
        {
            String STRFROM;
            String STRTO;
            String DNAME;
            String KUBUN1;
            String KUBUN2;
            String KUBUN3;
            String KUBUN4;
            String KUBUN5;
            String KUBUN6;
            String EIGYOUSYO;

            EIGYOUSYO = this.cb営業所.Text;

            //from発生日
            if ((this.txFromYMD.Text).Length == 8 || (this.txFromYMD.Text).Length == 10 || (this.txFromYMD.Text).Length == 0)
            {
                //from発生日
                if ((this.txFromYMD.Text).Length == 8)
                {
                    STRFROM = this.txFromYMD.Text.Substring(0, 4) + "/" + this.txFromYMD.Text.Substring(4, 2) + "/" + this.txFromYMD.Text.Substring(6, 2);
                }
                else if ((this.txFromYMD.Text).Length == 10)
                {
                    STRFROM = this.txFromYMD.Text;
                }
                else
                {
                    STRFROM = "0000/00/00";
                }
            }
            else
            {
                return;
            }

            //to発生日
            if ((this.txToYMD.Text).Length == 8 || (this.txToYMD.Text).Length == 10 || (this.txToYMD.Text).Length == 0)
            {
                //from発生日
                if ((this.txToYMD.Text).Length == 8)
                {
                    STRTO = this.txToYMD.Text.Substring(0, 4) + "/" + this.txToYMD.Text.Substring(4, 2) + "/" + this.txToYMD.Text.Substring(6, 2);
                }
                else if ((this.txToYMD.Text).Length == 10)
                {
                    STRTO = this.txToYMD.Text;
                }
                else
                {
                    STRTO = "9999/99/99";
                }
            }
            else
            {
                return;
            }

            //乗務員名
            if (this.cbDriverName.Text != "")
            {
                DNAME = this.cbDriverName.Text;
            }
            else
            {
                DNAME = "";
            }

            //事故区分****************************************
            //労災
                        if (this.ck1.CheckState == 0)
            {
                KUBUN1 = "";
            }
            else
            {
                KUBUN1 = "労災";
            }
            
            //車両
            if (this.ck2.CheckState == 0)
            {
                KUBUN2 = "";
            }
            else
            {
                KUBUN2 = "車両";
            }

            //荷物
            if (this.ck3.CheckState == 0)
            {
                KUBUN3 = "";
            }
            else
            {
                KUBUN3 = "荷物";
            }

            //品質
            if (this.ck4.CheckState == 0)
            {
                KUBUN4 = "";
            }
            else
            {
                KUBUN4 = "品質";
            }

            //環境
            if (this.ck5.CheckState == 0)
            {
                KUBUN5 = "";
            }
            else
            {
                KUBUN5 = "環境";
            }

            //貰い
            if (this.ck6.CheckState == 0)
            {
                KUBUN6 = "";
            }
            else
            {
                KUBUN6 = "貰い";
            }

           string filter = String.Format(" (発生日 >= '{0}' AND 発生日 <= '{1}' AND 乗務員名 like {2} AND 事故区分 like {3} and 事故区分 like {4} and 事故区分 like {5} and 事故区分 like {6} and 事故区分 like {7} and 事故区分 like {8} and 営業所 like {9}) ", STRFROM, STRTO, Func.FilterEscape(DNAME), Func.FilterEscape(KUBUN1), Func.FilterEscape(KUBUN2), Func.FilterEscape(KUBUN3), Func.FilterEscape(KUBUN4), Func.FilterEscape(KUBUN5), Func.FilterEscape(KUBUN6), Func.FilterEscape(EIGYOUSYO));


            try
            {
                ((DataView)(this.dgJikoList.DataSource)).RowFilter = filter;
            }
            catch 
            {
            }
        }

        private int dgSelectedRow;
        private int dgScrollPos;

        private void Reload()
        {
            this.SaveScrollPos();

            var query = new System.Text.StringBuilder();

            query.Append(" select * from v_g_事故情報 order by 事故NO desc");

            var dv = new DataView();
            
            dv.Table = DB.GetDataTable(query.ToString());

            this.dgJikoList.AutoGenerateColumns = false;
            this.dgJikoList.DataSource = dv;

            this.doFilterCB();
            this.doFilterCB営業所();
            //フィルタ
            this.txFilter_TextChanged(null, null);
        }
        private void SaveScrollPos()
        {
            //選択行の保存
            if(this.dgJikoList.SelectedRows.Count != 0){
                this.dgSelectedRow = this.dgJikoList.SelectedRows.Count;
            }

            this.dgScrollPos = this.dgJikoList.FirstDisplayedScrollingRowIndex;
        }
        private void txFilter_TextChanged(object send, EventArgs e)
        {
            this.doFilter();
        }

        private void txToYMD_TextChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void cbDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void cbDriverName_TextUpdate(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck1_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck2_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck3_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck4_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck5_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void ck6_CheckedChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void bt新規作成_Click(object sender, EventArgs e)
        {
            //新規追加処理
            var nextForm = new InputForm();
            nextForm.currentSID = DB.NEW_SID;
            nextForm.currentBUMON = _JikoInfo.部門CD;
            //nextForm.currentBUMON = "3";
            nextForm.updateFlg = false;
            nextForm.ShowDialog(this);

            this.Reload();
        }

        private void txDriverKana_TextChanged(object sender, EventArgs e)
        {
            this.doFilterCB();
        }

        private void dgJikoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            int row = e.RowIndex;

            switch (col){

            case 0:
                    //ボタン列
                    String key = this.dgJikoList.CurrentRow.Cells["sid"].Value.ToString();

                    InputForm nextForm = new InputForm();
                    nextForm.currentSID = key;
#if DEBUG 
                    //nextForm.currentBUMON = "6";
                    nextForm.currentBUMON = _JikoInfo.部門CD;
#else
                    nextForm.currentBUMON = _JikoInfo.部門CD;
#endif
                    nextForm.modeFlg = this.modeFlg;
                    nextForm.adminCD = _JikoInfo.権限CD;
                    nextForm.ShowDialog(this);

                    this.Reload();
                    break;
            }
        }

        private void lbTitle_Click(object sender, EventArgs e)
        {
            int SI;
            int YE;
            int MA;
            if (Control.ModifierKeys == Keys.Control)
            {
                if (modeFlg == true)
                {
                    SI = 230;
                    YE = 230;
                    MA = 230;
                    modeFlg = false;
                    this.bt新規作成.Visible = true;
                }
                else
                {
                    SI = 230;
                    YE = 255;
                    MA = 255;
                    modeFlg = true;
                    this.bt新規作成.Visible = false;
                }

                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            }
        }

        private void cb営業所_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.doFilter();
        }

        private void dgJikoList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var path = Func.GetWorkFolder();
            System.Diagnostics.Process.Start(path + "/README.xlsx");
        }

        private void cb部門_SelectedIndexChanged(object sender, EventArgs e)
        {
            JikoInfo inf = (JikoInfo)this.cb部門.SelectedItem;
            this.cb部門.Text = inf.item1;
            _JikoInfo.部門名 = inf.item1;
            _JikoInfo.部門CD = inf.item2;
            _JikoInfo.権限CD = inf.item3;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgJikoList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //セルの列を確認
            if (dgv.Columns[e.ColumnIndex].Name == "削除FLG" && e.Value is string)
            {
                int val = Int32.Parse((string)e.Value);
                //セルの値により、背景色を変更する
                Console.WriteLine(e.RowIndex);
                if (val == 1)
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(150, 150, 150);
                }
                else if (val == 0)
                {
                    //e.CellStyle.BackColor = Color.Red;
                }
            }

        }
    }
}
