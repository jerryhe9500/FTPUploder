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
using System.Collections.Generic;

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

            //Load from a config file.
            config.LoadFromConfig();

            //Init FTP class.
            ftp = new FTPUpload(config.URL, config.username, config.password);
            
            //Go through the directory and show every file in a listBox.
            DirectoryInfo dir = new DirectoryInfo(config.path);
            GetFileList(dir);

            //Start Upload after the form loaded.
            Shown += MainForm_Shown;
        }

        private void MainForm_Shown(Object sender, EventArgs e)
        {
            foreach (string localFile in listFile)
            {
                ftp.Upload(Path.GetFileName(localFile), localFile);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetFileList(DirectoryInfo diroot)
        {
            foreach (FileInfo fileName in diroot.GetFiles())
            {
                listFile.Add(fileName.FullName);
                listBox1.Items.Add(fileName.Name);
            }

            foreach (DirectoryInfo dirSub in diroot.GetDirectories())
            {
                GetFileList(dirSub);
            }
        }
    }
}
