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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplicationService _categoryApplicationService;

        public CategoryController(ICategoryApplicationService categoryApplicationService)
        {
            _categoryApplicationService = categoryApplicationService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public ActionResult<List<CategoryDTO>> Get()
        {
            try
            {
                return Ok(_categoryApplicationService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> Get(int id)
        {
            try
            {
                return Ok(_categoryApplicationService.Get(id));

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public ActionResult<CategoryDTO> Post([FromBody] CategoryDTO category)
        {
            try
            {
                return Ok(_categoryApplicationService.Add(category));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public ActionResult<CategoryDTO> Put(int id, [FromBody] CategoryDTO category)
        {
            try
            {
                return Ok(_categoryApplicationService.Update(id, category));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryApplicationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.GetExceptionMessage() });
            }
        }
    }
}
