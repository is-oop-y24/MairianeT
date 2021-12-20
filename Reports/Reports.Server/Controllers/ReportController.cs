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
            [FromQuery] DateTime startTime,
            [FromQuery] DateTime finishTime)
        {
            return await _service.Create(ownerId, startTime, finishTime);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        
        [HttpGet]
        [Route("/reports/tasks")]
        public async Task<IActionResult> GetTasksFromReport([FromQuery] Guid reportId)
        {
            return Ok(await _service.TasksFromReport(reportId));
        }
        [HttpGet]
        [Route("/reports/byLeader")]
        public async Task<IActionResult> GetReportsByEmployees([FromQuery] Guid leaderId)
        {
            return Ok(await _service.TasksByLeader(leaderId));
        }

        [HttpPatch]
        [Route("/reports/addTask")]
        public async Task<IActionResult> AddTask([FromQuery] Guid reportId, [FromQuery] Guid taskId)
        {
            await _service.AddTaskToReport(taskId, reportId);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Report entity)
        {
            await _service.Update(entity);
            return Ok();
        }
    }
}