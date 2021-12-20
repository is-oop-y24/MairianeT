using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        Task<Report> Create(Guid ownerId, DateTime startTime, DateTime finishTime);
        Task<List<TaskModel>> TasksFromReport(Guid reportId);
        DbSet<Report> GetAll();
        Task<List<Report>> TasksByLeader(Guid leaderId);
        Task AddTaskToReport(Guid taskId, Guid reportId);
        Task Update(Report entity);
    }
}