using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using SharpConfig;
using System.Threading;

namespace FTPUploader
{
    public partial class MainForm : Form
    {
        private Config config = new Config();
        private FTPUpload ftp = null;

        private List<string> listFile = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        //
        // Form Event
        //

        // Load config from default file.
        private void MainForm_Load(object sender, EventArgs e)
        {
            // If default file exists, load directly
            if (File.Exists("Uploader.cfg"))
            {
                ConfigLoad();
            }
            // Or open Config Form to set config file
            else
            {
                MessageBox.Show("Cannot find config file.");
                ConfigFormOpen();
                if (File.Exists("Uploader.cfg"))
                {
                    ConfigLoad();
                }
                else
                {
                    // Config file set failed, close the form
                    this.Close();
                }
            }
        }

        // Menu Strip
        // Start Upload
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new thread to upload files
            Thread ftpUploadThread = new Thread(new ThreadStart(StartUpload));
            ftpUploadThread.Start();
        }

        // Open Config Form
        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigFormOpen();
        }

        // Prevent users to resize the form.
        private void MainForm_Resize(object sender, EventArgs e)
        {
            fileList.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - 24);
        }

        //
        // Method
        //

        // Go through files in directory and show them in the listview.
        // (Name Type LastWriteTime Size)
        private void GetFileList(DirectoryInfo diroot)
        {
            foreach (FileInfo file in diroot.GetFiles())
            {
                listFile.Add(file.FullName);
                ListViewItem item = new ListViewItem(file.Name, 0);
                item.SubItems.Add(file.Extension);
                item.SubItems.Add(file.LastWriteTime.ToShortDateString());
                if (file.Length / 8.0 / 1024 < 1024)
                {
                    item.SubItems.Add((file.Length / 8 / 1024).ToString() + "KB");
                }
                else if (file.Length / 8.0 / 1024 > 1024 && file.Length / 8.0 / 1024 / 1024 < 1024)
                {
                    item.SubItems.Add((file.Length / 8.0 / 1024 / 1024).ToString("N2") + " MB");
                }
                else if (file.Length / 8.0 / 1024 / 1024 > 1024 && file.Length / 8.0 / 1024 / 1024 / 1024 < 1024)
                {
                    item.SubItems.Add((file.Length / 8.0 / 1024 / 1024 / 1024).ToString("N2") + " GB");
                }
                item.SubItems.Add("");
                fileList.Items.Add(item);
            }

            foreach (DirectoryInfo dirSub in diroot.GetDirectories())
            {
                GetFileList(dirSub);
            }
        }

        // Load config from default file.
        private void ConfigLoad()
        {
            // Load config from default file
            config.LoadFromConfig();

            // Refresh the listView
            listFile.Clear();
            fileList.Items.Clear();
            // Go through files in directory and show them in the listview
            DirectoryInfo dir = new DirectoryInfo(config.localPath);
            GetFileList(dir);
        }

        // Open config form
        private void ConfigFormOpen()
        {
            ConfigForm configForm = new ConfigForm();

            while (true)
            {
                // Show a login form to verify user's permission
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    // Verify complete, Open Config Form
                    configForm.ShowDialog();
                    break;
                }
                else if (loginForm.DialogResult == DialogResult.Retry)
                {
                    // Verify failed, Close Login Form and open another one
                    loginForm.Close();
                    continue;
                }
                break;
            }

            // Refresh Main Form
            ConfigLoad();
        }

        // Start Upload 
        private void StartUpload()
        {
            // Init FTP class.
            ftp = new FTPUpload(config.URL, config.username, config.password);

            int i = 0;
            // Upload Files
            foreach (string localFile in listFile)
            {
                string status;
                // Whether file exists in remote server
                if(ftp.isFileExist(Path.GetFileName(localFile)))
                {
                    // Exists, skip
                    status = "Existed";
                }
                else
                {
                    // Not exists, Upload file
                    if (ftp.Upload(Path.GetFileName(localFile), localFile))
                    {
                        status = "Completed";
                    }
                    else
                    {
                        status = "Failed";
                    }
                }
                
                // Back to main thread to refresh MainForm's UI
                this.BeginInvoke(new changechangeFileStatusDelegate(changeFileStatus),status,i);
                i++;
            }
        }

        // Main thread delegate to change file status.
        delegate void changechangeFileStatusDelegate(string status, int index);

        // Change file status
        private void changeFileStatus(string status, int index)
        {
            fileList.Items[index].SubItems[4].Text = status;
        }
    }
}
