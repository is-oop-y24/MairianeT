using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;
using Reports.Server.Repositories;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskRepository _repository;

        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskModel> Create(string description, Guid employeeId)
        {
            var task = new TaskModel(Guid.NewGuid(), employeeId, description);
            await _repository.SaveChanges();
            return task;
        }

        public async Task<TaskModel> FindById(Guid id)
        {
            var task = await _repository.Find(id);
            return task;
        }


        public DbSet<TaskModel> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task Update(TaskModel entity)
        {
            await _repository.Update(entity);
            await _repository.SaveChanges();
        }
        public async Task<TaskModel> GetTaskByTime(DateTime creationTime)
        {
            Guid resultId = Guid.Empty;
            foreach (TaskModel curTask in _repository.GetAll())
            {
                if (curTask.CreationTime == creationTime)
                {
                    resultId = curTask.Id;
                }
            }

            TaskModel task = await _repository.Find(resultId);
            return task;
        }

        public async Task<List<TaskModel>> GetTasksByEmployee(Guid employeeId)
        {
            var tasks = new List<TaskModel>();
            await foreach (TaskModel task in _repository.GetAll())
            {
                if (task.DesignatedEmployeeId == employeeId)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
        public async Task<List<TaskModel>> GetTasksWithChanges()
        {
            var tasks = new List<TaskModel>();
            await foreach (Change change in _repository.GetAllChanges())
            {
                if (!tasks.Contains(await _repository.Find(change.TaskId)))
                    tasks.Add(await _repository.Find(change.TaskId));
            }
            return tasks;
        }
        public async Task<List<TaskModel>> GetTasksByLeader(Guid leaderId)
        {
            var tasks = new List<TaskModel>();
            await foreach (Employee employee in _repository.GetAllEmployees())
            {
                if (employee.LeaderId == leaderId)
                {
                    await foreach (var task in _repository.GetAll())
                    {
                        if (employee.Id == task.DesignatedEmployeeId)
                        {
                            tasks.Add(task);
                        }
                    }
                }
            }
            return tasks;
        }
    }
}