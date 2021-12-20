using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Report> Create(
            [FromQuery] Guid ownerId,
            [FromQuery] string startTime,
            [FromQuery] string finishTime)
        {
            return await _service.Create(ownerId, startTime, finishTime);
        }
    }
}