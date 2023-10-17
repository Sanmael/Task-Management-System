using Domain.Entitys;
using Domain.Interfaces;


namespace DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly IBaseRepository _baseRepository;

        public UserRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task InsertUser(User user)
        {
            await _baseRepository.InsertAsync(user);
        }
    }
}
