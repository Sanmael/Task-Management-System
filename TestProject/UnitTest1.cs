using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Domain.DomainServices;
using Domain.Interfaces;
using Domain.ValidationExceptions;
using MockDataAccess.Tests.BaseRepository;
using MockDataAccess.Tests.Repositories;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly IUserService _userService;
        private long userId;
        public UnitTest1()
        {
            MockEntityRepository entity = new MockEntityRepository();
            IBaseRepository baseRepository = new BaseMockRepository(entity);
            MockUserRepository mockUserRepository = new MockUserRepository(baseRepository, entity);
            IUserValidation userValidation = new UserValidation(mockUserRepository);

            _userService = new UserService(mockUserRepository, userValidation);
        }
      
    }
}