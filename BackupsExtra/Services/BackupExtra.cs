using System.Collections.Generic;
using Backups;
using BackupsExtra.Entities;

namespace BackupsExtra.Services
{
    public class BackupExtra : Backup
    {
        private List<Limit> _limits;
        public BackupExtra(string path, IAlgorithm algorithm)
        : base(path, algorithm)
        {
            _limits = new List<Limit>();
        }
    }
}