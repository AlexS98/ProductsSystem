namespace ProductsSystem.Auth.Models
{
    public class User : CommonModel
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}