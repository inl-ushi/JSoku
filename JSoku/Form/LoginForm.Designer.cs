namespace JSoku
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LinkLabel2 = new System.Windows.Forms.LinkLabel();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lbPassword = new System.Windows.Forms.LinkLabel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btLogin = new System.Windows.Forms.Button();
            this.txPassword = new System.Windows.Forms.TextBox();
            this.txUserId = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinkLabel2
            // 
            this.LinkLabel2.AutoSize = true;
            this.LinkLabel2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LinkLabel2.Location = new System.Drawing.Point(425, 263);
            this.LinkLabel2.Name = "LinkLabel2";
            this.LinkLabel2.Size = new System.Drawing.Size(56, 18);
            this.LinkLabel2.TabIndex = 17;
            this.LinkLabel2.TabStop = true;
            this.LinkLabel2.Text = "更新履歴";
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LinkLabel1.Location = new System.Drawing.Point(389, 242);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(92, 18);
            this.LinkLabel1.TabIndex = 16;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = "操作マニュアル";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("メイリオ", 9F);
            this.lbPassword.Location = new System.Drawing.Point(389, 9);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(92, 18);
            this.lbPassword.TabIndex = 15;
            this.lbPassword.TabStop = true;
            this.lbPassword.Text = "パスワード変更";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMessage.ForeColor = System.Drawing.Color.SlateGray;
            this.lbMessage.Location = new System.Drawing.Point(4, 288);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(85, 17);
            this.lbMessage.TabIndex = 14;
            this.lbMessage.Text = "バージョン表記";
            // 
            // btLogin
            // 
            this.btLogin.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.btLogin.Location = new System.Drawing.Point(182, 180);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(118, 40);
            this.btLogin.TabIndex = 13;
            this.btLogin.Text = "ログイン";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // txPassword
            // 
            this.txPassword.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.txPassword.Location = new System.Drawing.Point(155, 124);
            this.txPassword.MaxLength = 20;
            this.txPassword.Name = "txPassword";
            this.txPassword.PasswordChar = '*';
            this.txPassword.Size = new System.Drawing.Size(241, 27);
            this.txPassword.TabIndex = 12;
            // 
            // txUserId
            // 
            this.txUserId.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.txUserId.Location = new System.Drawing.Point(155, 79);
            this.txUserId.MaxLength = 20;
            this.txUserId.Name = "txUserId";
            this.txUserId.Size = new System.Drawing.Size(241, 27);
            this.txUserId.TabIndex = 11;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.Label2.Location = new System.Drawing.Point(75, 127);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(74, 20);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "パスワード";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 9.75F);
            this.Label1.Location = new System.Drawing.Point(88, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 20);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "ユーザ名";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 312);
            this.Controls.Add(this.LinkLabel2);
            this.Controls.Add(this.LinkLabel1);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.txPassword);
            this.Controls.Add(this.txUserId);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "LoginForm";
            this.Text = "ログイン";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.LinkLabel LinkLabel2;
        internal System.Windows.Forms.LinkLabel LinkLabel1;
        internal System.Windows.Forms.LinkLabel lbPassword;
        internal System.Windows.Forms.Label lbMessage;
        internal System.Windows.Forms.Button btLogin;
        internal System.Windows.Forms.TextBox txPassword;
        internal System.Windows.Forms.TextBox txUserId;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
    }
}