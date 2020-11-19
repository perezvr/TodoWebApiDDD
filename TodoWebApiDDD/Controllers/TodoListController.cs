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
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListApplicationService _todoListApplicationService;

        public TodoListController(ITodoListApplicationService todoListApplicationService)
        {
            _todoListApplicationService = todoListApplicationService;
        }

        // GET: api/<TodoListController>
        [HttpGet]
        public ActionResult<List<TodoListDTO>> Get()
        {
            try
            {
                return Ok(_todoListApplicationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoListDTO> Get(int id)
        {
            try
            {
                return Ok(_todoListApplicationService.Get(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // POST api/<TodoListController>
        [HttpPost]
        public ActionResult<TodoListDTO> Post([FromBody] TodoListDTO todoList)
        {
            try
            {
                return Ok(_todoListApplicationService.Add(todoList));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public ActionResult<TodoListDTO> Put(int id, [FromBody] TodoListDTO todoList)
        {
            try
            {
                return Ok(_todoListApplicationService.Update(id, todoList));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // DELETE api/<TodoListController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _todoListApplicationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }
    }
}
