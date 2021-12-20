using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Repositories
{
    public class EmployeeRepository
    {
        private readonly ReportsDatabaseContext _context;
        public EmployeeRepository(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public Employee FindByName(string name)
        {
            return Enumerable.FirstOrDefault(_context.Employees, employee => employee.Name == name);
        }
        public Employee FindById(Guid id)
        {
            return Enumerable.FirstOrDefault(_context.Employees, employee => employee.Id == id);
        }

        public async Task<Employee> Find(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public DbSet<Employee> GetAll()
        {
            return _context.Employees;
        }

        public async Task Update(Employee entity)
        {
            _context.Employees.Update(entity);
        }
    }
}