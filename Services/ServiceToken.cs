using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TrensManager.Models;

namespace TrensManager.Services
{
    public class ServiceToken
    {
        public static string GenerateToken(UserModel user)
        {
            // Codificando a nossa Secret
            byte[] key = Encoding.ASCII.GetBytes(Key.Secret);
            // Definindo algumas configurações do Token
            var tokenConfig = new SecurityTokenDescriptor
            {
                // Informando o que será salvo dentro do Token
                Subject = new ClaimsIdentity(new Claim[] {

                    new Claim("Id", user.Id.ToString()),
                    new Claim("Role", user.Role.ToString()),
                    new Claim("userName", user.UserName.ToString())
                }),
                // Informando o tempo de expiração do Token
                Expires = DateTime.UtcNow.AddHours(6),
                // Informando o tipo de criptografia que será utilizada
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // Criando o Token de fato
            var tokenHandler = new JwtSecurityTokenHandler();
            string token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenConfig));
            return token;
        }
    }
}
