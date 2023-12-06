namespace FrontEnd.Models
{
    public record UserModel
    {     
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
    }
}
