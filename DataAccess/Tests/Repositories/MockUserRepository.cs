using Domain.DomainServices;
using Domain.Entitys;
using Domain.Interfaces;
using static Slapper.AutoMapper;


namespace DataAccess.Tests.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;        
        private readonly GetMockRepository<User> _getMockRepository;

        public MockUserRepository(IBaseRepository baseRepository, MockEntityRepository entityRepository)
        {
            _baseRepository = baseRepository;
            _getMockRepository = new GetMockRepository<User>(entityRepository);
        }

        public Task<User?> GetUserByEmail(string email)
        {
            User? entity = _getMockRepository.FindEntity(x => x.Email == email);
            return Task.FromResult(entity);
        }

        public Task<User?> GetUserById(long id)
        {
            User? entity = _getMockRepository.FindEntity(x => x.Id == id);
            return Task.FromResult(entity);
        }

        public Task<User?> GetUserByPhoneNumber(string phone)
        {
            User? entity = _getMockRepository.FindEntity(x => x.Phone == phone);
            return Task.FromResult(entity);
        }

        public async Task InsertUser(User user)
        {          
            await _baseRepository.InsertAsync(user);
        }
    }
}
