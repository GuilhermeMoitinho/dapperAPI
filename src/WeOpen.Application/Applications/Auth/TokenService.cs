using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeOpen.WebApi.Domain.Model.Entities;
using WeOpen.Application.Applications.Auth;
using WeOpen.Domain.Model.Entities;

namespace WeOpen.Application.Applications.Auth
{
    public class TokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Key);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]    
                {
                      new Claim("UsuarioCadastroId", usuario.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials
                                    (new SymmetricSecurityKey(key), 
                                     SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);

            return tokenHandler.WriteToken(token);
        }
    }
}
