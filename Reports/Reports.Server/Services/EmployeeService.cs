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
using Reports.Server.Repositories;
using Task = System.Threading.Tasks.Task;

namespace Reports.Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> Create(string name, EmployeeType role)
        {
            var employee = new Employee(Guid.NewGuid(), name, role, Guid.Empty);
            await _repository.SaveChanges();
            return employee;
        }

        public Employee FindByName(string name)
        {
            return _repository.FindByName(name);
        }

        public Employee FindById(Guid id)
        {
            return _repository.FindById(id);
        }

        public DbSet<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Employee> Delete(Guid id)
        {
            Employee employee = await _repository.Find(id);
            await Task.Run(() => _repository.Remove(employee));
            await _repository.SaveChanges();
            return employee;
        }

        public async Task Update(Employee entity)
        {
            await _repository.Update(entity);
            await _repository.SaveChanges();
        }
    }
}