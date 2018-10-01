using System;
using System.IO;
using DatabaseReplacement.Shared;
using ICSharpCode.SharpZipLib.Zip;

namespace DatabaseReplacement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "sample.zip";
            var downloadDestination = @"E:\New folder\" + fileName;
            var unzipDestination = @"E:\New folder\sample";
            var downloadUrl = "https://localhost:44342/dPMI_E2E_CFG_V2.zip";
            var downloader = new Downloader(downloadUrl, downloadDestination);
            downloader.DownloadFile();
            var zipHelper = new ZipHelper();
            zipHelper.Unzip(downloadDestination, unzipDestination);
            System.Console.Read();
        }
    }
}
