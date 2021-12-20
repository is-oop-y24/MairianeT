using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;
using Reports.Server.Repositories;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportRepository _repository;

        public ReportService(ReportRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<Report> Create(Guid ownerId, DateTime startTime, DateTime finishTime)
        {
            var report = new Report(new Guid(), ownerId, startTime, finishTime);
            await _repository.SaveChanges();
            return report;
        }
        
        public DbSet<Report> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<List<TaskModel>> TasksFromReport(Guid reportId)
        {
            var result = new List<TaskModel>();
            DateTime creationTime = (await _repository.Find(reportId)).StartTime;
            DateTime finishTime = (await _repository.Find(reportId)).FinishTime;
            await foreach (TaskModel task in _repository.GetAllTasks())
            {
                if (task.CreationTime >= creationTime && task.CreationTime <= finishTime)
                {
                    result.Add(task);
                }
            }

            return result;
        }
        public async Task<List<Report>> TasksByLeader(Guid leaderId)
        {
            var result = new List<Report>();
            var employees = new List<Guid>();
            await foreach (var employee in _repository.GetAllEmployees())
            {
                if (employee.LeaderId == leaderId)
                    employees.Add(employee.Id);
            }

            await foreach (var report in _repository.GetAll())
            {
                foreach (var employee in employees)
                {
                    if (employee == report.Id)
                        result.Add(report);
                }
            }

            return result;
        }

        public async Task AddTaskToReport(Guid taskId, Guid reportId)
        {
            (await _repository.Find(reportId)).TaskId = taskId;
        }
        public async Task Update(Report entity)
        {
            await _repository.Update(entity);
            await _repository.SaveChanges();
        }
    }
}