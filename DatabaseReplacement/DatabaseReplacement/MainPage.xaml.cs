using Foundation;
using Plugin.DownloadManager;
using Plugin.DownloadManager.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DatabaseReplacement
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            downloadFile();
            var data = unzip();
            
        }

        private void downloadFile()
        {
            string envoirnmentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var downloadManager = CrossDownloadManager.Current;
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(file1 => {

                string fileName = (new NSUrl(file1.Url, false)).LastPathComponent;
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            });
            var fileUrl = "http://172.16.0.252:8080/DashboardFrameworkClient/dPMI_E2E_CFG.zip";
            var file = downloadManager.CreateDownloadFile(fileUrl);
            downloadManager.Start(file);
            
            var directories = Directory.EnumerateDirectories("./");
            // Get the file name
            var fileNames = Path.Combine(envoirnmentFolderPath, "dPMI_E2E_CFG.zip");
            
        }


        private string unzip()
        {
            string envoirnmentFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fileContent = "";
            var fileNames = Path.Combine(envoirnmentFolderPath, "dPMI_E2E_CFG.zip");
            string fileName = "";

            using (System.IO.Compression.ZipArchive za = System.IO.Compression.ZipFile.OpenRead(fileNames))
            {
                foreach(var item in za.Entries)
                {
                    fileName = item.Name;
                    item.ExtractToFile(Path.Combine(envoirnmentFolderPath, item.Name));
                }
                fileNames = Path.Combine(envoirnmentFolderPath, fileName);

                fileContent = System.IO.File.ReadAllText(fileNames);
            }
            return fileContent;
        }
    }
}
