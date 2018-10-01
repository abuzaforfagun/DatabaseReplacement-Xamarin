using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace DatabaseReplacement.Shared
{
    public class ZipHelper
    {
        public void Unzip(string fileLocation, string unZipDestination)
        {
            using (ZipInputStream zipInputStream = new ZipInputStream(File.OpenRead(fileLocation)))
            {
                ZipEntry theEntry;
                while ((theEntry = zipInputStream.GetNextEntry()) != null)
                {
                    string zipFileName = Path.GetFileName(theEntry.Name);

                    createDirectory(unZipDestination);

                    if (zipFileName != String.Empty)
                    {
                        writeInFile(zipInputStream, theEntry, unZipDestination);
                    }
                }
            }
        }

        private void createDirectory(string directoryName)
        {
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(directoryName);
            }
        }

        private void writeInFile(ZipInputStream zipInputStream, ZipEntry theEntry, string directoryName)
        {
            using (FileStream streamWriter = File.Create(Path.Combine(directoryName, theEntry.Name)))
            {
                int size = 2048;
                byte[] data = new byte[2048];
                while (size > 0)
                {
                    size = zipInputStream.Read(data, 0, data.Length);
                    streamWriter.Write(data, 0, size);

                }
            }
        }
    }
}