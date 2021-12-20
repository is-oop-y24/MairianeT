using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reports.DAL.Entities;
using Reports.Server.Services;

namespace Reports.Server.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<Employee> Create([FromQuery] string name, [FromQuery] EmployeeType role)
        {
            return await _service.Create(name, role);
        }

        [HttpGet]
        [Route("/employees/FindOne")]
        public IActionResult Find([FromQuery] string name, [FromQuery] Guid id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Employee result = _service.FindByName(name);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            if (id != Guid.Empty)
            {
                Employee result = _service.FindById(id);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }

            return StatusCode((int) HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("/employees/GetAll")]
        public IActionResult GetAll()
        {
            DbSet<Employee> result = _service.GetAll();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] Employee entity)
        {
            if (entity.Role == EmployeeType.TeamLeader && entity.LeaderId != Guid.Empty)
                return StatusCode((int) HttpStatusCode.BadRequest);
            await _service.Update(entity);
            return Ok();
        }
    }
}

      