using System;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ProductsSystem.Auth.Services.Helpers
{
    public static class Hash
    {
        public static string Create(string value, string salt = "pIu4mf/0/OBdzPa7CmmY8Q==")
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                password: value,
                                salt: Encoding.UTF8.GetBytes(salt),
                                prf: KeyDerivationPrf.HMACSHA512,
                                iterationCount: 10000,
                                numBytesRequested: 256 / 8);
            return Convert.ToBase64String(valueBytes);
        }

        public static bool Validate(string value, string hash, string salt = "pIu4mf/0/OBdzPa7CmmY8Q==")
            => Create(value, salt) == hash;
    }
}