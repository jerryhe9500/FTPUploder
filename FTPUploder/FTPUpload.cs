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

        //Init Class
        public FTPUpload(string URL, string username, string password)
        {
            this.URL = URL;
            ftpClient.Credentials = new NetworkCredential(username, password);
        }

        public void Upload(string remoteFile, string localFile)
        {
            try
            {
                string remotePath = URL + "/" + remoteFile;
                ftpClient.UploadFile(remotePath, WebRequestMethods.Ftp.AppendFile, localFile);
                MessageBox.Show("Upload File " + remoteFile + " Complete");
            }
            catch(WebException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
