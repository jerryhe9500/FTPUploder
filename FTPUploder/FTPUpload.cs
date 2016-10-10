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
        private FtpWebResponse response = null;
        private Stream requestStream = null;

        private string username = null;
        private string password = null;
        private string URL = null;

        //Init Class
        public FTPUpload(string URL, string username, string password)
        {
            this.URL = URL;
            this.username = username;
            this.password = password;
        }

        public void Upload(string remoteFile, string localFile)
        {
            request = (FtpWebRequest)WebRequest.Create(URL + "/" + remoteFile);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential (username,password);

            sourceStream = new StreamReader(localFile);
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();

            try
            {
                requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                response = (FtpWebResponse)request.GetResponse();

                MessageBox.Show("Upload File Complete, status " + response.StatusDescription);
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
