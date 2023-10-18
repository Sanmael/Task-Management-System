
namespace Domain.Entitys
{
    public class User : BaseEntity
    {
        public string NickName { get; private set; } 
        public string Password { get; private set; }
        public string Email { get; private set; } 
        public string Phone { get; private set; }                          
        public User(string password, string email, string phone, string nickName)
        {            
            Password = password;
            Email = email;
            Phone = phone;
            NickName = nickName;      
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
        public User(long id, DateTime creationDate, DateTime updateDate, string password, string email, string phone, string nickName)
        {
            Id = id;
            CreationDate = creationDate;
            UpdateDate = updateDate;
            Password = password;
            Email = email;
            Phone = phone;
            NickName = nickName;
        }
        public void ReseteUserNickName(string nickName)
        {
            NickName = nickName;
            UpdateDate = DateTime.Now;
        }
        public void UpdateUserEmail(string email)
        {
            Email = email;
            UpdateDate = DateTime.Now;
        }
        public void ResetePassword(string password)
        {
            Password = password;
            UpdateDate= DateTime.Now;
        }
        public void UpdatePhone(string phone)
        {
            Phone = phone;
            UpdateDate= DateTime.Now;
        }
    }
}
