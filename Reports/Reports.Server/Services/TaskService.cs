using System;
using System.Threading.Tasks;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class TaskService
    {
        private readonly ReportsDatabaseContext _context;
        
        public TaskService(ReportsDatabaseContext context) {
            _context = context;
        }
        public async Task<TaskModel> Create(string description, Guid employeeId)
        {
            var task = new TaskModel(Guid.NewGuid(), employeeId, description);
            var taskFromDb = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}