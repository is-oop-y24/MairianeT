using System.IO;

namespace Backups
{
    public class Repository
    {
        public Repository()
        {
        }

        public string MakeDirectory(string path)
        {
            string directory = path + "/Backup";
            Directory.CreateDirectory(directory);
            return directory;
        }
    }
}