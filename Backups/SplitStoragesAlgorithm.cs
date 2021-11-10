using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
        public class SplitStoragesAlgorithm : IAlgorithm
        {
            public List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber)
            {
                var zipFiles = new List<ZipFile>();
                var toSave = new Repository();
                foreach (BackupFile file in filesToSave)
                {
                    string zipName = path + "/" + file.Name + "_" + restorePointNumber + ".zip";
                    var zip = new ZipFile();
                    zip.AddFile(file.FullName, "/");
                    toSave.SaveZip(zip, zipName);
                    zipFiles.Add(zip);
                }

                return zipFiles;
            }
        }
}