using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class ReportRepository
    {
        private readonly ReportsDatabaseContext _context;
        public ReportRepository(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Report> Find(Guid id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public DbSet<Report> GetAll()
        {
            return _context.Reports;
        }
        public DbSet<TaskModel> GetAllTasks()
        {
            return _context.Tasks;
        }
        
        public DbSet<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }
        public async Task Update(Report entity)
        {
            _context.Reports.Update(entity);
        }
    }
}