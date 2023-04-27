namespace VisionsWRMemo
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.txtSite = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnDownloadTemplate = new System.Windows.Forms.Button();
            this.btnUploadToVisions = new System.Windows.Forms.Button();
            this.lblSelectedFiles = new System.Windows.Forms.Label();
            this.btnSelectFileForImport = new System.Windows.Forms.Button();
            this.pnlVisionsUpload = new System.Windows.Forms.Panel();
            this.pbUpload = new System.Windows.Forms.ProgressBar();
            this.linkTemplateFilePath = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblSupport = new System.Windows.Forms.LinkLabel();
            this.gbLogin.SuspendLayout();
            this.pnlVisionsUpload.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(29, 74);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(172, 41);
            this.lblUserName.TabIndex = 100;
            this.lblUserName.Text = "User Name";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(29, 159);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(150, 41);
            this.lblPassword.TabIndex = 99;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(483, 74);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(400, 47);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(483, 153);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(400, 47);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.lblSite);
            this.gbLogin.Controls.Add(this.txtSite);
            this.gbLogin.Controls.Add(this.lblServer);
            this.gbLogin.Controls.Add(this.txtServer);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.lblPassword);
            this.gbLogin.Controls.Add(this.txtPassword);
            this.gbLogin.Controls.Add(this.lblUserName);
            this.gbLogin.Controls.Add(this.txtUserName);
            this.gbLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbLogin.Location = new System.Drawing.Point(34, 27);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gbLogin.Size = new System.Drawing.Size(930, 508);
            this.gbLogin.TabIndex = 4;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Login";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSite.Location = new System.Drawing.Point(32, 317);
            this.lblSite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(72, 41);
            this.lblSite.TabIndex = 96;
            this.lblSite.Text = "Site";
            // 
            // txtSite
            // 
            this.txtSite.Location = new System.Drawing.Point(486, 312);
            this.txtSite.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSite.Name = "txtSite";
            this.txtSite.Size = new System.Drawing.Size(400, 47);
            this.txtSite.TabIndex = 4;
            this.txtSite.TextChanged += new System.EventHandler(this.txtSite_TextChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblServer.Location = new System.Drawing.Point(29, 241);
            this.lblServer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(108, 41);
            this.lblServer.TabIndex = 97;
            this.lblServer.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(483, 235);
            this.txtServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(400, 47);
            this.txtServer.TabIndex = 3;
            this.txtServer.TextChanged += new System.EventHandler(this.txtServer_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(29, 385);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(855, 90);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDownloadTemplate
            // 
            this.btnDownloadTemplate.Location = new System.Drawing.Point(29, 74);
            this.btnDownloadTemplate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDownloadTemplate.Name = "btnDownloadTemplate";
            this.btnDownloadTemplate.Size = new System.Drawing.Size(838, 90);
            this.btnDownloadTemplate.TabIndex = 6;
            this.btnDownloadTemplate.Text = "Download Template";
            this.btnDownloadTemplate.UseVisualStyleBackColor = true;
            this.btnDownloadTemplate.Click += new System.EventHandler(this.btnDownloadTemplate_Click);
            // 
            // btnUploadToVisions
            // 
            this.btnUploadToVisions.Location = new System.Drawing.Point(32, 599);
            this.btnUploadToVisions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnUploadToVisions.Name = "btnUploadToVisions";
            this.btnUploadToVisions.Size = new System.Drawing.Size(838, 90);
            this.btnUploadToVisions.TabIndex = 9;
            this.btnUploadToVisions.Text = "Upload To Visions";
            this.btnUploadToVisions.UseVisualStyleBackColor = true;
            this.btnUploadToVisions.Click += new System.EventHandler(this.btnUploadToVisions_Click);
            // 
            // lblSelectedFiles
            // 
            this.lblSelectedFiles.AutoSize = true;
            this.lblSelectedFiles.Location = new System.Drawing.Point(32, 380);
            this.lblSelectedFiles.Margin = new System.Windows.Forms.Padding(2, 0, 2, 50);
            this.lblSelectedFiles.MaximumSize = new System.Drawing.Size(1000, 0);
            this.lblSelectedFiles.Name = "lblSelectedFiles";
            this.lblSelectedFiles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblSelectedFiles.Size = new System.Drawing.Size(184, 51);
            this.lblSelectedFiles.TabIndex = 93;
            this.lblSelectedFiles.Text = "Selected File";
            this.lblSelectedFiles.Click += new System.EventHandler(this.lblSelectedFiles_Click);
            // 
            // btnSelectFileForImport
            // 
            this.btnSelectFileForImport.Location = new System.Drawing.Point(29, 482);
            this.btnSelectFileForImport.Margin = new System.Windows.Forms.Padding(2, 10, 2, 3);
            this.btnSelectFileForImport.Name = "btnSelectFileForImport";
            this.btnSelectFileForImport.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnSelectFileForImport.Size = new System.Drawing.Size(838, 90);
            this.btnSelectFileForImport.TabIndex = 8;
            this.btnSelectFileForImport.Text = "Select File For Import";
            this.btnSelectFileForImport.UseVisualStyleBackColor = true;
            this.btnSelectFileForImport.Click += new System.EventHandler(this.btnSelectFileForImport_Click);
            // 
            // pnlVisionsUpload
            // 
            this.pnlVisionsUpload.Controls.Add(this.pbUpload);
            this.pnlVisionsUpload.Controls.Add(this.linkTemplateFilePath);
            this.pnlVisionsUpload.Controls.Add(this.label2);
            this.pnlVisionsUpload.Controls.Add(this.label1);
            this.pnlVisionsUpload.Controls.Add(this.btnDownloadTemplate);
            this.pnlVisionsUpload.Controls.Add(this.btnSelectFileForImport);
            this.pnlVisionsUpload.Controls.Add(this.btnUploadToVisions);
            this.pnlVisionsUpload.Controls.Add(this.lblSelectedFiles);
            this.pnlVisionsUpload.Location = new System.Drawing.Point(29, 27);
            this.pnlVisionsUpload.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnlVisionsUpload.Name = "pnlVisionsUpload";
            this.pnlVisionsUpload.Size = new System.Drawing.Size(930, 825);
            this.pnlVisionsUpload.TabIndex = 9;
            this.pnlVisionsUpload.Visible = false;
            this.pnlVisionsUpload.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVisionsUpload_Paint);
            // 
            // pbUpload
            // 
            this.pbUpload.Location = new System.Drawing.Point(34, 719);
            this.pbUpload.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.pbUpload.Name = "pbUpload";
            this.pbUpload.Size = new System.Drawing.Size(835, 63);
            this.pbUpload.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbUpload.TabIndex = 96;
            this.pbUpload.Visible = false;
            // 
            // linkTemplateFilePath
            // 
            this.linkTemplateFilePath.AutoSize = true;
            this.linkTemplateFilePath.Location = new System.Drawing.Point(211, 183);
            this.linkTemplateFilePath.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.linkTemplateFilePath.Name = "linkTemplateFilePath";
            this.linkTemplateFilePath.Size = new System.Drawing.Size(92, 47);
            this.linkTemplateFilePath.TabIndex = 7;
            this.linkTemplateFilePath.TabStop = true;
            this.linkTemplateFilePath.Text = "sdfsdf";
            this.linkTemplateFilePath.UseCompatibleTextRendering = true;
            this.linkTemplateFilePath.Visible = false;
            this.linkTemplateFilePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTemplateFilePath_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 41);
            this.label2.TabIndex = 95;
            this.label2.Text = "File Path:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 282);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(930, 11);
            this.label1.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblSupport
            // 
            this.lblSupport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSupport.AutoSize = true;
            this.lblSupport.Location = new System.Drawing.Point(731, 886);
            this.lblSupport.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(236, 41);
            this.lblSupport.TabIndex = 10;
            this.lblSupport.TabStop = true;
            this.lblSupport.Text = "Contact Support";
            this.lblSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblSupport_LinkClicked);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 951);
            this.Controls.Add(this.lblSupport);
            this.Controls.Add(this.pnlVisionsUpload);
            this.Controls.Add(this.gbLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visions Work Memo";
            this.Load += new System.EventHandler(this.Home_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.pnlVisionsUpload.ResumeLayout(false);
            this.pnlVisionsUpload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblUserName;
        private Label lblPassword;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private GroupBox gbLogin;
        private Button btnDownloadTemplate;
        private Button btnUploadToVisions;
        private Label lblSelectedFiles;
        private Button btnSelectFileForImport;
        private Panel pnlVisionsUpload;
        private Button btnLogin;
        private Label label1;
        private Label lblSite;
        private TextBox txtSite;
        private Label lblServer;
        private TextBox txtServer;
        private Label label2;
        private LinkLabel linkTemplateFilePath;
        private OpenFileDialog openFileDialog1;
        private ProgressBar pbUpload;
        private LinkLabel lblSupport;
    }
}