using Domain.Entitys;

namespace Application.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Password { get; set; } = string.Empty!;
        public string Email { get; set; } = string.Empty!;
        public string Phone { get; set; } = string.Empty!;
        public string NickName { get; set; } = string.Empty!;

        public User ToEntity()
        {
            return new User(Password = Password, Email = Email, Phone = Phone, NickName = NickName);            
        }
    }
}
