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

        protected BackupExtra Backup { get; }

        public abstract int GetLimit();
    }
}