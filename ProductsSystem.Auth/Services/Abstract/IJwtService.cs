
using System.Collections.Generic;
using System.Security.Claims;
using ProductsSystem.Auth.Models;

namespace ProductsSystem.Auth.Services.Abstract
{
    public interface IJwtService
    {
        string GenerateToken(IEnumerable<Claim> claims);
        ClaimsIdentity GetIdentityFromUser(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}