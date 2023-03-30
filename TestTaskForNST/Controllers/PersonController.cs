using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TestTaskForNST.Models;
using TestTaskForNST.Services;

namespace TestTaskForNST.Controllers
{
    [Route("api/vl")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _person;

        public PersonController(IPersonService person)
        {
            _person = person;
        }

        [HttpGet("persons")]
        public async Task<IActionResult> GerPersons()
        {
            try
            {
                return Ok(await _person.GetAllPerson());
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("person/{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            try
            {
                return Ok(await _person.GetPerson(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("person")]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest($"Объект {nameof(person)} был null");
                }
                return Ok(await _person.Create(person));
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("person/{id}")]
        public async Task<IActionResult> Update(int id, Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest($"Объект {nameof(person)} был null");
                }

                return Ok(await _person.Update(id, person));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("person/{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                return Ok(await _person.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
