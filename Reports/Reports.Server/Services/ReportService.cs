using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Database;

namespace Reports.Server.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportsDatabaseContext _context;

        public ReportService(ReportsDatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Report> Create(Guid ownerId, DateTime startTime, DateTime finishTime)
        {
            var report = new Report(new Guid(), ownerId, startTime, finishTime);
            await _context.SaveChangesAsync();
            return report;
        }
        
        public DbSet<Report> GetAll()
        {
            return _context.Reports;
        }

        public async Task<List<TaskModel>> TasksFromReport(Guid reportId)
        {
            var result = new List<TaskModel>();
            DateTime creationTime = (await _context.Reports.FindAsync(reportId)).StartTime;
            DateTime finishTime = (await _context.Reports.FindAsync(reportId)).FinishTime;
            await foreach (TaskModel task in _context.Tasks)
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
            await foreach (var employee in _context.Employees)
            {
                if (employee.LeaderId == leaderId)
                    employees.Add(employee.Id);
            }

            await foreach (var report in _context.Reports)
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
            (await _context.Reports.FindAsync(reportId)).TaskId = taskId;
        }
        public async Task Update(Report entity)
        {
            _context.Reports.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}