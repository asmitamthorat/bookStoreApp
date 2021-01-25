using ModelLayer;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ServiceLayer.TokenAuthentication
{
    public interface ITokenManager
    {
        string GenerateToken(userRegistration account);
        ClaimsPrincipal GetPrincipal(string token);
        int ValidateToken(string token);
    }
}
