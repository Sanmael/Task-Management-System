using Dapper;
using Domain.Entitys;
using Domain.Interfaces;
using static Slapper.AutoMapper;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly ISession _session;
        public UserRepository(IBaseRepository baseRepository, ISession session)
        {
            _baseRepository = baseRepository;
            _session = session;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            string query = "SELECT * FROM USER WHERE EMAIL = @email";
            return await _session.Connection.ExecuteScalarAsync<User>(sql: query, email);
        }

        public async Task<User?> GetUserById(int id)
        {
            string query = "SELECT * FROM USER WHERE USERID = @id";
            return await _session.Connection.ExecuteScalarAsync<User>(sql: query, id);
        }

        public async Task<User?> GetUserByPhoneNumber(string phone)
        {
            string query = "SELECT * FROM USER WHERE PHONE = @phone";
            return await _session.Connection.ExecuteScalarAsync<User>(sql: query, phone);
        }

        public async Task InsertUser(User user)
        {
            await _baseRepository.InsertAsync(user);
        }
    }
}
