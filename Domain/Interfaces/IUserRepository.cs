using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetUserById(int id);
        public Task InsertUser(User user);
        public Task<User?> GetUserByEmail(string email);
        public Task<User?> GetUserByPhoneNumber(string phone);
    }
}
