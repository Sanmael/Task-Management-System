using Domain.Entitys;

namespace Application.DTO
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public string NickName { get; set; } 

        public User ToEntity()
        {
            return new User(Password = Password, Email = Email, Phone = Phone, NickName = NickName);            
        }

        public UserDTO(string password, string email, string phone, string nickName)
        {
            Password = password;
            Email = email;
            Phone = phone;
            NickName = nickName;
        }
        public UserDTO()
        {            
        }

        public UserDTO(User user)
        {
            Id = user.Id;
            Password = user.Password;
            Email = user.Email;
            Phone = user.Phone;
            NickName = user.NickName;
        }
    }
}
