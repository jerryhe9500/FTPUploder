using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace FTPUploader
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            // Load config from default file
            if(File.Exists("Uploader.cfg"))
            {
                config.LoadFromConfig();
                localPathTextBox.Text = config.localPath;
                urlTextBox.Text = config.URL;
                usernameTextBox.Text = config.username;
                passwordTextBox.Text = config.password;
            }
        }

        private Config config = new Config();

        //
        // Form Event
        //

        // Choose local directory
        private void dirButton_Click(object sender, EventArgs e)
        {
            DialogResult result = localPathBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                MessageBox.Show("Wrong Path Selected!");
            }
            localPathTextBox.Text = localPathBrowserDialog.SelectedPath;
        }

        // Verify the ftp connection
        private void verifyButton_Click(object sender, EventArgs e)
        {
            FTPUpload ftp = new FTPUpload();
            if(ftp.VerifyConnection(urlTextBox.Text, usernameTextBox.Text, passwordTextBox.Text))
            {
                MessageBox.Show("Connected");
            }
            else
            {
                MessageBox.Show("Please check your URL, username, password are correctly");
            }
        }

        // Reset password
        private void resetButton_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Get MD5Hashed Code
                string password = SecurityMD5.GetMd5Hash(md5Hash, configPasswordTextBox.Text);
                if (File.Exists("pass"))
                {
                    File.Delete("pass");
                }
                // Create the pass file.
                using (BinaryWriter writer = new BinaryWriter(File.Open("pass", FileMode.Create)))
                {
                    writer.Write(password);
                }
                MessageBox.Show("Password has been reset.");
            }
        }

        // Save config to File
        private void saveButton_Click(object sender, EventArgs e)
        {
            config.localPath = localPathTextBox.Text;
            config.URL = urlTextBox.Text;
            config.username = usernameTextBox.Text;
            config.password = passwordTextBox.Text;
            config.SaveConfigToFile();
            MessageBox.Show("Saved");
        }

        // Load config from file(by choosing file)
        private void loadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openConfigFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                config.LoadFromConfig(openConfigFileDialog.FileName);
                localPathTextBox.Text = config.localPath;
                urlTextBox.Text = config.URL;
                usernameTextBox.Text = config.username;
                passwordTextBox.Text = config.password;
            }
            else
            {
                MessageBox.Show("Wrong File Selected! Please select again.");
            }
        }
    }
}
