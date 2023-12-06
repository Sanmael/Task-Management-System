using Domain.Entitys;
using Domain.Interfaces;
using Domain.ValidationExceptions;

namespace Domain.DomainServices
{
    public class UserValidation : IUserValidation
    {
        private readonly IUserRepository _userRepository;
        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task ValidateCreationNewUser(User user)
        {
            await EmailAvailabilityCheckAsync(user.Email);
            await PhoneAvailabilityCheckAsync(user.Phone);
        }
        public async Task EmailAvailabilityCheckAsync(string email)
        {
            User? user = await _userRepository.GetUserByEmail(email);

            if (user != null)
                throw new TaskDomainException(string.Format(ExceptionMessages.EmailAlreadyExists, user.Email));
        }
        public async Task PhoneAvailabilityCheckAsync(string phone)
        {
            User? user = await _userRepository.GetUserByPhoneNumber(phone);

            if (user != null)
                throw new TaskDomainException(string.Format(ExceptionMessages.PhoneAlreadyExists,user.Phone));
        }
    }
}
