namespace JSoku
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbTitle = new System.Windows.Forms.Label();
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbSYMD = new System.Windows.Forms.Label();
            this.txFromYMD = new System.Windows.Forms.TextBox();
            this.txToYMD = new System.Windows.Forms.TextBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.cbDriverName = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ck1 = new System.Windows.Forms.CheckBox();
            this.ck2 = new System.Windows.Forms.CheckBox();
            this.ck3 = new System.Windows.Forms.CheckBox();
            this.ck4 = new System.Windows.Forms.CheckBox();
            this.ck5 = new System.Windows.Forms.CheckBox();
            this.ck6 = new System.Windows.Forms.CheckBox();
            this.lbDeiverKana = new System.Windows.Forms.Label();
            this.txDriverKana = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgJikoList = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sl接続先 = new System.Windows.Forms.ToolStripStatusLabel();
            this.slSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.slユーザ名 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bt新規作成 = new System.Windows.Forms.Button();
            this.cb営業所 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cb部門 = new System.Windows.Forms.ComboBox();
            this.編集btn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.sid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.削除FLG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.事故No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.発生日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.営業所 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.乗務員名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.車両コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.処理状況 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.区分 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.登録番号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.事故回数 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.荷主 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.便名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.営業所CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.乗務員カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.乗務員CD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生年月日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.入社年月日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.環境 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.車両 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.荷物 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.品質 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.労災 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.貰い = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gb1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJikoList)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("メイリオ", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbTitle.Location = new System.Drawing.Point(12, 13);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(120, 27);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "事故速報一覧";
            this.lbTitle.Click += new System.EventHandler(this.lbTitle_Click);
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LinkLabel2.Location = new System.Drawing.Point(1050, 601);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(56, 18);
            this.LinkLabel2.TabIndex = 10;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "更新履歴";
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LinkLabel1.Location = new System.Drawing.Point(1236, 568);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(92, 18);
            this.LinkLabel1.TabIndex = 9;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "操作マニュアル";
            this.LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // lbSYMD
            // 
            this.lbSYMD.AutoSize = true;
            this.lbSYMD.Location = new System.Drawing.Point(19, 21);
            this.lbSYMD.Name = "lbSYMD";
            this.lbSYMD.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbSYMD.Size = new System.Drawing.Size(44, 19);
            this.lbSYMD.TabIndex = 1;
            this.lbSYMD.Text = "発生日";
            // 
            // txFromYMD
            // 
            this.txFromYMD.Location = new System.Drawing.Point(69, 18);
            this.txFromYMD.Name = "txFromYMD";
            this.txFromYMD.Size = new System.Drawing.Size(86, 25);
            this.txFromYMD.TabIndex = 2;
            this.txFromYMD.TextChanged += new System.EventHandler(this.txFromYMD_TextChanged);
            // 
            // txToYMD
            // 
            this.txToYMD.Location = new System.Drawing.Point(183, 18);
            this.txToYMD.Name = "txToYMD";
            this.txToYMD.Size = new System.Drawing.Size(86, 25);
            this.txToYMD.TabIndex = 4;
            this.txToYMD.TextChanged += new System.EventHandler(this.txToYMD_TextChanged);
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.cbDriverName);
            this.gb1.Controls.Add(this.flowLayoutPanel1);
            this.gb1.Controls.Add(this.lbDeiverKana);
            this.gb1.Controls.Add(this.txDriverKana);
            this.gb1.Controls.Add(this.label1);
            this.gb1.Controls.Add(this.txToYMD);
            this.gb1.Controls.Add(this.lbSYMD);
            this.gb1.Controls.Add(this.txFromYMD);
            this.gb1.Location = new System.Drawing.Point(31, 43);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(948, 81);
            this.gb1.TabIndex = 0;
            this.gb1.TabStop = false;
            this.gb1.Text = "絞込検索";
            // 
            // cbDriverName
            // 
            this.cbDriverName.FormattingEnabled = true;
            this.cbDriverName.Location = new System.Drawing.Point(455, 17);
            this.cbDriverName.Name = "cbDriverName";
            this.cbDriverName.Size = new System.Drawing.Size(121, 26);
            this.cbDriverName.TabIndex = 7;
            this.cbDriverName.SelectedIndexChanged += new System.EventHandler(this.cbDriverName_SelectedIndexChanged);
            this.cbDriverName.TextUpdate += new System.EventHandler(this.cbDriverName_TextUpdate);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ck1);
            this.flowLayoutPanel1.Controls.Add(this.ck2);
            this.flowLayoutPanel1.Controls.Add(this.ck3);
            this.flowLayoutPanel1.Controls.Add(this.ck4);
            this.flowLayoutPanel1.Controls.Add(this.ck5);
            this.flowLayoutPanel1.Controls.Add(this.ck6);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(587, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(347, 27);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // ck1
            // 
            this.ck1.AutoSize = true;
            this.ck1.Location = new System.Drawing.Point(8, 3);
            this.ck1.Name = "ck1";
            this.ck1.Size = new System.Drawing.Size(51, 22);
            this.ck1.TabIndex = 0;
            this.ck1.Text = "労災";
            this.ck1.UseVisualStyleBackColor = true;
            this.ck1.CheckedChanged += new System.EventHandler(this.ck1_CheckedChanged);
            // 
            // ck2
            // 
            this.ck2.AutoSize = true;
            this.ck2.Location = new System.Drawing.Point(65, 3);
            this.ck2.Name = "ck2";
            this.ck2.Size = new System.Drawing.Size(51, 22);
            this.ck2.TabIndex = 1;
            this.ck2.Text = "車両";
            this.ck2.UseVisualStyleBackColor = true;
            this.ck2.CheckedChanged += new System.EventHandler(this.ck2_CheckedChanged);
            // 
            // ck3
            // 
            this.ck3.AutoSize = true;
            this.ck3.Location = new System.Drawing.Point(122, 3);
            this.ck3.Name = "ck3";
            this.ck3.Size = new System.Drawing.Size(51, 22);
            this.ck3.TabIndex = 2;
            this.ck3.Text = "荷物";
            this.ck3.UseVisualStyleBackColor = true;
            this.ck3.CheckedChanged += new System.EventHandler(this.ck3_CheckedChanged);
            // 
            // ck4
            // 
            this.ck4.AutoSize = true;
            this.ck4.Location = new System.Drawing.Point(179, 3);
            this.ck4.Name = "ck4";
            this.ck4.Size = new System.Drawing.Size(51, 22);
            this.ck4.TabIndex = 3;
            this.ck4.Text = "品質";
            this.ck4.UseVisualStyleBackColor = true;
            this.ck4.CheckedChanged += new System.EventHandler(this.ck4_CheckedChanged);
            // 
            // ck5
            // 
            this.ck5.AutoSize = true;
            this.ck5.Location = new System.Drawing.Point(236, 3);
            this.ck5.Name = "ck5";
            this.ck5.Size = new System.Drawing.Size(51, 22);
            this.ck5.TabIndex = 4;
            this.ck5.Text = "環境";
            this.ck5.UseVisualStyleBackColor = true;
            this.ck5.CheckedChanged += new System.EventHandler(this.ck5_CheckedChanged);
            // 
            // ck6
            // 
            this.ck6.AutoSize = true;
            this.ck6.Location = new System.Drawing.Point(293, 3);
            this.ck6.Name = "ck6";
            this.ck6.Size = new System.Drawing.Size(51, 22);
            this.ck6.TabIndex = 5;
            this.ck6.Text = "貰い";
            this.ck6.UseVisualStyleBackColor = true;
            this.ck6.CheckedChanged += new System.EventHandler(this.ck6_CheckedChanged);
            // 
            // lbDeiverKana
            // 
            this.lbDeiverKana.AutoSize = true;
            this.lbDeiverKana.Location = new System.Drawing.Point(282, 21);
            this.lbDeiverKana.Name = "lbDeiverKana";
            this.lbDeiverKana.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbDeiverKana.Size = new System.Drawing.Size(68, 19);
            this.lbDeiverKana.TabIndex = 5;
            this.lbDeiverKana.Text = "乗務員カナ";
            // 
            // txDriverKana
            // 
            this.txDriverKana.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.txDriverKana.Location = new System.Drawing.Point(353, 18);
            this.txDriverKana.Name = "txDriverKana";
            this.txDriverKana.Size = new System.Drawing.Size(100, 25);
            this.txDriverKana.TabIndex = 6;
            this.txDriverKana.TextChanged += new System.EventHandler(this.txDriverKana_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "～";
            // 
            // dgJikoList
            // 
            this.dgJikoList.AllowUserToAddRows = false;
            this.dgJikoList.AllowUserToDeleteRows = false;
            this.dgJikoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgJikoList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.編集btn,
            this.sid,
            this.削除FLG,
            this.事故No,
            this.発生日,
            this.時間,
            this.営業所,
            this.乗務員名,
            this.車両コード,
            this.処理状況,
            this.区分,
            this.登録番号,
            this.事故回数,
            this.荷主,
            this.便名,
            this.営業所CD,
            this.乗務員カナ,
            this.乗務員CD,
            this.生年月日,
            this.入社年月日,
            this.環境,
            this.車両,
            this.荷物,
            this.品質,
            this.労災,
            this.貰い});
            this.dgJikoList.Location = new System.Drawing.Point(15, 140);
            this.dgJikoList.Name = "dgJikoList";
            this.dgJikoList.ReadOnly = true;
            this.dgJikoList.RowHeadersVisible = false;
            this.dgJikoList.RowTemplate.Height = 21;
            this.dgJikoList.Size = new System.Drawing.Size(1313, 425);
            this.dgJikoList.TabIndex = 2;
            this.dgJikoList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgJikoList_CellContentClick);
            this.dgJikoList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgJikoList_CellFormatting);
            this.dgJikoList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgJikoList_DataError);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sl接続先,
            this.slSpacer,
            this.slユーザ名});
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1342, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sl接続先
            // 
            this.sl接続先.Name = "sl接続先";
            this.sl接続先.Size = new System.Drawing.Size(43, 17);
            this.sl接続先.Text = "接続先";
            // 
            // slSpacer
            // 
            this.slSpacer.Name = "slSpacer";
            this.slSpacer.Size = new System.Drawing.Size(1237, 17);
            this.slSpacer.Spring = true;
            // 
            // slユーザ名
            // 
            this.slユーザ名.Name = "slユーザ名";
            this.slユーザ名.Size = new System.Drawing.Size(47, 17);
            this.slユーザ名.Text = "ユーザ名";
            // 
            // bt新規作成
            // 
            this.bt新規作成.Location = new System.Drawing.Point(1222, 60);
            this.bt新規作成.Name = "bt新規作成";
            this.bt新規作成.Size = new System.Drawing.Size(106, 30);
            this.bt新規作成.TabIndex = 1;
            this.bt新規作成.Text = "新規作成";
            this.bt新規作成.UseVisualStyleBackColor = true;
            this.bt新規作成.Click += new System.EventHandler(this.bt新規作成_Click);
            // 
            // cb営業所
            // 
            this.cb営業所.FormattingEnabled = true;
            this.cb営業所.Location = new System.Drawing.Point(100, 89);
            this.cb営業所.Name = "cb営業所";
            this.cb営業所.Size = new System.Drawing.Size(86, 26);
            this.cb営業所.TabIndex = 8;
            this.cb営業所.SelectedIndexChanged += new System.EventHandler(this.cb営業所_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.5F);
            this.label2.Location = new System.Drawing.Point(49, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "営業所";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(1230, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "ver 3.3.0";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 9F);
            this.label7.Location = new System.Drawing.Point(158, 18);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.TabIndex = 26;
            this.label7.Text = "利用可能営業所";
            // 
            // cb部門
            // 
            this.cb部門.Font = new System.Drawing.Font("メイリオ", 9F);
            this.cb部門.FormattingEnabled = true;
            this.cb部門.Location = new System.Drawing.Point(255, 15);
            this.cb部門.Name = "cb部門";
            this.cb部門.Size = new System.Drawing.Size(138, 26);
            this.cb部門.TabIndex = 25;
            this.cb部門.SelectedIndexChanged += new System.EventHandler(this.cb部門_SelectedIndexChanged);
            // 
            // 編集btn
            // 
            this.編集btn.HeaderText = "-";
            this.編集btn.Name = "編集btn";
            this.編集btn.ReadOnly = true;
            this.編集btn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.編集btn.Text = "編集";
            this.編集btn.UseColumnTextForButtonValue = true;
            this.編集btn.Width = 50;
            // 
            // sid
            // 
            this.sid.DataPropertyName = "sid";
            this.sid.HeaderText = "sid";
            this.sid.Name = "sid";
            this.sid.ReadOnly = true;
            this.sid.Visible = false;
            // 
            // 削除FLG
            // 
            this.削除FLG.DataPropertyName = "削除FLG";
            this.削除FLG.HeaderText = "削";
            this.削除FLG.MinimumWidth = 2;
            this.削除FLG.Name = "削除FLG";
            this.削除FLG.ReadOnly = true;
            this.削除FLG.Width = 2;
            // 
            // 事故No
            // 
            this.事故No.DataPropertyName = "事故NO";
            this.事故No.HeaderText = "事故No";
            this.事故No.Name = "事故No";
            this.事故No.ReadOnly = true;
            this.事故No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.事故No.Width = 72;
            // 
            // 発生日
            // 
            this.発生日.DataPropertyName = "発生日";
            this.発生日.HeaderText = "発生日";
            this.発生日.Name = "発生日";
            this.発生日.ReadOnly = true;
            this.発生日.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.発生日.Width = 80;
            // 
            // 時間
            // 
            this.時間.DataPropertyName = "発生時間";
            this.時間.HeaderText = "時間";
            this.時間.Name = "時間";
            this.時間.ReadOnly = true;
            this.時間.Width = 55;
            // 
            // 営業所
            // 
            this.営業所.DataPropertyName = "営業所";
            this.営業所.HeaderText = "営業所";
            this.営業所.Name = "営業所";
            this.営業所.ReadOnly = true;
            this.営業所.Width = 75;
            // 
            // 乗務員名
            // 
            this.乗務員名.DataPropertyName = "乗務員名";
            this.乗務員名.HeaderText = "乗務員名";
            this.乗務員名.Name = "乗務員名";
            this.乗務員名.ReadOnly = true;
            this.乗務員名.Width = 80;
            // 
            // 車両コード
            // 
            this.車両コード.DataPropertyName = "車両コード";
            this.車両コード.HeaderText = "車両コード";
            this.車両コード.Name = "車両コード";
            this.車両コード.ReadOnly = true;
            this.車両コード.Visible = false;
            // 
            // 処理状況
            // 
            this.処理状況.DataPropertyName = "状態";
            this.処理状況.HeaderText = "処理状況";
            this.処理状況.Name = "処理状況";
            this.処理状況.ReadOnly = true;
            this.処理状況.Width = 80;
            // 
            // 区分
            // 
            this.区分.DataPropertyName = "事故区分";
            this.区分.HeaderText = "区分";
            this.区分.Name = "区分";
            this.区分.ReadOnly = true;
            this.区分.Width = 140;
            // 
            // 登録番号
            // 
            this.登録番号.DataPropertyName = "登録番号";
            this.登録番号.HeaderText = "登録番号";
            this.登録番号.Name = "登録番号";
            this.登録番号.ReadOnly = true;
            this.登録番号.Width = 110;
            // 
            // 事故回数
            // 
            this.事故回数.DataPropertyName = "事故回数";
            this.事故回数.HeaderText = "事故数";
            this.事故回数.Name = "事故回数";
            this.事故回数.ReadOnly = true;
            this.事故回数.Width = 80;
            // 
            // 荷主
            // 
            this.荷主.DataPropertyName = "荷主";
            this.荷主.HeaderText = "荷主";
            this.荷主.Name = "荷主";
            this.荷主.ReadOnly = true;
            this.荷主.Width = 280;
            // 
            // 便名
            // 
            this.便名.DataPropertyName = "便名";
            this.便名.HeaderText = "便名";
            this.便名.Name = "便名";
            this.便名.ReadOnly = true;
            this.便名.Width = 200;
            // 
            // 営業所CD
            // 
            this.営業所CD.DataPropertyName = "営業所CD";
            this.営業所CD.HeaderText = "営業所CD";
            this.営業所CD.Name = "営業所CD";
            this.営業所CD.ReadOnly = true;
            this.営業所CD.Visible = false;
            // 
            // 乗務員カナ
            // 
            this.乗務員カナ.HeaderText = "乗務員カナ";
            this.乗務員カナ.Name = "乗務員カナ";
            this.乗務員カナ.ReadOnly = true;
            this.乗務員カナ.Visible = false;
            // 
            // 乗務員CD
            // 
            this.乗務員CD.DataPropertyName = "乗務員CD";
            this.乗務員CD.HeaderText = "乗務員CD";
            this.乗務員CD.Name = "乗務員CD";
            this.乗務員CD.ReadOnly = true;
            this.乗務員CD.Visible = false;
            // 
            // 生年月日
            // 
            this.生年月日.DataPropertyName = "生年月日";
            this.生年月日.HeaderText = "生年月日";
            this.生年月日.Name = "生年月日";
            this.生年月日.ReadOnly = true;
            this.生年月日.Visible = false;
            // 
            // 入社年月日
            // 
            this.入社年月日.DataPropertyName = "入社年月日";
            this.入社年月日.HeaderText = "入社年月日";
            this.入社年月日.Name = "入社年月日";
            this.入社年月日.ReadOnly = true;
            this.入社年月日.Visible = false;
            // 
            // 環境
            // 
            this.環境.DataPropertyName = "環境";
            this.環境.HeaderText = "環境";
            this.環境.Name = "環境";
            this.環境.ReadOnly = true;
            this.環境.Visible = false;
            // 
            // 車両
            // 
            this.車両.DataPropertyName = "車両";
            this.車両.HeaderText = "車両";
            this.車両.Name = "車両";
            this.車両.ReadOnly = true;
            this.車両.Visible = false;
            // 
            // 荷物
            // 
            this.荷物.DataPropertyName = "荷物";
            this.荷物.HeaderText = "荷物";
            this.荷物.Name = "荷物";
            this.荷物.ReadOnly = true;
            this.荷物.Visible = false;
            // 
            // 品質
            // 
            this.品質.DataPropertyName = "品質";
            this.品質.HeaderText = "品質";
            this.品質.Name = "品質";
            this.品質.ReadOnly = true;
            this.品質.Visible = false;
            // 
            // 労災
            // 
            this.労災.DataPropertyName = "労災";
            this.労災.HeaderText = "労災";
            this.労災.Name = "労災";
            this.労災.ReadOnly = true;
            this.労災.Visible = false;
            // 
            // 貰い
            // 
            this.貰い.DataPropertyName = "貰い";
            this.貰い.HeaderText = "貰い";
            this.貰い.Name = "貰い";
            this.貰い.ReadOnly = true;
            this.貰い.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 615);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb部門);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb営業所);
            this.Controls.Add(this.bt新規作成);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgJikoList);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.LinkLabel2);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.lbTitle);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "メイン";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJikoList)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        internal System.Windows.Forms.LinkLabel LinkLabel2;
        internal System.Windows.Forms.LinkLabel LinkLabel1;
        private System.Windows.Forms.Label lbSYMD;
        private System.Windows.Forms.TextBox txFromYMD;
        private System.Windows.Forms.TextBox txToYMD;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.DataGridView dgJikoList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ck2;
        private System.Windows.Forms.CheckBox ck1;
        private System.Windows.Forms.Label lbDeiverKana;
        private System.Windows.Forms.TextBox txDriverKana;
        private System.Windows.Forms.StatusStrip statusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel sl接続先;
        internal System.Windows.Forms.ToolStripStatusLabel slSpacer;
        internal System.Windows.Forms.ToolStripStatusLabel slユーザ名;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox ck3;
        private System.Windows.Forms.CheckBox ck5;
        private System.Windows.Forms.CheckBox ck6;
        private System.Windows.Forms.ComboBox cbDriverName;
        private System.Windows.Forms.Button bt新規作成;
        private System.Windows.Forms.CheckBox ck4;
        private System.Windows.Forms.ComboBox cb営業所;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb部門;
        private System.Windows.Forms.DataGridViewButtonColumn 編集btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sid;
        private System.Windows.Forms.DataGridViewTextBoxColumn 削除FLG;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事故No;
        private System.Windows.Forms.DataGridViewTextBoxColumn 発生日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn 営業所;
        private System.Windows.Forms.DataGridViewTextBoxColumn 乗務員名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 車両コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 処理状況;
        private System.Windows.Forms.DataGridViewTextBoxColumn 区分;
        private System.Windows.Forms.DataGridViewTextBoxColumn 登録番号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 事故回数;
        private System.Windows.Forms.DataGridViewTextBoxColumn 荷主;
        private System.Windows.Forms.DataGridViewTextBoxColumn 便名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 営業所CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 乗務員カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 乗務員CD;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生年月日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 入社年月日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 環境;
        private System.Windows.Forms.DataGridViewTextBoxColumn 車両;
        private System.Windows.Forms.DataGridViewTextBoxColumn 荷物;
        private System.Windows.Forms.DataGridViewTextBoxColumn 品質;
        private System.Windows.Forms.DataGridViewTextBoxColumn 労災;
        private System.Windows.Forms.DataGridViewTextBoxColumn 貰い;
    }
}

