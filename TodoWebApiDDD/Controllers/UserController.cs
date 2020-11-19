using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Util.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoWebApiDDD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            try
            {
                return Ok(_userApplicationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            try
            {
                return Ok(_userApplicationService.Get(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO user)
        {
            try
            {
                return Ok(_userApplicationService.Add(user));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<UserDTO> Put(int id, [FromBody] UserDTO user)
        {
            try
            {
                return Ok(_userApplicationService.Update(id, user));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userApplicationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }
    }
}
