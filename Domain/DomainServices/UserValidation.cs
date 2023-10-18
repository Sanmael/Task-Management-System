using Domain.Entitys;
using Domain.Interfaces;
using Domain.ValidationExceptions;

namespace Domain.DomainServices
{
    public class UserValidation
    {
        private readonly IUserRepository _userRepository;
        public UserValidation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailAvailabilityCheckAsync(string email)
        {
            User? user = await _userRepository.GetUserByEmail(email);

            if (user != null)
                throw new DomainException(ExceptionMessages.EmailAlreadyExists);
        }
        public async Task PhoneAvailabilityCheckAsync(string phone)
        {
            User? user = await _userRepository.GetUserByPhoneNumber(phone);

            if (user != null)
                throw new DomainException(ExceptionMessages.PhoneAlreadyExists);
        }
    }
}
