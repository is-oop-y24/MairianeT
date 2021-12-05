using System;
using System.Collections.Generic;
using Backups;
using BackupsExtra.Entities;
using BackupsExtra.Tool;

namespace BackupsExtra.Services
{
    public class BackupExtra : Backup, IBackup
    {
        private Limit _timeLimit;
        private Limit _numberLimit;
        private RepositoryExtra _repository = new RepositoryExtra();
        public BackupExtra(string path, IAlgorithm algorithm)
        : base(path, algorithm)
        {
        }

        public void SetTimeLimit(DateTime dateTime)
        {
            _timeLimit = new TimeLimit(this, dateTime);
        }

        public void SetNumberLimit(int maxNumber)
        {
            _numberLimit = new NumberLimit(this, maxNumber);
        }

        public void PushToLimit(LimitType type)
        {
            switch (type)
            {
                case LimitType.Time:
                    for (int i = 0; i < _timeLimit.GetLimit(); i++)
                    {
                        _repository.RemoveRestorePoint(this, i, Algorithm);
                    }

                    break;
                case LimitType.Number:
                    for (int i = 0; i < _numberLimit.GetLimit(); i++)
                    {
                        _repository.RemoveRestorePoint(this, i, Algorithm);
                    }

                    break;
                case LimitType.HybridAll:
                    for (int i = 0; i < Math.Max(_numberLimit.GetLimit(), _timeLimit.GetLimit()); i++)
                    {
                        _repository.RemoveRestorePoint(this, i, Algorithm);
                    }

                    break;
                case LimitType.HybridLeastOne:
                    for (int i = 0; i < Math.Min(_numberLimit.GetLimit(), _timeLimit.GetLimit()); i++)
                    {
                        _repository.RemoveRestorePoint(this, i, Algorithm);
                    }

                    break;
                default:
                    throw new BackupsExtraException("Incorrect Limit Type");
            }
        }
    }
}