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
        private WebClient ftpClient = new WebClient();
        private string URL = null;
        private string username = null;
        private string password = null;

        //Init Class
        public FTPUpload(string URL, string username, string password)
        {
            this.URL = URL;
            this.username = username;
            this.password = password;
            ftpClient.Credentials = new NetworkCredential(username, password);
        }

        public FTPUpload()
        {

        }

        public bool VerifyConnection(string URL, string username, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }

        }

        public bool Upload(string remoteFile, string localFile)
        {
            try
            {
                string remotePath = URL + "/" + remoteFile;
                ftpClient.UploadFile(remotePath, WebRequestMethods.Ftp.AppendFile, localFile);
                return true;
            }
            catch(WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        public bool isFileExist(string remoteFile)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(URL + "/" + remoteFile);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;
        }


    }
}
