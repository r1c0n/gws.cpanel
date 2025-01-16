using System.Windows.Forms;

namespace gws.cpanel
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Button btnStartServer;
        private Button btnStopServer;
        private TextBox txtServerLogs;
        private Label lblServerStatus;

        private TextBox txtPort;
        private Label lblPort;
        private TextBox txtDomain;
        private Label lblDomain;
        private TextBox txtStaticDir;
        private Label lblStaticDir;

        private CheckBox chkTlsEnabled;
        private TextBox txtCertFile;
        private Label lblCertFile;
        private TextBox txtKeyFile;
        private Label lblKeyFile;

        private CheckBox chkLoggingMiddleware;
        private CheckBox chkGzipMiddleware;

        private Button btnSaveConfig;
        private Button btnSelectWorkingDir;
        private TextBox txtWorkingDir;
        private Label lblWorkingDir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.txtServerLogs = new System.Windows.Forms.TextBox();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.txtStaticDir = new System.Windows.Forms.TextBox();
            this.lblStaticDir = new System.Windows.Forms.Label();
            this.chkTlsEnabled = new System.Windows.Forms.CheckBox();
            this.txtCertFile = new System.Windows.Forms.TextBox();
            this.lblCertFile = new System.Windows.Forms.Label();
            this.txtKeyFile = new System.Windows.Forms.TextBox();
            this.lblKeyFile = new System.Windows.Forms.Label();
            this.chkLoggingMiddleware = new System.Windows.Forms.CheckBox();
            this.chkGzipMiddleware = new System.Windows.Forms.CheckBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnSelectWorkingDir = new System.Windows.Forms.Button();
            this.txtWorkingDir = new System.Windows.Forms.TextBox();
            this.lblWorkingDir = new System.Windows.Forms.Label();
            this.chkDaemonMode = new System.Windows.Forms.CheckBox();
            this.lblFooter = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(50, 310);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 30);
            this.btnStartServer.TabIndex = 16;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(170, 310);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(100, 30);
            this.btnStopServer.TabIndex = 17;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.Click += new System.EventHandler(this.BtnStopServer_Click);
            // 
            // txtServerLogs
            // 
            this.txtServerLogs.Location = new System.Drawing.Point(50, 360);
            this.txtServerLogs.Multiline = true;
            this.txtServerLogs.Name = "txtServerLogs";
            this.txtServerLogs.ReadOnly = true;
            this.txtServerLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtServerLogs.Size = new System.Drawing.Size(700, 200);
            this.txtServerLogs.TabIndex = 19;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Location = new System.Drawing.Point(50, 580);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(200, 20);
            this.lblServerStatus.TabIndex = 20;
            this.lblServerStatus.Text = "Server Status: Stopped";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(120, 60);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 4;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(50, 60);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(50, 20);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(365, 60);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(115, 20);
            this.txtDomain.TabIndex = 6;
            // 
            // lblDomain
            // 
            this.lblDomain.Location = new System.Drawing.Point(250, 60);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(100, 20);
            this.lblDomain.TabIndex = 5;
            this.lblDomain.Text = "Domain:";
            // 
            // txtStaticDir
            // 
            this.txtStaticDir.Location = new System.Drawing.Point(200, 100);
            this.txtStaticDir.Name = "txtStaticDir";
            this.txtStaticDir.Size = new System.Drawing.Size(280, 20);
            this.txtStaticDir.TabIndex = 8;
            // 
            // lblStaticDir
            // 
            this.lblStaticDir.Location = new System.Drawing.Point(50, 100);
            this.lblStaticDir.Name = "lblStaticDir";
            this.lblStaticDir.Size = new System.Drawing.Size(150, 20);
            this.lblStaticDir.TabIndex = 7;
            this.lblStaticDir.Text = "Static Directory:";
            // 
            // chkTlsEnabled
            // 
            this.chkTlsEnabled.Location = new System.Drawing.Point(50, 140);
            this.chkTlsEnabled.Name = "chkTlsEnabled";
            this.chkTlsEnabled.Size = new System.Drawing.Size(150, 20);
            this.chkTlsEnabled.TabIndex = 9;
            this.chkTlsEnabled.Text = "Enable TLS";
            // 
            // txtCertFile
            // 
            this.txtCertFile.Location = new System.Drawing.Point(200, 170);
            this.txtCertFile.Name = "txtCertFile";
            this.txtCertFile.Size = new System.Drawing.Size(280, 20);
            this.txtCertFile.TabIndex = 11;
            // 
            // lblCertFile
            // 
            this.lblCertFile.Location = new System.Drawing.Point(50, 170);
            this.lblCertFile.Name = "lblCertFile";
            this.lblCertFile.Size = new System.Drawing.Size(150, 20);
            this.lblCertFile.TabIndex = 10;
            this.lblCertFile.Text = "TLS Certificate File:";
            // 
            // txtKeyFile
            // 
            this.txtKeyFile.Location = new System.Drawing.Point(200, 200);
            this.txtKeyFile.Name = "txtKeyFile";
            this.txtKeyFile.Size = new System.Drawing.Size(280, 20);
            this.txtKeyFile.TabIndex = 13;
            // 
            // lblKeyFile
            // 
            this.lblKeyFile.Location = new System.Drawing.Point(50, 200);
            this.lblKeyFile.Name = "lblKeyFile";
            this.lblKeyFile.Size = new System.Drawing.Size(150, 20);
            this.lblKeyFile.TabIndex = 12;
            this.lblKeyFile.Text = "TLS Key File:";
            // 
            // chkLoggingMiddleware
            // 
            this.chkLoggingMiddleware.Location = new System.Drawing.Point(50, 240);
            this.chkLoggingMiddleware.Name = "chkLoggingMiddleware";
            this.chkLoggingMiddleware.Size = new System.Drawing.Size(200, 20);
            this.chkLoggingMiddleware.TabIndex = 14;
            this.chkLoggingMiddleware.Text = "Enable Logging Middleware";
            // 
            // chkGzipMiddleware
            // 
            this.chkGzipMiddleware.Location = new System.Drawing.Point(50, 270);
            this.chkGzipMiddleware.Name = "chkGzipMiddleware";
            this.chkGzipMiddleware.Size = new System.Drawing.Size(200, 20);
            this.chkGzipMiddleware.TabIndex = 15;
            this.chkGzipMiddleware.Text = "Enable GZIP Middleware";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(620, 310);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(100, 30);
            this.btnSaveConfig.TabIndex = 18;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.Click += new System.EventHandler(this.BtnSaveConfig_Click);
            // 
            // btnSelectWorkingDir
            // 
            this.btnSelectWorkingDir.Location = new System.Drawing.Point(620, 20);
            this.btnSelectWorkingDir.Name = "btnSelectWorkingDir";
            this.btnSelectWorkingDir.Size = new System.Drawing.Size(100, 25);
            this.btnSelectWorkingDir.TabIndex = 2;
            this.btnSelectWorkingDir.Text = "Browse";
            this.btnSelectWorkingDir.Click += new System.EventHandler(this.BtnSelectWorkingDir_Click);
            // 
            // txtWorkingDir
            // 
            this.txtWorkingDir.Location = new System.Drawing.Point(200, 20);
            this.txtWorkingDir.Name = "txtWorkingDir";
            this.txtWorkingDir.Size = new System.Drawing.Size(400, 20);
            this.txtWorkingDir.TabIndex = 1;
            // 
            // lblWorkingDir
            // 
            this.lblWorkingDir.Location = new System.Drawing.Point(50, 20);
            this.lblWorkingDir.Name = "lblWorkingDir";
            this.lblWorkingDir.Size = new System.Drawing.Size(150, 20);
            this.lblWorkingDir.TabIndex = 0;
            this.lblWorkingDir.Text = "Working Directory:";
            // 
            // chkDaemonMode
            // 
            this.chkDaemonMode.AutoSize = true;
            this.chkDaemonMode.Location = new System.Drawing.Point(276, 318);
            this.chkDaemonMode.Name = "chkDaemonMode";
            this.chkDaemonMode.Size = new System.Drawing.Size(70, 17);
            this.chkDaemonMode.TabIndex = 21;
            this.chkDaemonMode.Text = "Headless";
            this.chkDaemonMode.UseVisualStyleBackColor = true;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.LinkArea = new System.Windows.Forms.LinkArea(41, 12);
            this.lblFooter.Location = new System.Drawing.Point(365, 583);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(436, 17);
            this.lblFooter.TabIndex = 23;
            this.lblFooter.TabStop = true;
            this.lblFooter.Text = "Copyright (c) 2022 - 2025 Gamma Team and Contributors | GWS Control Panel v1.0.0";
            this.lblFooter.UseCompatibleTextRendering = true;
            this.lblFooter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblFooter_LinkClicked);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblFooter);
            this.Controls.Add(this.chkDaemonMode);
            this.Controls.Add(this.lblWorkingDir);
            this.Controls.Add(this.txtWorkingDir);
            this.Controls.Add(this.btnSelectWorkingDir);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.lblStaticDir);
            this.Controls.Add(this.txtStaticDir);
            this.Controls.Add(this.chkTlsEnabled);
            this.Controls.Add(this.lblCertFile);
            this.Controls.Add(this.txtCertFile);
            this.Controls.Add(this.lblKeyFile);
            this.Controls.Add(this.txtKeyFile);
            this.Controls.Add(this.chkLoggingMiddleware);
            this.Controls.Add(this.chkGzipMiddleware);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.txtServerLogs);
            this.Controls.Add(this.lblServerStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gamma Web Server Control Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CheckBox chkDaemonMode;
        private LinkLabel lblFooter;
    }
}
