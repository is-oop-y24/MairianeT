using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        Task<TaskModel> Create(string description, Guid employeeId);
        Task<TaskModel> FindById(Guid id);
        DbSet<TaskModel> GetAll();
        Task Update(TaskModel entity);
        Task<TaskModel> GetTaskByTime(DateTime creationTime);
        Task<List<TaskModel>> GetTasksByEmployee(Guid employeeId);
        Task<List<TaskModel>> GetTasksWithChanges();
        Task<List<TaskModel>> GetTasksByLeader(Guid leaderId);
    }
}