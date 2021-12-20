using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Task = System.Threading.Tasks.Task;

namespace Reports.Server.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Create(string name, EmployeeType role);

        Employee FindByName(string name);

        Employee FindById(Guid id);
        DbSet<Employee> GetAll();

        Task<Employee> Delete(Guid id);

        Task Update(Employee entity);
    }
}