using System;
using System.Linq;
using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public class TimeLimit : Limit
    {
        public TimeLimit(BackupExtra backup, DateTime lastTime)
            : base(backup)
        {
            LastTime = lastTime;
        }

        public DateTime LastTime { get; set; }

        public override int GetLimit()
        {
            return Backup.RestorePoints.Count(rp => DateTime.Compare(rp.CreationTime, LastTime) <= 0);
        }
    }
}