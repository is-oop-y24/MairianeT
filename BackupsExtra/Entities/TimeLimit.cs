using System;
using System.Linq;
using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public class TimeLimit : Limit
    {
        private DateTime _lastTime;
        public TimeLimit(BackupExtra backup, DateTime lastTime)
            : base(backup)
        {
            _lastTime = lastTime;
        }

        public override int GetLimit()
        {
            return Backup.RestorePoints.Count(rp => DateTime.Compare(rp.CreationTime, _lastTime) <= 0);
        }
    }
}