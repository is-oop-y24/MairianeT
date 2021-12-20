using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface ITaskService
    {
        Task<TaskModel> Create(string description, Guid employeeId, string creationTime);
        Task<TaskModel> FindById(Guid id);
        DbSet<TaskModel> GetAll();
        Task Update(TaskModel entity);
        Task<TaskModel> GetTaskByTime(string creationTime);
        Task<List<TaskModel>> GetTasksByEmployee(Guid employeeId);
        Task<List<TaskModel>> GetTasksWithChanges();
        Task<List<TaskModel>> GetTasksByLeader(Guid leaderId);
    }
}