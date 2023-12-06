using Application.DTO;
using Domain.Entitys;
using Domain.Enums;
using Domain.Interfaces;


namespace Application.Services
{
    public class PersonService 
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task InsertPerson(PersonDTO personDTO)
        {
            Person person = new Person(personDTO.UserId, personDTO.FirstName, personDTO.LastName, personDTO.Age, personDTO.Birthday, personDTO.Salary, (JobPosition)personDTO.JobPosition);

            await _personRepository.InsertPerson(person);

            personDTO.Id = person.Id;            
        }
        public async Task<PersonDTO?> GetPersonById(long id)
        {
            Person? person = await _personRepository.GetPersonById(id);

            if (person == null)
                return null;

            PersonDTO personDTO = new PersonDTO(person.Id, 0, person.FirstName, person.LastName, person.Age, person.Birthday, person.Salary, (int)person.JobPosition);

            return personDTO;
        }
    }
}
