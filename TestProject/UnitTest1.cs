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
        public UnitTest1()
        {
            MockEntityRepository entity = new MockEntityRepository();
            IBaseRepository baseRepository = new BaseMockRepository(entity);            
            MockUserRepository mockUserRepository = new MockUserRepository(baseRepository, entity);
            IUserValidation userValidation = new UserValidation(mockUserRepository);

            _userService = new UserService(mockUserRepository, userValidation);
        }

        [Fact]
        public async Task InsertUserWhenAlreadyExistUserWithThisSameEmail()
        {           
            UserDTO user1DTO = new UserDTO("senha123", "user2@email.com", "123456789", "User1");
            UserDTO user2DTO = new UserDTO("outraSenha456", "user2@email.com", "987654321", "User2");

            await _userService.InsertUser(user1DTO);            

            var exception = await Assert.ThrowsAsync<TaskApplicatioException>(() => _userService.InsertUser(user2DTO));

            Assert.Equal(ExceptionMessages.EmailAlreadyExists, exception.Message);
        }

        [Fact]
        public async Task InsertUserWhenAlreadyExistUserWithThisSamePhone()
        {
            UserDTO user1DTO = new UserDTO("senha123", "user2@email.com", "123456789", "User1");
            UserDTO user2DTO = new UserDTO("outraSenha456", "user1@email.com", "123456789", "User2");

            await _userService.InsertUser(user1DTO);

            var exception = await Assert.ThrowsAsync<TaskApplicatioException>(() => _userService.InsertUser(user2DTO));

            Assert.Equal(ExceptionMessages.PhoneAlreadyExists, exception.Message);
        }
    }
}