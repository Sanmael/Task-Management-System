using Domain.DomainServices;
using Domain.Entitys;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tests.Repositories
{
    public class MockUserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly MockEntityRepository _entityRepository;
        public MockUserRepository(IBaseRepository baseRepository, MockEntityRepository mockEntityRepository)
        {
            _entityRepository = mockEntityRepository;
            _baseRepository = baseRepository;
        }

        public Task<User?> GetUserByEmail(string email)
        {
            List<BaseEntity> entities = _entityRepository.GetAllEntities();

            User? user = entities.OfType<User>().FirstOrDefault(x => x.Email == email);

            return Task.FromResult(user);
        }

        public Task<User?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByPhoneNumber(string phone)
        {
            List<BaseEntity> entities = _entityRepository.GetAllEntities();

            User? user = entities.OfType<User>().FirstOrDefault(x => x.Phone == phone);

            return Task.FromResult(user);
        }

        public async Task InsertUser(User user)
        {          
            await _baseRepository.InsertAsync(user);
        }
    }
}
