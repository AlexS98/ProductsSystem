using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductsSystem.Auth.Database;
using ProductsSystem.Auth.Models;
using ProductsSystem.Auth.Services.Abstract;

namespace ProductsSystem.Auth.Services
{
    public class JwtService : IJwtService
    {
        private readonly DbSet<User> _userSet;
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration, AuthDbContext context)
        {
            _configuration = configuration;
            _userSet = context.Users;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:KEY"]));
            var jwt = new JwtSecurityToken(
                issuer: _configuration["Auth:ISSUER"],
                audience: _configuration["Auth:AUDIENCE"],
                notBefore: DateTime.Now,
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Auth:LIFETIME"])),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Auth:KEY"])),
                    SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public ClaimsIdentity GetIdentityFromUser(User user)
        {
            if (user == null) 
            {
                return null;
            }
            
            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
        
        public ClaimsIdentity GetAdminIdentity(User user)
        {
            throw new NotImplementedException("Admin role not implemented");
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:KEY"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }
}