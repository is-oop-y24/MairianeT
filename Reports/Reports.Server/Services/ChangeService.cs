using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class ChangeService : IChangeService
    {
        private readonly ReportsDatabaseContext _context;

        public ChangeService(ReportsDatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Change> Create(Guid taskId, string comment, string creationTime)
        {
            var change = new Change(taskId, comment, creationTime);
            var taskFromDb = await _context.Changes.AddAsync(change);
            await _context.SaveChangesAsync();
            return change;
        }
        public DbSet<Change> GetAllChanges()
        {
            return _context.Changes;
        }

        public async Task<Change> GetChangeById(Guid changeId)
        {
            var change = await _context.Changes.FindAsync(changeId);
            return change;
        }

        public async Task<Change> GetChangeByTime(string creationTime)
        {
            Guid resultId = Guid.Empty;
            foreach (Change current in _context.Changes)
            {
                if (current.CreationTime == creationTime)
                {
                    resultId = current.Id;
                }
            }

            Change result = await _context.Changes.FindAsync(resultId);
            return result;
        }
    }
}