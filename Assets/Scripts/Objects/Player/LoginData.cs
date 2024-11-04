namespace Player.DTO
{
    public class LoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginData(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
