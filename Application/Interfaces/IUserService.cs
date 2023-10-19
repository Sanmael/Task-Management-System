﻿using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        public Task InsertUser(UserDTO userDTO);
        public Task<UserDTO?> GetUserById(long id);
    }
}
