using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Back_End_WebAPI.Models;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Back_End_WebAPI.Utilities
{

    
    internal sealed class TokenProvider()
    {
        public string Create(User user)
        {
            string secretKey = "gpRK5SXay9ZGQ7rl7T1Yl98dZMHc4h8GC8O1XYeQdBlJG75SeG";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(JwtRegisteredClaimNames.Sub,user.UserID.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email,user.Email)
                    ]),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credentials,
                Issuer = "Back_End_WebAPI",
                Audience = "account"
            };

            var handler = new JsonWebTokenHandler();
            string token = handler.CreateToken(tokenDescriptor);
            return token;
        }
        


    }
}
