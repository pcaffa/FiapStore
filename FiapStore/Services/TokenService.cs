using FiapStore.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FiapStore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler(); // gera o token

            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Secret")); //array de bytes

            // descreve td que o token tem
            var tokenDescriptior = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] //nossas permissoes
                {
                    //nunca passar informações sensiveis, ex senhas, documentos
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Permission.ToString()),
                    new Claim("Id", user.Id.ToString()) //podemos criar nosso proprio claimtype
                }),

                Expires = DateTime.UtcNow.AddHours(8), // validade do token será de 8h após o login
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptior);
            return tokenHandler.WriteToken(token);
        }
    }
}
