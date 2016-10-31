using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SharpConfig;
namespace FTPUploader
{
    class Config
    {
        private Configuration config = new Configuration();
        private Section localSection;
        private Section ftpSection;

        public string localPath;
        public string URL;
        public string username;
        public string password;

        // Load from default file
        public void LoadFromConfig()
        {
            config = Configuration.LoadFromBinaryFile("Uploader.cfg");
            // Local
            localSection = config["Local"];
            localPath = localSection["path"].StringValue;
            // FTP
            ftpSection = config["FTP"];
            URL = ftpSection["URL"].StringValue;
            username = ftpSection["username"].StringValue;
            password = ftpSection["password"].StringValue;
        }

        // Load from a file
        public void LoadFromConfig(string path)
        {
            config = Configuration.LoadFromBinaryFile(path);
            // Local
            localSection = config["Local"];
            localPath = localSection["Path"].StringValue;
            MessageBox.Show(path);
            // FTP
            ftpSection = config["FTP"];
            URL = ftpSection["URL"].StringValue;
            username = ftpSection["username"].StringValue;
            password = ftpSection["password"].StringValue;
        }

        // Save config to file
        public void SaveConfigToFile()
        {
            if (File.Exists("Uploader.cfg"))
            {
                File.Delete("Uploader.cfg");
            }
            config = new Configuration();
            // Local
            localSection = config["Local"];
            localSection["Path"].SetValue(localPath);
            // FTP
            ftpSection = config["FTP"];
            ftpSection["URL"].SetValue(URL);
            ftpSection["username"].SetValue(username);
            ftpSection["password"].SetValue(password);

            config.SaveToBinaryFile("Uploader.cfg");
        }

        /*
         * Example Config File
         * 
         * [Local]
         * Path = 
         * 
         * [FTP]
         * URL = ftp://
         * username = 
         * password = 
         * 
         * //The URL in FTP must be contained with "ftp://"
         * 
        */
    }
}
