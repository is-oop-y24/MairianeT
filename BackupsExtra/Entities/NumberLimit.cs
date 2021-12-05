using Backups;
using BackupsExtra.Services;

namespace BackupsExtra.Entities
{
    public class NumberLimit : Limit
    {
        public NumberLimit(BackupExtra backup, int maxPoints)
        : base(backup)
        {
            MaxPoints = maxPoints;
        }

        private int MaxPoints { get; set; }

        public override int GetLimit()
        {
            int limits = Backup.RestorePoints.Count - MaxPoints;
            return limits > 0 ? limits : 0;
        }
    }
}