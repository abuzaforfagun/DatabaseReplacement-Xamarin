using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace DatabaseReplacement.Shared
{
    public class ZipHelper
    {
        public void Unzip(string destination, string fileName, string unZipDestination)
        {
            var filePath = Path.Combine(destination, fileName);
            using (ZipInputStream s = new ZipInputStream(File.OpenRead(filePath)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {


                    string directoryName = unZipDestination;
                    string zipFileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName.Length > 0)
                    {
                        Directory.CreateDirectory(directoryName);
                    }

                    if (zipFileName != String.Empty)
                    {
                        using (FileStream streamWriter = File.Create(Path.Combine(directoryName, theEntry.Name)))
                        {

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}