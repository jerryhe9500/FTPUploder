using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpConfig;
namespace FTPUploader
{
    class Config
    {
        private Configuration config;
        private Section localSection;
        private Section ftpSection;

        public string path;
        public string URL;
        public string username;
        public string password;

        public Config()
        {
            config = Configuration.LoadFromFile("Uploader.cfg");
        }

        public void LoadFromConfig()
        {
            //Local
            localSection = config["Local"];
            path = localSection["path"].StringValue;
            //FTP
            ftpSection = config["FTP"];
            URL = ftpSection["URL"].StringValue;
            username = ftpSection["username"].StringValue;
            password = ftpSection["password"].StringValue;
        }

    }
}
