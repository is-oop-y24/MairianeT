using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/changes")]
    public class ChangesController : ControllerBase
    {
        private readonly IChangeService _service;
        public ChangesController(IChangeService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<Change> Create([FromQuery] Guid taskId, [FromQuery] string comment)
        {
            return await _service.Create(taskId, comment);
        }
        [HttpGet]
        [Route("/changes/all")]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllChanges());
        }
        [HttpGet]
        [Route("/changes/Id")]
        public async Task<IActionResult> FindById([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var result = await _service.GetChangeById(id);
                return Ok(result);
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }
        [HttpGet]
        [Route("/changes/time")]
        public async Task<IActionResult> GetByTime([FromQuery] DateTime creationTime)
        {
            return Ok(await _service.GetChangeByTime(creationTime));
        }
    }
}