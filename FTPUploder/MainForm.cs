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

namespace FTPUploader
{
    public partial class MainForm : Form
    {
        private Config config = new Config();

        public MainForm()
        {
            InitializeComponent();
            config.LoadFromConfig();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            /*
            //Choose a sourcee file
            do
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (openFileDialog.OpenFile() != null)
                        {
                            fileName = openFileDialog.SafeFileName;
                            sourceFile = openFileDialog.FileName;
                            saveFileDialog.FileName = fileName;
                            MessageBox.Show("source:" + sourceFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            } while (sourceFile == null);
            */
            
            
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://202.121.127.206");
            
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("root","ct7rTqinJNBKikme");

            // Copy the contents of the file to the request stream.
            StreamReader sourceStream = new StreamReader(sourceFile);
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            MessageBox.Show("Length:" + fileContents.Length);

            try
            {
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                //Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                MessageBox.Show("Upload File Complete, status " + response.StatusDescription);
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            

            /*
            //Choose a destination path
            do
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        destFile = saveFileDialog.FileName;
                        MessageBox.Show("destination:" + destFile);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save file to disk. Original error: " + ex.Message);
                    }
                }
            } while (destFile == null);

            //Provide a standard dialog box that shows progress on file operations in Windows
            try
            {
                FileSystem.CopyFile(sourceFile, destFile, UIOption.AllDialogs);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            */
        }
    }
}
