using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<TaskModel> Create(
            [FromQuery] string description, 
            [FromQuery] Guid employeeId)
        {
            return await _service.Create(description, employeeId);
        }
        [HttpGet]
        [Route("/task/all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("/task/Id")]
        public async Task<IActionResult> FindById([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var result = await _service.FindById(id);
                return Ok(result);
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("/task/time")]
        public async Task<IActionResult> GetByTime([FromQuery] DateTime creationTime)
        {
            return Ok(await _service.GetTaskByTime(creationTime));
        }
        
        [HttpGet]
        [Route("/task/designatedEmployee")]
        public async Task<IActionResult> GetByDesignatedEmployee([FromQuery] Guid employeeId)
        {
            if (employeeId != Guid.Empty)
            {
                return Ok(await _service.GetTasksByEmployee(employeeId));
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpGet]
        [Route("/task/withChanges")]
        public async Task<IActionResult> GetTasksWithChanges()
        {
            return Ok(await _service.GetTasksWithChanges());
        }
        
        [HttpGet]
        [Route("/task/leader")]
        public async Task<IActionResult> GetByLeader([FromQuery] Guid leaderId)
        {
            if (leaderId != Guid.Empty)
            {
                return Ok(await _service.GetTasksByEmployee(leaderId));
            }
            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] TaskModel task)
        {
            await _service.Update(task);
            return Ok();
        }
    }
}