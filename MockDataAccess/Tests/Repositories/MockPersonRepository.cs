using Domain.Entitys;
using Domain.Interfaces;


namespace MockDataAccess.Tests.Repositories
{
    public class MockPersonRepository : IPersonRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly GetMockRepository<Person> _getMockRepository;

        public MockPersonRepository(IBaseRepository baseRepository, MockEntityRepository entityRepository)
        {
            _baseRepository = baseRepository;            
            _getMockRepository = new GetMockRepository<Person>(entityRepository);
        }

        public Task<Person?> GetPersonById(long id)
        {
            Person? person = _getMockRepository.FindEntity(x=> x.Id == id);

            return Task.FromResult(person);
        }

        public async Task InsertPerson(Person person)
        {
            await _baseRepository.InsertAsync(person);
        }
    }
}
