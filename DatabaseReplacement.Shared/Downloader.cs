using System;
using System.IO;
using System.Net;

namespace DatabaseReplacement.Shared
{
    public class Downloader
    {
        private readonly string _fileUrl;
        private readonly string _destination;
        private readonly string _fileName;

        public Downloader(string fileUrl, string destination, string fileName)
        {
            _fileUrl = fileUrl;
            _destination = destination;
            _fileName = fileName;
        }
        public void DownloadFile()
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadFile(_fileUrl, Path.Combine(_destination, _fileName));
            }
            catch (Exception ex)
            {

            }
            

        }
    }
}
