using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FTPUploader
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string passFile = "pass";
        private string password;

        //
        // Form Event
        //

        // Whether the pass file existed
        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(passFile))
            {
                // Read password from file
                using (BinaryReader reader = new BinaryReader(File.Open(passFile, FileMode.Open)))
                {
                    password = reader.ReadString();
                }
            }
            else
            {
                // If cannot find pass file, close the form directly
                MessageBox.Show("Password file cannot find.");
                this.Close();
            }
        }

        // Login verify
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (isLogined())
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        //
        // Method
        //

        // Verify whether logined
        public bool isLogined()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Verify the password
                if (SecurityMD5.VerifyMd5Hash(md5Hash, passwordBox.Text, password))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Wrong Password!");
                    return false;
                }
            }
        }
    }
}
