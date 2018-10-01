using System;
using System.IO;
using System.Net;

namespace DatabaseReplacement.Shared
{
    public class Downloader
    {
        private readonly string _fileUrl;
        private readonly string _destination;

        public Downloader(string fileUrl, string destination)
        {
            _fileUrl = fileUrl;
            _destination = destination;
        }
        public void DownloadFile()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(_fileUrl, _destination);
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
