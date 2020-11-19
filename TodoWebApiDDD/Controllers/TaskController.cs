using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Util.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoWebApiDDD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskApplicationService _taskApplicationService;

        public TaskController(ITaskApplicationService taskApplicationService)
        {
            _taskApplicationService = taskApplicationService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public ActionResult<List<TaskDTO>> Get()
        {
            try
            {
                return Ok(_taskApplicationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public ActionResult<TaskDTO> Get(int id)
        {
            try
            {
                return Ok(_taskApplicationService.Get(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // POST api/<TaskController>
        [HttpPost]
        public ActionResult<TaskDTO> Post([FromBody] TaskDTO task)
        {
            try
            {
                return Ok(_taskApplicationService.Add(task));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public ActionResult<TaskDTO> Put(int id, [FromBody] TaskDTO task)
        {
            try
            {
                return Ok(_taskApplicationService.Update(id, task));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _taskApplicationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }
    }
}
