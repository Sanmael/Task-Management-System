using Application.DTO;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDTO personDTO)
        {
            await _personService.InsertPerson(personDTO);

            return Ok(personDTO);
        }
    }
}
