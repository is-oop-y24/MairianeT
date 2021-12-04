using System.IO;
using Backups;

namespace BackupsExtra.Entities
{
    public class RepositoryExtra : Repository
    {
        public void RemoveDirectory(string path)
        {
            Directory.Delete(path);
        }
    }
}