using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public abstract class Limit
    {
        public Limit(BackupExtra backup)
        {
            this.Backup = backup;
        }

        public BackupExtra Backup { get; set; }

        public abstract int GetLimit();
    }
}