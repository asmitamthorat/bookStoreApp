using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer;
using System;
using System.Collections.Generic;

using System.Security.Claims;
using System.Text;
using ServiceLayer.TokenAuthentication;
using System.IdentityModel.Tokens.Jwt;

namespace ServiceLayer.TokenAuthentication
{
    public class TokenManager:ITokenManager
    {
        private JwtSecurityTokenHandler tokenHandler;
        private byte[] secretKey;
        private string token;

        public TokenManager(IConfiguration cofiguration)
        {
            tokenHandler = new JwtSecurityTokenHandler();
            secretKey = Encoding.ASCII.GetBytes(cofiguration.GetSection("JwtSecretKey").Value);
        }

        public string GenerateToken(userRegistration account)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Email,  account.email),
            new Claim(ClaimTypes.UserData, account.userId.ToString()),
            new Claim(ClaimTypes.Role, account.role)
            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return token;
        }

        public ClaimsPrincipal GetPrincipal(String token)
        {
            var claims = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.FromMinutes(120000)
            }, out SecurityToken validatedToken);
            return claims;
        }

        public int ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token);
            ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;
            Claim userNameClaim = identity.FindFirst(ClaimTypes.UserData);
            string AccountId = userNameClaim.Value;
            return Int32.Parse(AccountId);
        }
    }
}
