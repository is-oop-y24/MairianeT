using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<Report> Create(Guid ownerId, string startTime, string finishTime)
        {
            var report = new Report(new Guid(), ownerId, startTime, finishTime);
            var taskFromDb = await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
            return report;
        }
    }
}