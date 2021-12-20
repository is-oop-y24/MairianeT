using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class TaskRepository
    {
        private readonly ReportsDatabaseContext _context;
        public TaskRepository(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TaskModel> Find(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public DbSet<TaskModel> GetAll()
        {
            return _context.Tasks;
        }
        public DbSet<Change> GetAllChanges()
        {
            return _context.Changes;
        }
        public DbSet<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public async Task Update(TaskModel entity)
        {
            _context.Tasks.Update(entity);
        }
    }
}