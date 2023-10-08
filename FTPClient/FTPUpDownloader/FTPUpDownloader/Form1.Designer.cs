namespace FTPClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tbxServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.tbxloginmessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btndownload = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.lstbxFtpResources = new System.Windows.Forms.ListBox();
            this.lstbxFtpState = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkbxAnonymous = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(731, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP 服务器地址：";
            // 
            // tbxServerIp
            // 
            this.tbxServerIp.Location = new System.Drawing.Point(869, 157);
            this.tbxServerIp.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxServerIp.Name = "tbxServerIp";
            this.tbxServerIp.Size = new System.Drawing.Size(273, 35);
            this.tbxServerIp.TabIndex = 1;
            this.tbxServerIp.TextChanged += new System.EventHandler(this.tbxServerIp_TextChanged);
            this.tbxServerIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxServerIp_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(731, 222);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户名：";
            // 
            // tbxUsername
            // 
            this.tbxUsername.Location = new System.Drawing.Point(869, 260);
            this.tbxUsername.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxUsername.Name = "tbxUsername";
            this.tbxUsername.Size = new System.Drawing.Size(162, 35);
            this.tbxUsername.TabIndex = 3;
            this.tbxUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxUsername_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(731, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "输入密码：";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(869, 361);
            this.tbxPassword.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.Size = new System.Drawing.Size(285, 35);
            this.tbxPassword.TabIndex = 5;
            this.tbxPassword.TextChanged += new System.EventHandler(this.tbxPassword_TextChanged);
            this.tbxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxPassword_KeyPress);
            // 
            // btnlogin
            // 
            this.btnlogin.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnlogin.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnlogin.Location = new System.Drawing.Point(732, 412);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(125, 64);
            this.btnlogin.TabIndex = 6;
            this.btnlogin.Text = "登录";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // tbxloginmessage
            // 
            this.tbxloginmessage.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tbxloginmessage.Location = new System.Drawing.Point(869, 432);
            this.tbxloginmessage.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxloginmessage.Name = "tbxloginmessage";
            this.tbxloginmessage.Size = new System.Drawing.Size(285, 35);
            this.tbxloginmessage.TabIndex = 8;
            this.tbxloginmessage.TextChanged += new System.EventHandler(this.tbxloginmessage_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btndownload);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.lstbxFtpResources);
            this.groupBox1.Font = new System.Drawing.Font("楷体", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(34, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.groupBox1.Size = new System.Drawing.Size(685, 520);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 文件列表：";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(464, 360);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(193, 66);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btndownload
            // 
            this.btndownload.Location = new System.Drawing.Point(464, 224);
            this.btndownload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(193, 71);
            this.btndownload.TabIndex = 2;
            this.btndownload.Text = "下载";
            this.btndownload.UseVisualStyleBackColor = true;
            this.btndownload.Click += new System.EventHandler(this.btndownload_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(464, 85);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(193, 70);
            this.btnUpload.TabIndex = 1;
            this.btnUpload.Text = "上传";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // lstbxFtpResources
            // 
            this.lstbxFtpResources.FormattingEnabled = true;
            this.lstbxFtpResources.ItemHeight = 27;
            this.lstbxFtpResources.Location = new System.Drawing.Point(40, 41);
            this.lstbxFtpResources.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstbxFtpResources.Name = "lstbxFtpResources";
            this.lstbxFtpResources.Size = new System.Drawing.Size(387, 463);
            this.lstbxFtpResources.TabIndex = 0;
            this.lstbxFtpResources.DoubleClick += new System.EventHandler(this.lstbxFtpResources_DoubleClick);
            // 
            // lstbxFtpState
            // 
            this.lstbxFtpState.FormattingEnabled = true;
            this.lstbxFtpState.ItemHeight = 24;
            this.lstbxFtpState.Location = new System.Drawing.Point(34, 558);
            this.lstbxFtpState.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstbxFtpState.Name = "lstbxFtpState";
            this.lstbxFtpState.Size = new System.Drawing.Size(1165, 148);
            this.lstbxFtpState.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(1018, 512);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "状态： ";
            // 
            // chkbxAnonymous
            // 
            this.chkbxAnonymous.AutoSize = true;
            this.chkbxAnonymous.Font = new System.Drawing.Font("楷体", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkbxAnonymous.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkbxAnonymous.Location = new System.Drawing.Point(1054, 264);
            this.chkbxAnonymous.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.chkbxAnonymous.Name = "chkbxAnonymous";
            this.chkbxAnonymous.Size = new System.Drawing.Size(160, 31);
            this.chkbxAnonymous.TabIndex = 12;
            this.chkbxAnonymous.Text = "匿名用户";
            this.chkbxAnonymous.UseVisualStyleBackColor = true;
            this.chkbxAnonymous.Click += new System.EventHandler(this.chkbxAnonymous_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 740);
            this.Controls.Add(this.chkbxAnonymous);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstbxFtpState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbxloginmessage);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxServerIp);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "FTP客户端";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox tbxloginmessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btndownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListBox lstbxFtpResources;
        private System.Windows.Forms.ListBox lstbxFtpState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkbxAnonymous;
    }
}

