using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace JSoku
{
    public partial class InputForm : Form
    {
        public string currentSID;
        JikoInfo _JikoInfo = new JikoInfo();
        public string currentBUMON;
        public Boolean updateFlg;
        public Boolean modeFlg;
        public string adminCD;
        DateTime? dateTime;
        public InputForm()
        {
            InitializeComponent();
        }

        private void doExLockCheck()
        {
            //排他ロックチェック
            Boolean isFree = JikoInfo.ExCheck(this._JikoInfo.SID);

            if (isFree == true)
            {
                //排他ロック実施
                JikoInfo.ExLock(this._JikoInfo.SID);
            }
            else
            {
                //this.bt承認依頼.Enabled = false;
            }
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

            this.tx保険連絡年月日.ValueChanged += new System.EventHandler(this.tx保険連絡年月日_ValueChanged);
            this.tx保険連絡年月日.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx保険連絡年月日_KeyDown);
            this.tx保険連絡年月日.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tx保険連絡年月日_MouseDown);

            this.dtp帰庫予定日.ValueChanged += new System.EventHandler(this.dtp帰庫予定日_ValueChanged);
            this.dtp帰庫予定日.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp帰庫予定日_KeyDown);
            this.dtp帰庫予定日.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtp帰庫予定日_MouseDown);

            //nullを設定した場合
            dateTime = null;
            setDateTimePicker(dateTime, "保険連絡");
            setDateTimePicker(dateTime, "帰庫");

            //排他ロック解除
            JikoInfo.ExUnlock();

            this._JikoInfo.SID = this.currentSID;

            this.doFilter_登録番号();
            this.doFilter_車両種別();
            this.doFilter_乗務員名();
            this.doFilter_荷主名();
            this.doFilter_保険会社();
            this.doFilter_責任区();

            this.setData(this.currentSID);

            if (this.currentSID == DB.NEW_SID)
            {
                //新規作成
                this.getBumonName(this.currentBUMON);

                this.tx版.Text = "0";
                this.bt印刷.Enabled = false;
                this.bt削除.Enabled = false;
                this.bt変更.Enabled = false;
                this.bt承認配信.Enabled = false;
                this.ck強制.Enabled = false;
                this.tx作成日時.Text = "";
                this.tx確認日時.Text = "";
                this.ck1.Focus();
            }
            else
            {
                this.bt印刷.Enabled = true;
                this.bt削除.Enabled = true;
                this.bt変更.Enabled = true;
                this.btクリア.Enabled = true;
                this.bt承認配信.Enabled = true;

                if (this._JikoInfo.完了 == "1")
                {
                    this.ck1.Enabled = false;
                    this.ck2.Enabled = false;
                    this.ck3.Enabled = false;
                    this.ck4.Enabled = false;
                    this.ck5.Enabled = false;
                    this.ck6.Enabled = false;

                    this.tx発生日.Enabled = false;
                    this.tx曜日.Enabled = false;
                    this.tx発生時刻.Enabled = false;
                    this.tx発生場所.Enabled = false;

                    this.cb登録番号.Enabled = false;
                    this.cb車両種別.Enabled = false;

                    this.tx荷主カナ.Enabled = false;
                    this.cb荷主名.Enabled = false;
                    this.tx便名.Enabled = false;

                    this.cb保険会社名.Enabled = false;
                    this.tx保険連絡年月日.Enabled = false;
                    this.tx保険連絡時刻.Enabled = false;

                    this.cb責任区.Enabled = false;
                    this.tx責任区担当.Enabled = false;
                    this.tx所轄署.Enabled = false;
                    this.tx所轄担当.Enabled = false;

                    this.tx乗務員カナ.Enabled = false;
                    this.cb乗務員名.Enabled = false;
                    this.dtp帰庫予定日.Enabled = false;
                    this.tx帰庫予定時刻.Enabled = false;
                    this.tx乗務員負傷.Enabled = false;

                    this.tx相手方名.Enabled = false;
                    this.tx相手方tel.Enabled = false;
                    this.tx相手方住所.Enabled = false;
                    this.tx相手方負傷.Enabled = false;

                    this.tx物損損傷.Enabled = false;

                    this.tx事故状況.Enabled = true;
                    this.tx事故状況.ReadOnly = true;

                    this.tx処置対応.Enabled = true;
                    this.tx処置対応.ReadOnly = true;

                    this.bt削除.Enabled = false;
                    this.bt変更.Enabled = false;
                    this.btクリア.Enabled = false;
                    this.bt承認配信.Enabled = false;
                    this.tx作成者.Enabled = false;
                    this.tx確認者.Enabled = false;
                    this.ck強制.Enabled = false;
                    this.bt印刷.Focus();
                }
                else
                {
                    //作成営業所と違う場合
                    if (this.currentBUMON != this.tx営業所CD.Text)
                    {
                        if (adminCD != "0")
                        {
                            //ブロック長の場合
                        }
                        else
                        {
                            //ブロック長で無い場合
                            this.ck1.Enabled = false;
                            this.ck2.Enabled = false;
                            this.ck3.Enabled = false;
                            this.ck4.Enabled = false;
                            this.ck5.Enabled = false;
                            this.ck6.Enabled = false;

                            this.tx発生日.Enabled = false;
                            this.tx曜日.Enabled = false;
                            this.tx発生時刻.Enabled = false;
                            this.tx発生場所.Enabled = false;

                            this.tx登録番号検索.Enabled = false;
                            this.cb登録番号.Enabled = false;
                            this.cb車両種別.Enabled = false;

                            this.tx荷主カナ.Enabled = false;
                            this.cb荷主名.Enabled = false;
                            this.tx便名.Enabled = false;

                            this.cb保険会社名.Enabled = false;
                            this.tx保険連絡年月日.Enabled = false;
                            this.tx保険連絡時刻.Enabled = false;

                            this.cb責任区.Enabled = false;
                            this.tx責任区担当.Enabled = false;
                            this.tx所轄署.Enabled = false;
                            this.tx所轄担当.Enabled = false;

                            this.tx乗務員カナ.Enabled = false;
                            this.cb乗務員名.Enabled = false;
                            this.dtp帰庫予定日.Enabled = false;
                            this.tx帰庫予定時刻.Enabled = false;
                            this.tx乗務員負傷.Enabled = false;

                            this.tx相手方名.Enabled = false;
                            this.tx相手方tel.Enabled = false;
                            this.tx相手方住所.Enabled = false;
                            this.tx相手方負傷.Enabled = false;

                            this.tx物損損傷.Enabled = false;

                            this.tx事故状況.Enabled = true;
                            this.tx事故状況.ReadOnly = true;

                            this.tx処置対応.Enabled = true;
                            this.tx処置対応.ReadOnly = true;

                            this.bt削除.Enabled = false;
                            this.bt変更.Enabled = false;
                            this.btクリア.Enabled = false;
                            this.bt承認配信.Enabled = false;
                            this.tx作成者.Enabled = false;
                            this.tx確認者.Enabled = false;
                            this.ck強制.Enabled = false;
                            this.bt印刷.Focus();
                        }
                    }
                    if (modeFlg == true)
                    {
                        //安全品質モードの場合
                        this.ModeChange();
                    }
                    this.doExLockCheck();
                }
            }

        }

        private void getBumonName(string bumonCD)
        {
            //レスポンス改善のため、Connectionは最初に貼る
            MySqlConnection myconn = DB.GetConnection();

            //基本情報
            String query = String.Format(" select * from m_部門 where 部門コード={0} ", bumonCD);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            while (rs.Read())
            {
                this.tx営業所CD.Text = DB.NVL(rs["部門コード"]).ToString();
                this.tx営業所.Text = DB.NVL(rs["部門名"]).ToString();
            }
        }
        private void setData(string sid)
        {
            //レスポンス改善のため、Connectionは最初に貼る
            MySqlConnection myconn = DB.GetConnection();

            //基本情報
            String query = String.Format(" select * from v_g_事故情報２ where sid={0} ", DB.Escape(sid));
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            while (rs.Read())
            {
                this.tx事故NO.Text = DB.NVL(rs["事故NO"]).ToString();
                this.tx営業所CD.Text = DB.NVL(rs["営業所CD"]).ToString();
                this.tx営業所.Text = DB.NVL(rs["営業所"]).ToString();
                this.tx版.Text = DB.NVL(rs["版数"]).ToString();
                this.tx発生日.Text = DB.NVL(rs["発生日"]).ToString();
                this.tx曜日.Text = DateTime.Parse(this.tx発生日.Text).ToString("ddd");

                this.tx発生時刻.Text = DB.NVL(rs["発生時間"]).ToString();
                this.cb登録番号.Text = DB.NVL(rs["登録番号"]).ToString();
                this.tx発生場所.Text = DB.NVL(rs["発生場所"]).ToString();

                this.cb荷主名.Text = DB.NVL(rs["荷主"]).ToString();
                this.tx便名.Text = DB.NVL(rs["便名"]).ToString();

                this.cb乗務員名.Text = DB.NVL(rs["乗務員名"]).ToString();
                set年数(DB.NVL(rs["社員CD"]).ToString());

                if (DB.NVL(rs["帰庫予定日"]).ToString() == " " || DB.NVL(rs["帰庫予定日"]).ToString() == "")
                {
                    setDateTimePicker(null, "帰庫");
                }
                else
                {
                    this.dtp帰庫予定日.Text = DB.NVL(rs["帰庫予定日"]).ToString();
                }

                this.tx帰庫予定時刻.Text = DB.NVL(rs["帰庫予定時刻"]).ToString();
                this.tx乗務員負傷.Text = DB.NVL(rs["乗務員詳細"]).ToString();
                this.tx相手方名.Text = DB.NVL(rs["相手方氏名"]).ToString();
                this.tx相手方tel.Text = DB.NVL(rs["相手方tel"]).ToString();
                this.tx相手方住所.Text = DB.NVL(rs["相手方住所"]).ToString();
                this.tx相手方負傷.Text = DB.NVL(rs["相手方詳細"]).ToString();
                this.tx物損損傷.Text = DB.NVL(rs["物損詳細"]).ToString();

                this.cb保険会社名.Text = DB.NVL(rs["保険会社名"]).ToString();
                if (DB.NVL(rs["保険会社日付"]).ToString() == " ")
                {
                    setDateTimePicker(null,"保険連絡");
                }
                else
                {
                    this.tx保険連絡年月日.Text = DB.NVL(rs["保険会社日付"]).ToString();
                }
                this.tx保険連絡時刻.Text = DB.NVL(rs["保険会社時刻"]).ToString();

                this.cb責任区.Text = DB.NVL(rs["責任区"]).ToString();
                this.tx責任区担当.Text = DB.NVL(rs["責任区担当"]).ToString();

                this.tx所轄署.Text = DB.NVL(rs["所轄署"]).ToString();
                this.tx所轄担当.Text = DB.NVL(rs["所轄担当"]).ToString();

                this.tx事故状況.Text = DB.NVL(rs["状況"]).ToString();
                this.tx処置対応.Text = DB.NVL(rs["処置"]).ToString();

                this.tx作成者.Text = DB.NVL(rs["作成者"]).ToString();
                this.tx確認者.Text = DB.NVL(rs["確認者"]).ToString();

                if (DB.NVL(rs["最終更新日時"]).ToString() == "")
                {
                    this.tx作成日時.Text = "";
                }
                else
                {
                    this.tx作成日時.Text = DateTime.Parse(DB.NVL(rs["最終更新日時"]).ToString()).ToString("yyyy/MM/dd");
                }

                if (DB.NVL(rs["確認日時"]).ToString()=="")
                {
                    this.tx確認日時.Text = "";
                }
                else
                {
                    this.tx確認日時.Text = DateTime.Parse(DB.NVL(rs["確認日時"]).ToString()).ToString("yyyy/MM/dd");
                }

                this._JikoInfo.更新者ID = DB.NVL(rs["更新者ID"]).ToString();
                this._JikoInfo.最終更新日時 = DB.NVL(rs["最終更新日時"]).ToString();
                this._JikoInfo.確認者ID = DB.NVL(rs["確認者ID"]).ToString();
                this._JikoInfo.確認日時 = DB.NVL(rs["確認日時"]).ToString();
                this._JikoInfo.安全担当ID = DB.NVL(rs["安全担当ID"]).ToString();
                this._JikoInfo.安全確認日時 = DB.NVL(rs["安全確認日時"]).ToString();
                this._JikoInfo.削除者ID = DB.NVL(rs["削除者ID"]).ToString();
                this._JikoInfo.削除日時 = DB.NVL(rs["削除日時"]).ToString();
                this._JikoInfo.削除FLG = DB.NVL(rs["削除FLG"]).ToString();
                this._JikoInfo.非表示FLG = DB.NVL(rs["非表示FLG"]).ToString();
                this._JikoInfo.安全品質承認FLG = DB.NVL(rs["安全品質承認FLG"]).ToString();

                if (DB.NVL(rs["強制FLG"]).ToString() == "0")
                {
                    this.ck強制.Checked = false;
                }
                else
                {
                    this.ck強制.Checked = true;
                }

                if (DB.NVL(rs["事故区分_労災"]).ToString() == "0")
                {
                    this.ck1.Checked = false;
                }
                else
                {
                    this.ck1.Checked = true;
                }

                if (DB.NVL(rs["事故区分_車両"]).ToString() == "0")
                {
                    this.ck2.Checked = false;
                }
                else
                {
                    this.ck2.Checked = true;
                }

                if (DB.NVL(rs["事故区分_荷物"]).ToString() == "0")
                {
                    this.ck3.Checked = false;
                }
                else
                {
                    this.ck3.Checked = true;
                }

                if (DB.NVL(rs["事故区分_品質"]).ToString() == "0")
                {
                    this.ck4.Checked = false;
                }
                else
                {
                    this.ck4.Checked = true;
                }

                if (DB.NVL(rs["事故区分_環境"]).ToString() == "0")
                {
                    this.ck5.Checked = false;
                }
                else
                {
                    this.ck5.Checked = true;
                }

                if (DB.NVL(rs["事故区分_貰い"]).ToString() == "0")
                {
                    this.ck6.Checked = false;
                }
                else
                {
                    this.ck6.Checked = true;
                }

                this._JikoInfo.完了= DB.NVL(rs["完了"]).ToString();
            }
            rs.Close();
            rs.Dispose();
        }

        private void tx発生日_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb発生日_Click(object sender, EventArgs e)
        {

        }

        private void bt印刷_Click(object sender, EventArgs e)
        {
            this.doExcel();
        }

        private void bt削除_Click(object sender, EventArgs e)
        {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("本当に、削除してよろしいですか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                this.bt削除.Enabled = false;
                try
                {
                    this.getData("削除");
                    this._JikoInfo.状態 = "削除";
                    this._JikoInfo.削除FLG = "1";
                    this._JikoInfo.削除者ID = Environment.MachineName;
                    this._JikoInfo.削除日時 = DateTime.Now.ToString();

                    this.Validate();
                    this._JikoInfo.Save();

                    Msg.Info("内容を削除しました。");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void bt変更_Click(object sender, EventArgs e)
        {

            this.bt承認依頼.Enabled = false;
            try
            {
                var div = "承認待ち";
                this.getData(div);
                this._JikoInfo.状態 = "承認待ち";
                this._JikoInfo.更新者ID = Environment.MachineName;
                this._JikoInfo.最終更新日時 = DateTime.Now.ToString();
                this.doFilter_作成者(); //確認者・確認者共通

                this.Validate();
                this._JikoInfo.Save();

                string[] cmds = System.Environment.GetCommandLineArgs();
                var fromUser = cmds[1];
                var usid = "s.ushinohama@ingroup.co.jp";
                var pass = "inl-1926";
#if DEBUG
#else
                this._JikoInfo.sendmail(usid, pass, fromUser, div);
#endif
                Msg.Info("内容を保存しました。");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void bt承認配信_Click(object sender, EventArgs e)
        {
            try
            {
                var DIVFLG = "";
                var div = "配信済み";
                DIVFLG = this.getData(div);
                if (DIVFLG == "0")
                {
                    Msg.Info("登録できませんでした。\r\n事故区分が選択されていません。\r\n最低１つは選択してください。");
                }
                else
                {
                    this.bt承認配信.Enabled = false;

                    this._JikoInfo.状態 = "配信済み";
                    this._JikoInfo.版数 = (Int32.Parse(this.tx版.Text) + 1).ToString();
                    this._JikoInfo.確認日時 = DateTime.Now.ToString();
                    this.doFilter_確認者(); //確認者

                    this.Validate();
                    this._JikoInfo.Save();

                    string[] cmds = System.Environment.GetCommandLineArgs();
                    var fromUser = cmds[1];
                    var usid = "s.ushinohama@ingroup.co.jp";
                    var pass = "inl-1926";
#if DEBUG
#else
                        this._JikoInfo.sendmail(usid, pass, fromUser, div);
#endif
                    Msg.Info("内容を保存しました。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void btクリア_Click(object sender, EventArgs e)
        {
            ck1.Checked = false;
            ck2.Checked = false;
            ck3.Checked = false;
            ck4.Checked = false;
            ck5.Checked = false;
            ck6.Checked = false;
            tx発生日.Text = "";
            tx曜日.Text = "";
            tx発生時刻.Text = "";
            tx発生場所.Text = "";
            cb登録番号.Text = "";
            cb車両種別.Text = "";
            tx荷主カナ.Text = "";
            cb荷主名.Text = "";
            tx便名.Text = "";
            tx乗務員カナ.Text = "";
            cb乗務員名.Text = "";
            tx年齢.Text = "";
            tx勤続年数.Text = "";
            tx事故回数.Text = "";
            setDateTimePicker(null, "帰庫");
            tx乗務員負傷.Text = "";
            tx相手方名.Text = "";
            tx相手方tel.Text = "";
            tx相手方住所.Text = "";
            tx相手方負傷.Text = "";
            tx物損損傷.Text = "";
            cb保険会社名.Text = "";
            tx責任区担当.Text = "";
            tx所轄担当.Text = "";
            setDateTimePicker(null, "保険連絡");
            tx保険連絡時刻.Text = "";
            cb責任区.Text = "";
            tx所轄署.Text = "";
            tx事故状況.Text = "";
            tx処置対応.Text = "";
        }

        private void bt承認依頼_Click(object sender, EventArgs e)
        {
            try
            {
                var DIVFLG = ""; 
                var div = "承認待ち";

                DIVFLG = this.getData(div);
                if (DIVFLG == "0")
                {
                    Msg.Info("登録できませんでした。\r\n事故区分が選択されていません。\r\n最低１つは選択してください。");
                }
                else
                {
                    this.bt承認依頼.Enabled = false;
                    this._JikoInfo.状態 = "承認待ち";
                    this.doFilter_作成者();  //作成者・確認者共通
                    this._JikoInfo.最終更新日時 = DateTime.Now.ToString();

                    this.Validate();
                    this._JikoInfo.Save();

                    string[] cmds = System.Environment.GetCommandLineArgs();
                    var fromUser = cmds[1];
                    var usid = "s.ushinohama@ingroup.co.jp";
                    var pass = "inl-1926";
#if DEBUG
                    this._JikoInfo.sendmail(usid, pass, fromUser, div);
#else

                    this._JikoInfo.sendmail(usid, pass, fromUser, div);
#endif

                    Msg.Info("内容を保存しました。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public string getData(string div)
        {
            var wk事故区分 = "";

            this._JikoInfo.営業所CD = tx営業所CD.Text;
            this._JikoInfo.営業所 = tx営業所.Text;
            this._JikoInfo.NNO = tx事故NO.Text;
            this._JikoInfo.発生日 = tx発生日.Text;
            this._JikoInfo.発生時間 = tx発生時刻.Text;

            this._JikoInfo.登録番号 = cb登録番号.Text;
            this._JikoInfo.車両種別 = cb車両種別.Text;

            this._JikoInfo.発生場所 = tx発生場所.Text;
            this._JikoInfo.荷主 = cb荷主名.Text;
            this._JikoInfo.便名 = tx便名.Text;

            this._JikoInfo.乗務員名 = cb乗務員名.Text;
            this._JikoInfo.帰庫予定日 = dtp帰庫予定日.Text;
            this._JikoInfo.帰庫予定時刻 = tx帰庫予定時刻.Text;
            this._JikoInfo.勤続年数 = tx勤続年数.Text;

            this._JikoInfo.乗務員詳細 = tx乗務員負傷.Text;
            this._JikoInfo.相手方氏名 = tx相手方名.Text;
            this._JikoInfo.相手方tel = tx相手方tel.Text;
            this._JikoInfo.相手方住所 = tx相手方住所.Text;
            this._JikoInfo.相手方詳細 = tx相手方負傷.Text;
            this._JikoInfo.物損詳細 = tx物損損傷.Text;
            this._JikoInfo.保険会社名 = cb保険会社名.Text;
            this._JikoInfo.保険会社日付 = tx保険連絡年月日.Text;
            this._JikoInfo.保険会社時刻 = tx保険連絡時刻.Text;
            this._JikoInfo.責任区 = cb責任区.Text;
            this._JikoInfo.責任区担当 = tx責任区担当.Text;
            this._JikoInfo.所轄署 = tx所轄署.Text;
            this._JikoInfo.所轄担当 = tx所轄担当.Text;
            this._JikoInfo.状況 = tx事故状況.Text;
            this._JikoInfo.処置 = tx処置対応.Text;
            this._JikoInfo.作成者 = tx作成者.Text;
            this._JikoInfo.最終更新日時 = tx作成日時.Text;
            this._JikoInfo.確認者 = tx確認者.Text;
            this._JikoInfo.確認日時 = tx確認日時.Text;
            this._JikoInfo.版数 = tx版.Text;

            this._JikoInfo.削除FLG = "0";
            this._JikoInfo.非表示FLG = "0";
            this._JikoInfo.強制FLG = ck強制.Text;
            this._JikoInfo.状態 = div;

            if (ck強制.Checked == true)
            {
                this._JikoInfo.強制FLG = "1";
            }
            else
            {
                this._JikoInfo.強制FLG = "0";
            }

            if (ck1.Checked == true)
            {
                wk事故区分 = wk事故区分 + "労災 ";
                this._JikoInfo.事故区分_労災 = "1";
            }
            else
            {
                this._JikoInfo.事故区分_労災 = "0";
            }

            if (ck2.Checked == true)
            {
                wk事故区分 = wk事故区分 + "車両 ";
                this._JikoInfo.事故区分_車両 = "1";
            }
            else
            {
                this._JikoInfo.事故区分_車両 = "0";
            }

            if (ck3.Checked == true)
            {
                wk事故区分 = wk事故区分 + "荷物 ";
                this._JikoInfo.事故区分_荷物 = "1";
            }
            else
            {
                this._JikoInfo.事故区分_荷物 = "0";
            }

            if (ck4.Checked == true)
            {
                wk事故区分 = wk事故区分 + "品質 ";
                this._JikoInfo.事故区分_品質 = "1";
            }
            else
            {
                this._JikoInfo.事故区分_品質 = "0";
            }

            if (ck5.Checked == true)
            {
                this._JikoInfo.事故区分_環境 = "1";
                wk事故区分 = wk事故区分 + "環境 ";
            }
            else
            {
                this._JikoInfo.事故区分_環境 = "0";
            }

            if (ck6.Checked == true)
            {
                wk事故区分 = wk事故区分 + "貰い ";
                this._JikoInfo.事故区分_貰い = "1";
            }
            else
            {
                this._JikoInfo.事故区分_貰い = "0";
            }

            this._JikoInfo.事故区分 = wk事故区分;
            if (wk事故区分=="")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        private void setvalue(IXLRange cell, Object value, Boolean needFormat = false)
        {
            string buff;

            if (value == null)
            {
                buff = "";
            }
            else
            {
                buff = value.ToString();
            }

            if (needFormat)
            {
                cell.Value = buff;
            }
            else
            {
                cell.Value = "'" + buff;
            }
        }

        private void doExcel()
        {
            XLWorkbook xlBook = new XLWorkbook("//192.168.1.230/共有フォルダ(公開)/01_本社/システム課/03_システム/事故報告書作成システム/事故管理/速/Report/事故速報temp.xlsx");
            IXLWorksheet xlSheet = xlBook.Worksheet("原紙");

            String fileName = Func.GetTempFolder() + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            xlBook.SaveAs(fileName);

            xlSheet.Cells("A1").Select();

            #region "ヘッダ"

            var wk事故区分 = "";

            if (this.ck1.Checked == true)
            {
                wk事故区分 = wk事故区分 + "労災 ";
            }
            if (this.ck2.Checked == true)
            {
                wk事故区分 = wk事故区分 + "車両 ";
            }
            if (this.ck3.Checked == true)
            {
                wk事故区分 = wk事故区分 + "荷物 ";
            }
            if (this.ck4.Checked == true)
            {
                wk事故区分 = wk事故区分 + "品質 ";
            }
            if (this.ck5.Checked == true)
            {
                wk事故区分 = wk事故区分 + "環境 ";
            }
            if (this.ck6.Checked == true)
            {
                wk事故区分 = wk事故区分 + "貰い ";
            }

            this.setvalue(xlSheet.Range("版"), this.tx版.Text);
            this.setvalue(xlSheet.Range("営業所"), this.tx営業所.Text);
            this.setvalue(xlSheet.Range("事故NO"), this.tx事故NO.Text);
            this.setvalue(xlSheet.Range("事故区分"), wk事故区分);
            this.setvalue(xlSheet.Range("発生日付"), this.tx発生日.Text);
            this.setvalue(xlSheet.Range("発生時刻"), this.tx発生時刻.Text);
            this.setvalue(xlSheet.Range("発生場所１"), this.tx発生場所.Text);
            //this.setvalue(xlSheet.Range("発生場所２"), "現在未使用");
            this.setvalue(xlSheet.Range("登録番号"), this.cb登録番号.Text);
            this.setvalue(xlSheet.Range("車種"), this.cb車両種別.Text);
            this.setvalue(xlSheet.Range("荷主名"), this.cb荷主名.Text);
            this.setvalue(xlSheet.Range("便名"), this.tx便名.Text);
            this.setvalue(xlSheet.Range("乗務員氏名"), this.cb乗務員名.Text);
            this.setvalue(xlSheet.Range("年齢"), this.tx年齢.Text);
            this.setvalue(xlSheet.Range("勤続年数"), this.tx勤続年数.Text);
            this.setvalue(xlSheet.Range("帰庫予定日"), this.dtp帰庫予定日.Text);
            this.setvalue(xlSheet.Range("帰庫予定時刻"), this.tx帰庫予定時刻.Text);
            this.setvalue(xlSheet.Range("乗務員負傷"), this.tx乗務員負傷.Text);
            this.setvalue(xlSheet.Range("相手方氏名"), this.tx相手方名.Text);
            this.setvalue(xlSheet.Range("相手方tel"), this.tx相手方tel.Text);
            this.setvalue(xlSheet.Range("相手方住所"), this.tx相手方住所.Text);
            this.setvalue(xlSheet.Range("相手方負傷"), this.tx相手方負傷.Text);
            this.setvalue(xlSheet.Range("物損損傷"), this.tx物損損傷.Text);
            this.setvalue(xlSheet.Range("保険会社名"), this.cb保険会社名.Text);
            if (this.tx保険連絡年月日.Text == "")
            {
                this.setvalue(xlSheet.Range("保険時刻"), this.tx保険連絡年月日.Text);
            }
            else
            {
                this.setvalue(xlSheet.Range("保険時刻"), this.tx保険連絡年月日.Text + " " + tx保険連絡時刻.Text);
            }
            this.setvalue(xlSheet.Range("責任区"), this.cb責任区.Text);
            this.setvalue(xlSheet.Range("責任区担当"), this.tx責任区担当.Text);
            this.setvalue(xlSheet.Range("所轄署"), this.tx所轄署.Text);
            this.setvalue(xlSheet.Range("所轄署担当"), this.tx所轄担当.Text);
            this.setvalue(xlSheet.Range("確認者"), this.tx確認者.Text);
            this.setvalue(xlSheet.Range("確認日時"), this.tx確認日時.Text);
            this.setvalue(xlSheet.Range("作成者"), this.tx作成者.Text);
            this.setvalue(xlSheet.Range("作成日時"), this.tx作成日時.Text);
            this.setvalue(xlSheet.Range("状況"), this.tx事故状況.Text);
            this.setvalue(xlSheet.Range("処置"), this.tx処置対応.Text);

            #endregion

            try
            {
                xlBook.SaveAs(fileName);

                Func.SetReadonly(fileName, true);

                Process.Start(fileName);
            }
            catch
            {
                Exception ex = new Exception();
                Msg.ShowError(ex.Message);
            }

        }

        private void ck強制_CheckedChanged(object sender, EventArgs e)
        {
            if (ck強制.Checked == true)
            {
                bt承認配信.Enabled = true;
            }
            else
            {
                bt承認配信.Enabled = false;
            }
        }

        private void cb登録番号_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            if (this.cb登録番号.Text == "") 
            {
                this.cb車両種別.Text = "";
            }
            else
            {
                MySqlConnection myconn = DB.GetConnection();

                String query = String.Format("SELECT * FROM v_m_車両 WHERE 登録番号={0}", DB.Escape(this.cb登録番号.Text));
                MySqlDataReader rs;
                rs = DB.GetReader(myconn, query);

                while (rs.Read())
                {
                    this.cb車両種別.Text = DB.NVL(rs["名称"]).ToString();
                }
            }
        }

        private void doFilter_乗務員名()
        {
            MySqlConnection myconn = DB.GetConnection();

            String query = String.Format(" select 社員コード,氏名 from v_g_社員list where カナ like {0} and not ISNULL(氏名)  and (退職年月日 is NULL OR DATE_ADD(退職年月日,INTERVAL 1 MONTH) > CURRENT_DATE())", DB.Escape('%' + this.tx乗務員カナ.Text + '%'));
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            this.cb乗務員名.Items.Clear();
            var _jikoInfo = new JikoInfo();
            _jikoInfo.item1 = "";
            _jikoInfo.item2 = "";
            this.cb乗務員名.Items.Add(_jikoInfo);
            while (rs.Read())
            {
                _jikoInfo = new JikoInfo();
                _jikoInfo.item1 = DB.NVL(rs["氏名"]).ToString();
                _jikoInfo.item2 = DB.NVL(rs["社員コード"]).ToString();
                this.cb乗務員名.Items.Add(_jikoInfo);
            }

            this.cb乗務員名.Refresh();
        }

        private void doFilter_保険会社()
        {
            MySqlConnection myconn = DB.GetConnection();

            String query = String.Format($" select * from v_m_保険 where 営業所CD = {currentBUMON} group BY `会社名`,`営業所CD`");
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);
            var DefBumon = "";

            this.cb保険会社名.Items.Clear();
            while (rs.Read())
            {
                var _jikoInfo = new JikoInfo();
                _jikoInfo.item1 = DB.NVL(rs["会社名"]).ToString();
                _jikoInfo.item2 = DB.NVL(rs["営業所CD"]).ToString();

                if (_jikoInfo.item2 == this.currentBUMON)
                {
                    DefBumon = _jikoInfo.item1;
                }

                this.cb保険会社名.Items.Add(_jikoInfo);
            }

            cb保険会社名.Refresh();
            this.cb保険会社名.Text = DefBumon;
        }

        private void doFilter_荷主名()
        {
            MySqlConnection myconn = DB.GetConnection();

            String query = "select 荷主名 from v_m_荷主マスタ WHERE 検索キー like '%" + this.tx荷主カナ.Text+"%'";
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            List<string> list = new List<string>();
            list.Add("");
            while (rs.Read())
            {
                list.Add(rs.GetString("荷主名"));
            }

            cb荷主名.DataSource = list.ToArray();
            cb荷主名.Refresh();

        }

        private void doFilter_登録番号()
        {

            MySqlConnection myconn = DB.GetConnection();

            String query = "select 登録番号 from v_m_登録番号 WHERE 登録番号 like '%"+this.tx登録番号検索.Text+"%'";
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            List<string> list = new List<string>();
            list.Add("");
            while (rs.Read())
            {
                list.Add(rs.GetString("登録番号"));
            }

            cb登録番号.DataSource = list.ToArray();
            cb登録番号.Refresh();
            rs.Close();

        }

        private void doFilter_車両種別()
        {

            MySqlConnection myconn = DB.GetConnection();

            String query = "select 名称 from v_m_車種";
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            List<string> list = new List<string>();
            list.Add("");
            while (rs.Read())
            {
                list.Add(rs.GetString("名称"));
            }

            cb車両種別.DataSource = list.ToArray();
            cb車両種別.Refresh();
            rs.Close();

        }
        private void doFilter_確認者()
        {
            MySqlConnection myconn = DB.GetConnection();

            //コマンドライン引数を配列で取得する
            string[] cmds = System.Environment.GetCommandLineArgs();
            //基本情報
            String query = String.Format("SELECT DISTINCT 氏 FROM `m_管理ユーザー` WHERE Email = '{0}' ", cmds[1]);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            rs.Read();
            this.tx確認者.Text = DB.NVL(rs["氏"]).ToString();
            _JikoInfo.確認者 = this.tx確認者.Text;
            rs.Close();

        }
        private void doFilter_作成者()
        {
            MySqlConnection myconn = DB.GetConnection();

            //コマンドライン引数を配列で取得する
            string[] cmds = System.Environment.GetCommandLineArgs();
            //基本情報
            String query = String.Format("SELECT DISTINCT 氏 FROM `m_管理ユーザー` WHERE Email = '{0}' ", cmds[1]);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            rs.Read();
            this.tx作成者.Text = DB.NVL(rs["氏"]).ToString();
            _JikoInfo.作成者 = this.tx作成者.Text;

            rs.Close();

            /*2021/04/30
            //レスポンス改善のため、Connectionは最初に貼る
            MySqlConnection myconn = DB.GetConnection();

            //基本情報
            String query = String.Format(" select * from m管理user where 営業所CD={0} ", this.currentBUMON);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            this.cb作成者.Items.Clear();
            this.cb確認者.Items.Clear();
            var _jikoInfo = new JikoInfo();
            _jikoInfo.item1 = "";
            _jikoInfo.item2 = "";
            this.cb作成者.Items.Add(_jikoInfo);
            this.cb確認者.Items.Add(_jikoInfo);

            while (rs.Read())
            {
                _jikoInfo = new JikoInfo();
                _jikoInfo.item1 = DB.NVL(rs["苗字"]).ToString();
                _jikoInfo.item2 = DB.NVL(rs["PC_NAME"]).ToString();
                this.cb作成者.Items.Add(_jikoInfo);
                this.cb確認者.Items.Add(_jikoInfo);
            }


            cb作成者.Refresh();
            cb確認者.Refresh();
            */
        }

        private void doFilter_責任区()
        {
            //レスポンス改善のため、Connectionは最初に貼る
            MySqlConnection myconn = DB.GetConnection();

            //基本情報
            String query = String.Format(" select * from m_部門 where 部門コード<>{0} ", 99);
            MySqlDataReader rs;
            rs = DB.GetReader(myconn, query);

            this.cb責任区.Items.Clear();
            var _jikoInfo = new JikoInfo();
            _jikoInfo.item1 = "";
            _jikoInfo.item2 = "";
            this.cb責任区.Items.Add(_jikoInfo);
            while (rs.Read())
            {
                _jikoInfo = new JikoInfo();
                _jikoInfo.item1 = DB.NVL(rs["部門名"]).ToString();
                _jikoInfo.item2 = DB.NVL(rs["部門コード"]).ToString();
                this.cb責任区.Items.Add(_jikoInfo);
            }

            cb責任区.Refresh();
            rs.Close();

        }

        private void tx発生時刻_Leave(object sender, EventArgs e)
        {
            var s = (this.tx発生時刻.Text).Trim();
            int strb = 0;
            int strc = 0;
            try
            {
                if (s.IndexOf(":") >= 0)
                {
                    if (s.Length >= 6 || s.Length <= 3)
                    {

                    }
                    else
                    {
                        string[] a = s.Split(':');
                        strb = Int32.Parse(a[1]);
                        strc = Int32.Parse(a[0]);
                    }
                }
                else
                {
                    if (s.Length >= 5 || s.Length <= 2)
                    {
                    }
                    else
                    {
                        strb = Int32.Parse(s.Substring(s.Length - 2));
                        strc = Int32.Parse(s.Substring(0, s.Length - 2));
                    }
                }
                this.tx発生時刻.Text = $"{strc:00}:{strb:00}";
            }
            catch
            {
                MessageBox.Show("数字以外の値が入力されました。確認してください。");
                this.tx発生時刻.Text = "";
            }
        }

        private void tx保険連絡時刻_Leave(object sender, EventArgs e)
        {
            var s = (this.tx保険連絡時刻.Text).Trim();
            int strb = 0;
            int strc = 0;
            try
            {
                if (this.tx保険連絡時刻.Text == "" && this.cb保険会社名.Text == "")
                {
                    this.tx保険連絡時刻.Text = "";
                }
                else
                {
                    if (s.IndexOf(":") >= 0)
                    {
                        if (s.Length >= 6 || s.Length <= 3)
                        {

                        }
                        else
                        {
                            string[] a = s.Split(':');
                            strb = Int32.Parse(a[1]);
                            strc = Int32.Parse(a[0]);
                        }
                    }
                    else
                    {
                        if (s.Length >= 5 || s.Length <= 2)
                        {
                        }
                        else
                        {
                            strb = Int32.Parse(s.Substring(s.Length - 2));
                            strc = Int32.Parse(s.Substring(0, s.Length - 2));
                        }
                    }
                    this.tx保険連絡時刻.Text = $"{strc:00}:{strb:00}";
                }
            }
            catch
            {
                MessageBox.Show("数字以外の値が入力されました。確認してください。");
                this.tx保険連絡時刻.Text = "";
            }
        }

        private void cb乗務員名_SelectedIndexChanged(object sender, EventArgs e)
        {
            JikoInfo inf = (JikoInfo)this.cb乗務員名.SelectedItem;
            this.cb乗務員名.Text = inf.item1;
            _JikoInfo.乗務員名 = inf.item1;
            _JikoInfo.社員CD = inf.item2;

            Console.WriteLine();
        }

        private void tx乗務員カナ_Leave(object sender, EventArgs e)
        {
            doFilter_乗務員名();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tx発生日_ValueChanged(object sender, EventArgs e)
        {

            this.tx曜日.Text = DateTime.Parse(this.tx発生日.Text).ToString("ddd");
        }

        private void lbTitle_Click(object sender, EventArgs e)
        {
        }
        private void ModeChange()
        {
            var SI = 230;

            var YE = 255;

            var MA = 255;

            modeFlg = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx版.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx事故NO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx作成日時.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx確認日時.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx営業所CD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.tx営業所.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(SI)))), ((int)(((byte)(YE)))), ((int)(((byte)(MA)))));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));

            this.ck1.Enabled = false;
            this.ck2.Enabled = false;
            this.ck3.Enabled = false;
            this.ck4.Enabled = false;
            this.ck5.Enabled = false;
            this.ck6.Enabled = false;

            this.tx発生日.Enabled = false;
            this.tx曜日.Enabled = false;
            this.tx発生時刻.Enabled = false;
            this.tx発生場所.Enabled = false;

            this.cb登録番号.Enabled = false;
            this.cb車両種別.Enabled = false;

            this.tx荷主カナ.Enabled = false;
            this.cb荷主名.Enabled = false;
            this.tx便名.Enabled = false;

            this.cb保険会社名.Enabled = false;
            this.tx保険連絡年月日.Enabled = false;
            this.tx保険連絡時刻.Enabled = false;

            this.cb責任区.Enabled = false;
            this.tx責任区担当.Enabled = false;
            this.tx所轄署.Enabled = false;
            this.tx所轄担当.Enabled = false;

            this.tx乗務員カナ.Enabled = false;
            this.cb乗務員名.Enabled = false;
            this.tx乗務員負傷.Enabled = false;

            this.tx相手方名.Enabled = false;
            this.tx相手方tel.Enabled = false;
            this.tx相手方住所.Enabled = false;
            this.tx相手方負傷.Enabled = false;

            this.tx物損損傷.Enabled = false;

            this.tx事故状況.Enabled = true;
            this.tx事故状況.ReadOnly = true;

            this.tx処置対応.Enabled = true;
            this.tx処置対応.ReadOnly = true;

            this.bt削除.Enabled = false;
            this.bt変更.Enabled = false;
            this.btクリア.Enabled = false;
            this.bt承認配信.Enabled = false;
            this.tx作成者.Enabled = false;
            this.tx確認者.Enabled = false;
            this.ck強制.Enabled = false;
        }
        private void bt安全確認_Click(object sender, EventArgs e)
        {
        }

        private void tx保険連絡年月日_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                dateTime = null;
                setDateTimePicker(dateTime, "保険連絡");
            }
        }

        private void dtp帰庫予定日_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                //Deleteキーが押されたら、dateTimeにnullを設定してdateTimePicker1を非表示に
                dateTime = null;
                setDateTimePicker(dateTime, "帰庫");
            }
        }

        private void tx保険連絡年月日_ValueChanged(object sender, EventArgs e)
        {
            //tx保険連絡年月日の値が変更されたら表示する
            dateTime = tx保険連絡年月日.Value;
            setDateTimePicker(dateTime, "保険連絡");
        }
        private void dtp帰庫予定日_ValueChanged(object sender, EventArgs e)
        {
            //dtp帰庫予定日の値が変更されたら表示する
            dateTime = dtp帰庫予定日.Value;
            setDateTimePicker(dateTime, "帰庫");
        }
        private void setDateTimePicker(DateTime? datetime,string objname)
        {
            if (objname == "保険連絡")
            {
                if (datetime == null)
                {
                    //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
                    tx保険連絡年月日.Format = DateTimePickerFormat.Custom;
                    tx保険連絡年月日.CustomFormat = " ";
                }
                else
                {
                    //フォーマットを元に戻して、値をセットする。
                    tx保険連絡年月日.Format = DateTimePickerFormat.Short;
                    tx保険連絡年月日.Value = (DateTime)datetime;
                }
            }
            if (objname == "帰庫")
            {
                if (datetime == null)
                {
                    //DateTimePickerFormat.Custom　にして、CostomFormatは半角の空白を入れておくと、日時が非表示になる。
                    dtp帰庫予定日.Format = DateTimePickerFormat.Custom;
                    dtp帰庫予定日.CustomFormat = " ";
                }
                else
                {
                    //フォーマットを元に戻して、値をセットする。
                    dtp帰庫予定日.Format = DateTimePickerFormat.Short;
                    dtp帰庫予定日.Value = (DateTime)datetime;
                }
            }
        }

        private void tx保険連絡年月日_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > tx保険連絡年月日.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void dtp帰庫予定日_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > dtp帰庫予定日.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void cb作成者_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*コンボボックスからテキストへ変更
            this.tx作成日時.Text = DateTime.Now.ToString("yyyy/MM/dd");
            JikoInfo inf = (JikoInfo)this.tx作成者.SelectedItem;
            _JikoInfo.更新者ID = inf.item2;
            */
        }

        private void cb確認者_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*コンボボックスからテキストへ変更
            this.tx確認日時.Text = DateTime.Now.ToString("yyyy/MM/dd");
            JikoInfo inf = (JikoInfo)this.tx確認者.SelectedItem;
            _JikoInfo.確認者ID = inf.item2;
            */
        }

        private void cb保険会社名_SelectedIndexChanged(object sender, EventArgs e)
        {
            JikoInfo inf = (JikoInfo)this.cb保険会社名.SelectedItem;
            _JikoInfo.保険会社名 = inf.item1;
            _JikoInfo.保険会社CD = inf.item2;
        }

        private void cb荷主名_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cb責任区_SelectedIndexChanged(object sender, EventArgs e)
        {
            JikoInfo inf = (JikoInfo)this.cb責任区.SelectedItem;
            _JikoInfo.責任区 = inf.item1;
            _JikoInfo.責任区CD = inf.item2;
        }

        private void InputForm_Shown(object sender, EventArgs e)
        {
        }

        private void tx発生日_Leave(object sender, EventArgs e)
        {
            this.tx曜日.Text = DateTime.Parse(this.tx発生日.Text).ToString("ddd");
        }

        private void ck1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ck1_Leave(object sender, EventArgs e)
        {
            this.tx曜日.Text = DateTime.Parse(this.tx発生日.Text).ToString("ddd");
        }


        private void cb登録番号_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void tx登録番号検索_TextChanged(object sender, EventArgs e)
        {
            this.doFilter_登録番号();
        }

        private void tx荷主カナ_TextChanged(object sender, EventArgs e)
        {
            this.doFilter_荷主名();
        }

        private void tx乗務員カナ_TextChanged(object sender, EventArgs e)
        {
            this.doFilter_乗務員名();
        }

        private void tx保険連絡時刻_TextChanged(object sender, EventArgs e)
        {

        }
        private void set年数(string 社員CD)
        {
            if (社員CD == "")
            {
                this.tx年齢.Text = "";
                this.tx勤続年数.Text = "";
                this.tx事故回数.Text = "0";
            }
            else
            {
                //新規の場合
                //レスポンス改善のため、Connectionは最初に貼る
                MySqlConnection myconn = DB.GetConnection();

                //年齢　勤続年数算出

                String query = String.Format(" select * from v_g_社員list where 社員コード ={0} ", DB.Escape(社員CD));
                MySqlDataReader rs;
                rs = DB.GetReader(myconn, query);

                DateTime 発生日 = tx発生日.Value;

                while (rs.Read())
                {

                    var wk入社年月日 = DB.NVL(rs["入社年月日"]);
                    var wk勤続年数_y = (((発生日 - (DateTime)wk入社年月日).Days) / 30) / 12;
                    var wk勤続年数_m = (((発生日 - (DateTime)wk入社年月日).Days) / 30) - wk勤続年数_y * 12;
                    if (wk勤続年数_m == 0)
                    {
                        this.tx勤続年数.Text = String.Format("{0}年", wk勤続年数_y.ToString());
                    }
                    else
                    {
                        this.tx勤続年数.Text = String.Format("{0}年 {1}ヵ月", wk勤続年数_y.ToString(), wk勤続年数_m.ToString());
                    }

                    var wk生年月日 = DB.NVL(rs["生年月日"]);
                    var wk年齢 = (((発生日 - (DateTime)wk生年月日).Days) / 365);
                    this.tx年齢.Text = String.Format("{0}歳", wk年齢.ToString());
                }
                rs.Close();

                //事故回数算出
                query = String.Format("SELECT t2.事故日,t1.* FROM t_事故情報 t1,(select DATE_FORMAT(`発生日`,'%Y/%m/%d') AS 事故日,t_事故情報.* from t_事故情報 where 削除Flg = '0')t2 WHERE t1.sid = t2.sid AND t1.乗務員名 ={0} AND t2.事故日 <={1}", DB.Escape(this.cb乗務員名.Text), DB.Escape(this.tx発生日.Text));
                DataTable rs2;
                rs2 = DB.GetDataTable(myconn, query);
                DateTime 発生日2 = tx発生日.Value;
                this.tx事故回数.Text = (rs2.Rows.Count).ToString();

            }
        }

        private void cb乗務員名_Leave(object sender, EventArgs e)
        {
            set年数(this.cb乗務員名.Text);
        }

        private void tx物損損傷_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb乗務員名_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
