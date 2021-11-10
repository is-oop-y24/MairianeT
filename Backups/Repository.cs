using System.IO;
using Ionic.Zip;

namespace Backups
{
    public class Repository
    {
        public string MakeDirectory(string path)
        {
            string directory = path + "/Backup";
            Directory.CreateDirectory(directory);
            return directory;
        }

        public void SaveZip(ZipFile zip, string name)
        {
            zip.Save(name);
        }
    }
}