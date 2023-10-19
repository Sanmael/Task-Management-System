using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entitys;
using Domain.Interfaces;
using Domain.ValidationExceptions;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidation _userValidation;

        public UserService(IUserRepository userRepository, IUserValidation userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }

        public async Task InsertUser(UserDTO userDTO)
        {
            try
            {
                User user = userDTO.ToEntity();
                await _userValidation.ValidateCreationNewUser(user);
                await _userRepository.InsertUser(user);
                userDTO.Id = user.Id;
            }
            catch (TaskDomainException ex)
            {
                throw new TaskApplicatioException(ex.Message);
            }
        }
        public async Task<UserDTO?> GetUserById(long id)
        {
            User? user = await _userRepository.GetUserById(id);

            if (user == null)
                return null;

            UserDTO userDTO = new UserDTO()
            {
                Id = id,
                NickName = user.NickName,
                Password = user.Password,
                Email = user.Email,
                Phone = user.Phone,
            };

            return userDTO;
        }
    }
}
