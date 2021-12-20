using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ReportsDatabaseContext _context;

        public TaskService(ReportsDatabaseContext context)
        {
            _context = context;
        }

        public async Task<TaskModel> Create(string description, Guid employeeId)
        {
            var task = new TaskModel(Guid.NewGuid(), employeeId, description);
            var taskFromDb = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<TaskModel> FindById(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task;
        }


        public DbSet<TaskModel> GetAll()
        {
            return _context.Tasks;
        }

        public async Task Update(TaskModel entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<TaskModel> GetTaskByTime(DateTime creationTime)
        {
            Guid resultId = Guid.Empty;
            foreach (TaskModel curTask in _context.Tasks)
            {
                if (curTask.CreationTime == creationTime)
                {
                    resultId = curTask.Id;
                }
            }

            TaskModel task = await _context.Tasks.FindAsync(resultId);
            return task;
        }

        public async Task<List<TaskModel>> GetTasksByEmployee(Guid employeeId)
        {
            var tasks = new List<TaskModel>();
            await foreach (TaskModel task in _context.Tasks)
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
            await foreach (Change change in _context.Changes)
            {
                if (!tasks.Contains(await _context.Tasks.FindAsync(change.TaskId)))
                    tasks.Add(await _context.Tasks.FindAsync(change.TaskId));
            }
            return tasks;
        }
        public async Task<List<TaskModel>> GetTasksByLeader(Guid leaderId)
        {
            var tasks = new List<TaskModel>();
            await foreach (Employee employee in _context.Employees)
            {
                if (employee.LeaderId == leaderId)
                {
                    await foreach (var task in _context.Tasks)
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