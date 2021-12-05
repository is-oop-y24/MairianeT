using System.Collections.Generic;
using Ionic.Zip;

namespace Backups
{
        public class SplitStoragesAlgorithm : IAlgorithm
        {
            private string _zipName;
            public List<ZipFile> MakeStorage(List<BackupFile> filesToSave, string path, string restorePointNumber)
            {
                var zipFiles = new List<ZipFile>();
                var toSave = new Repository();
                foreach (BackupFile file in filesToSave)
                {
                    _zipName = path + "/" + file.Name + "_" + restorePointNumber + ".zip";
                    var zip = new ZipFile();
                    zip.AddFile(file.FullName, "/");
                    toSave.SaveZip(zip, _zipName);
                    zipFiles.Add(zip);
                }

                _zipName = restorePointNumber;
                return zipFiles;
            }

            public string ZipName()
            {
                return _zipName;
            }
        }
}