using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task<IBaseResponse> InsertUserAsync(UserDTO userDTO);
        public Task<UserDTO?> GetUserById(long id);
    }
}
