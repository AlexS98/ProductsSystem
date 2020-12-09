using System;

namespace ProductsSystem.Auth.Models
{
    public class LoginHistory : CommonModel
    {
        public DateTimeOffset? LoginTimeUtc { get; set; }
        public string IpAddress { get; set; }
        public string Location { get; set; }
        public User User { get; set; }
    }
}