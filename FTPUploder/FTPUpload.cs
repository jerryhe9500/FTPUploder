using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace FTPUploader
{
    class FTPUpload
    {
        private FtpWebRequest request = null;
        private StreamReader sourceStream = null;
        //private FtpWebResponse response = null;

        private string username = null;
        private string password = null;
        private string URL = null;


        public FTPUpload(string URL, string username, string password)
        {
            this.URL = URL;
            this.username = username;
            this.password = password;
        }

        public void Upload(string remoteFile, string localFile)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL+"/"+remoteFile);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential (username,password);

            sourceStream = new StreamReader(localFile);
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();

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
        }
        //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://202.121.127.206");
            
            //request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("root","ct7rTqinJNBKikme");

            // Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader(sourceFile);
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

    }
}
