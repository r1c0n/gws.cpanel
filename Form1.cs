using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Timers;
using WK.Libraries.BetterFolderBrowserNS;
using System.Linq;

namespace gws.cpanel
{
    public partial class Form1 : Form
    {
        private string workingDirectory = "";
        private string logFilePath = "";
        private System.Timers.Timer logTimer;
        private const string configFileName = "cpanel.json";
        private Process serverProcess;

        public Form1()
        {
            InitializeComponent();
            LoadWorkingDirectory();
            InitializeLogTimer();
            UpdateFooterLabel();
        }

        private void LoadWorkingDirectory()
        {
            string configPath = Path.Combine(Environment.CurrentDirectory, configFileName); // Path to cpanel.json

            if (File.Exists(configPath))
            {
                // Load the working directory from cpanel.json
                string json = File.ReadAllText(configPath);
                dynamic config = JsonConvert.DeserializeObject(json);
                workingDirectory = config.working_directory;
                txtWorkingDir.Text = workingDirectory; // Update UI with loaded directory

                // Load the configuration
                string configFilePath = Path.Combine(workingDirectory, "config.json");
                if (File.Exists(configFilePath))
                {
                    LoadConfig(configFilePath);
                    Log("Configuration loaded from: " + configFilePath);
                }
                else
                {
                    Log("No configuration file found in the selected directory.");
                }

                // Set log file path
                logFilePath = Path.Combine(workingDirectory, "logs", "realtimelogs.log");
                ReadLogFile(null, null); // Initial read of the log file
                StartLogTimer(); // Start monitoring the log file
            }
            else
            {
                // If cpanel.json doesn't exist, create it with an empty working directory
                CreateDefaultConfig(configPath);
            }
        }

        private void CreateDefaultConfig(string configPath)
        {
            var defaultConfig = new
            {
                working_directory = string.Empty
            };

            string json = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);
            File.WriteAllText(configPath, json);
        }

        private void InitializeLogTimer()
        {
            logTimer = new System.Timers.Timer(1000); // Check logs every second
            logTimer.Elapsed += LogTimerElapsed;
            logTimer.AutoReset = true;
        }

        private void StartLogTimer()
        {
            if (logTimer != null && !logTimer.Enabled) // Check if timer is initialized and not running
            {
                logTimer.Start(); // Start monitoring the log file
            }
        }

        private void BtnSelectWorkingDir_Click(object sender, EventArgs e)
        {
            var betterFolderBrowser = new BetterFolderBrowser
            {
                Title = "Select Working Directory",
                Multiselect = false // Set to true if you want to allow multi-selection
            };

            if (betterFolderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                workingDirectory = betterFolderBrowser.SelectedFolder; // Get the selected folder
                txtWorkingDir.Text = workingDirectory;

                // Save the selected working directory to cpanel.json
                SaveWorkingDirectory();

                // Load the configuration
                string configFilePath = Path.Combine(workingDirectory, "config.json");
                if (File.Exists(configFilePath))
                {
                    LoadConfig(configFilePath);
                    Log("Configuration loaded from: " + configFilePath);
                }
                else
                {
                    Log("No configuration file found in the selected directory.");
                }

                // Set log file path
                logFilePath = Path.Combine(workingDirectory, "logs", "realtimelogs.log");
                ReadLogFile(null, null); // Initial read of the log file
                logTimer.Start(); // Start monitoring the log file
            }
        }

        private void SaveWorkingDirectory()
        {
            string configPath = Path.Combine(Environment.CurrentDirectory, configFileName); // Path to cpanel.json

            var config = new
            {
                working_directory = workingDirectory
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configPath, json);
            Log($"Working directory saved to: {configPath}");
        }

        private void LoadConfig(string configPath)
        {
            string json = File.ReadAllText(configPath);
            dynamic config = JsonConvert.DeserializeObject(json);

            txtPort.Text = config.port;
            txtDomain.Text = config.domain;
            txtStaticDir.Text = config.static_dir;

            chkTlsEnabled.Checked = config.tls_config.enabled;
            txtCertFile.Text = config.tls_config.cert_file;
            txtKeyFile.Text = config.tls_config.key_file;

            chkLoggingMiddleware.Checked = config.middleware.logging_middleware_enabled;
            chkGzipMiddleware.Checked = config.middleware.gzip_middleware_enabled;
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                MessageBox.Show("Please select a working directory first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate inputs
            if (!ValidateInputs())
            {
                return;
            }

            // Save the configuration
            var config = new
            {
                port = txtPort.Text,
                domain = txtDomain.Text,
                static_dir = txtStaticDir.Text,
                tls_config = new
                {
                    enabled = chkTlsEnabled.Checked,
                    cert_file = txtCertFile.Text,
                    key_file = txtKeyFile.Text
                },
                middleware = new
                {
                    logging_middleware_enabled = chkLoggingMiddleware.Checked,
                    gzip_middleware_enabled = chkGzipMiddleware.Checked
                }
            };

            string json = JsonConvert.SerializeObject(config, Formatting.Indented);
            string configPath = Path.Combine(workingDirectory, "config.json");
            File.WriteAllText(configPath, json);

            Log("Configuration saved to: " + configPath);
        }

        private bool ValidateInputs()
        {
            // Validate port number
            if (string.IsNullOrWhiteSpace(txtPort.Text) || !txtPort.Text.StartsWith(":"))
            {
                MessageBox.Show("The port number must start with a colon (:).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Extract the number part after the colon
            string portText = txtPort.Text.TrimStart(':');

            // Check if the number is valid
            if (!int.TryParse(portText, out int port) || port <= 0 || port > 65535)
            {
                MessageBox.Show("Please enter a valid port number (1-65535) after the colon (:).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate domain
            if (string.IsNullOrWhiteSpace(txtDomain.Text))
            {
                MessageBox.Show("Domain cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate static directory
            if (string.IsNullOrWhiteSpace(txtStaticDir.Text))
            {
                MessageBox.Show("Static directory cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check for TLS files if TLS is enabled
            if (chkTlsEnabled.Checked)
            {
                string certFilePath = Path.Combine(workingDirectory, txtCertFile.Text);
                string keyFilePath = Path.Combine(workingDirectory, txtKeyFile.Text);

                if (!File.Exists(certFilePath))
                {
                    MessageBox.Show($"TLS Certificate file does not exist: {certFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!File.Exists(keyFilePath))
                {
                    MessageBox.Show($"TLS Key file does not exist: {keyFilePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void BtnStartServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                MessageBox.Show("Please select a working directory before starting the server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StartServer();
        }

        private void BtnStopServer_Click(object sender, EventArgs e)
        {
            StopServer();
        }

        private void BtnRestartServer_Click(object sender, EventArgs e)
        {
            RestartServer();
        }

        private void StartServer()
        {
            string exeName = chkDaemonMode.Checked ? "gwsvc.exe" : "gws.exe";
            string exePath = Path.Combine(workingDirectory, exeName);

            if (!File.Exists(exePath))
            {
                MessageBox.Show($"Executable not found: {exePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                serverProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true, // Run as a standalone process
                        WorkingDirectory = workingDirectory
                    },
                    EnableRaisingEvents = true // Allow process events to be raised
                };

                serverProcess.Exited += ServerProcess_Exited; // Attach the Exited event handler
                serverProcess.Start(); // Start the process

                Log($"{exeName} started. PID: {serverProcess.Id}");
                CheckServerStatus(); // Update server status
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ServerProcess_Exited(object sender, EventArgs e)
        {
            // This event is raised on a worker thread, so invoke UI updates
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    Log("Server process exited.");
                    CheckServerStatus(); // Update the status to "Stopped"
                }));
            }
            else
            {
                Log("Server process exited.");
                CheckServerStatus(); // Update the status to "Stopped"
            }
        }

        private void StopServer()
        {
            if (serverProcess != null && !serverProcess.HasExited)
            {
                try
                {
                    serverProcess.Kill(); // Terminate the server process
                    serverProcess.WaitForExit(); // Ensure it has exited
                    serverProcess.Exited -= ServerProcess_Exited; // Detach the Exited event
                    serverProcess.Dispose(); // Clean up the process object
                    serverProcess = null; // Clear the reference
                    Log("Server stopped.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error stopping the server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Log("Server is not running.");
            }

            CheckServerStatus();
        }

        private void RestartServer()
        {
            StopServer();
            StartServer();
        }

        private void LogTimerElapsed(object sender, ElapsedEventArgs e)
        {
            ReadLogFile(null, null); // Read logs
            if (InvokeRequired)
            {
                Invoke(new Action(CheckServerStatus)); // Update UI safely
            }
            else
            {
                CheckServerStatus();
            }
        }

        private void CheckServerStatus()
        {
            string exeName = chkDaemonMode.Checked ? "gwsvc" : "gws"; // Process names without .exe
            var processes = Process.GetProcessesByName(exeName);

            if (serverProcess != null && !serverProcess.HasExited)
            {
                var process = processes.First(); // Get the first process
                lblServerStatus.Text = $"Server Status: Running (PID: {process.Id})";
            }
            else
            {
                lblServerStatus.Text = "Server Status: Stopped";
            }
        }


        private void ReadLogFile(object sender, ElapsedEventArgs e)
        {
            if (File.Exists(logFilePath))
            {
                // Read the log file and display its content
                string logContent = File.ReadAllText(logFilePath);

                // Check if the control's handle is created before updating
                if (IsHandleCreated)
                {
                    // Update the server logs textbox safely on the UI thread
                    Invoke(new Action(() =>
                    {
                        txtServerLogs.Text = logContent;
                    }));
                }
            }
        }

        private void Log(string message)
        {
            txtServerLogs.AppendText($"{DateTime.Now}: {message}\r\n");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopServer();

            if (logTimer != null)
            {
                logTimer.Stop();
                logTimer.Dispose();
            }
        }

        private void UpdateFooterLabel()
        {
            int currentYear = DateTime.Now.Year;
            lblFooter.Text = $"Copyright (c) 2022 - {currentYear} Gamma Team and Contributors | GWS Control Panel v1.0.0";
        }

        private void lblFooter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/r1c0n/gws");
        }
    }
}
