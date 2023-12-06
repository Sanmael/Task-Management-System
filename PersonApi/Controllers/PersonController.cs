using Application.DTO;
using Application.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using PersonApi.PersonResponses;

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

        [HttpGet]
        public async Task<IActionResult> GetPersonById(long personId)
        {
            PersonDTO personDTO = await _personService.GetPersonById(personId);

            if(personDTO == null)
            {
                GetPersonByIdResponse getPersonByIdResponseNotFound = new GetPersonByIdResponse("Usuario nao encontrado.", personDTO);
                return NotFound(getPersonByIdResponseNotFound);
            }

            GetPersonByIdResponse getPersonByIdResponse = new GetPersonByIdResponse("Usuario encontrado.", personDTO);
            return Ok(getPersonByIdResponse);
        }
    }
}
