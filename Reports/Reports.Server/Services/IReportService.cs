using System;
using System.Threading.Tasks;
using Reports.DAL.Entities;

namespace Reports.Server.Services
{
    public interface IReportService
    {
        Task<Report> Create(Guid ownerId, string startTime, string finishTime);
    }
}