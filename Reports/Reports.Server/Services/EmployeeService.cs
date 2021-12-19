using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Reports.DAL.Entities;
using Reports.Server.Controllers;
using Reports.Server.Database;
using Task = System.Threading.Tasks.Task;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ReportsDatabaseContext _context;

        public EmployeeService(ReportsDatabaseContext context) {
            _context = context;
        }

        public async Task<Employee> Create(string name, EmployeeType role)
        {
            var employee = new Employee(Guid.NewGuid(), name, role, Guid.Empty);
            var employeeFromDb = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public Employee FindByName(string name)
        {
            return Enumerable.FirstOrDefault(_context.Employees, employee => employee.Name == name);
        }

        public async Task<Employee> FindById(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee;
        }

        public DbSet<Employee> GetAll()
        {
            return _context.Employees;
        }

        public async Task<Employee> Delete(Guid id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            await Task.Run(() => _context.Employees.Remove(employee));
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task Update(Employee entity)
        {
            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}