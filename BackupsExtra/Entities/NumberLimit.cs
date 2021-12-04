using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public class NumberLimit : Limit
    {
        private int _maxPoints;

        public NumberLimit(BackupExtra backup, int maxPoints)
        : base(backup)
        {
            _maxPoints = maxPoints;
        }

        public override int GetLimit()
        {
            int limits = Backup.RestorePoints.Count - _maxPoints;
            return limits > 0 ? limits : 0;
        }
    }
}