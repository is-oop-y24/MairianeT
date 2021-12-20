using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;
using Reports.Server.Repositories;

namespace Reports.Server.Services
{
    public class ChangeService : IChangeService
    {
        private readonly ChangeRepository _repository;

        public ChangeService(ChangeRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Change> Create(Guid taskId, string comment)
        {
            var change = new Change(taskId, comment);
            await _repository.SaveChanges();
            return change;
        }
        public DbSet<Change> GetAllChanges()
        {
            return _repository.GetAll();
        }

        public async Task<Change> GetChangeById(Guid changeId)
        {
            var change = await _repository.Find(changeId);
            return change;
        }

        public async Task<Change> GetChangeByTime(DateTime creationTime)
        {
            Guid resultId = Guid.Empty;
            foreach (Change current in _repository.GetAll())
            {
                if (current.CreationTime == creationTime)
                {
                    resultId = current.Id;
                }
            }

            Change result = await _repository.Find(resultId);
            return result;
        }
    }
}