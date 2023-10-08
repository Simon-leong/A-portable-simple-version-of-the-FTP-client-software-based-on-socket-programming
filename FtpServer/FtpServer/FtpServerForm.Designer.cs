namespace FtpServer
{
    partial class FtpServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FtpServer));
            this.lstboxStatus = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFtpServerIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxFtpServerPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFtpRoot = new System.Windows.Forms.TextBox();
            this.btnFtpServerStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstboxStatus
            // 
            this.lstboxStatus.BackColor = System.Drawing.SystemColors.Window;
            this.lstboxStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstboxStatus.FormattingEnabled = true;
            this.lstboxStatus.ItemHeight = 24;
            this.lstboxStatus.Location = new System.Drawing.Point(31, 147);
            this.lstboxStatus.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lstboxStatus.Name = "lstboxStatus";
            this.lstboxStatus.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstboxStatus.Size = new System.Drawing.Size(1177, 556);
            this.lstboxStatus.TabIndex = 0;
            this.lstboxStatus.SelectedIndexChanged += new System.EventHandler(this.lstboxStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器地址：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbxFtpServerIp
            // 
            this.tbxFtpServerIp.Location = new System.Drawing.Point(85, 75);
            this.tbxFtpServerIp.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxFtpServerIp.Name = "tbxFtpServerIp";
            this.tbxFtpServerIp.Size = new System.Drawing.Size(206, 35);
            this.tbxFtpServerIp.TabIndex = 2;
            this.tbxFtpServerIp.TextChanged += new System.EventHandler(this.tbxFtpServerIp_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(318, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口号：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tbxFtpServerPort
            // 
            this.tbxFtpServerPort.Location = new System.Drawing.Point(388, 75);
            this.tbxFtpServerPort.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxFtpServerPort.Name = "tbxFtpServerPort";
            this.tbxFtpServerPort.Size = new System.Drawing.Size(184, 35);
            this.tbxFtpServerPort.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(609, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "本地目录:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbxFtpRoot
            // 
            this.tbxFtpRoot.Location = new System.Drawing.Point(681, 75);
            this.tbxFtpRoot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxFtpRoot.Name = "tbxFtpRoot";
            this.tbxFtpRoot.Size = new System.Drawing.Size(274, 35);
            this.tbxFtpRoot.TabIndex = 6;
            this.tbxFtpRoot.TextChanged += new System.EventHandler(this.tbxFtpRoot_TextChanged);
            // 
            // btnFtpServerStartStop
            // 
            this.btnFtpServerStartStop.Font = new System.Drawing.Font("楷体", 13F, System.Drawing.FontStyle.Bold);
            this.btnFtpServerStartStop.Location = new System.Drawing.Point(1019, 48);
            this.btnFtpServerStartStop.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnFtpServerStartStop.Name = "btnFtpServerStartStop";
            this.btnFtpServerStartStop.Size = new System.Drawing.Size(153, 77);
            this.btnFtpServerStartStop.TabIndex = 7;
            this.btnFtpServerStartStop.Text = "开始";
            this.btnFtpServerStartStop.UseVisualStyleBackColor = true;
            this.btnFtpServerStartStop.Click += new System.EventHandler(this.btnFtpServerStartStop_Click);
            // 
            // FtpServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 740);
            this.Controls.Add(this.btnFtpServerStartStop);
            this.Controls.Add(this.tbxFtpRoot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxFtpServerPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxFtpServerIp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstboxStatus);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "FtpServer";
            this.Text = "Ftp服务器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstboxStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxFtpServerIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxFtpServerPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxFtpRoot;
        private System.Windows.Forms.Button btnFtpServerStartStop;
    }
}

