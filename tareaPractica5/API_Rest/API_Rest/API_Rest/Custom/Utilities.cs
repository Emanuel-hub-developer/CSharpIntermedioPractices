
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API_Rest.DB;
using API_Rest.Models;
using System.Security;
using Microsoft.EntityFrameworkCore;
using API_Rest.DTOs;

namespace API_Rest.Custom
{
    public class Utilities 
    {
        private readonly IConfiguration _configuration;
        public Utilities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        


        public string encriptarSHA256(string texto)
        {
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //Computar Hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));


                //Convertir array de bytes a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i< bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("X2"));
                }

                return builder.ToString();  
            }

        }

       

        public string generateJWT(Usuario modelo)
        {
            //Crear la informacion del usuario para el token

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,modelo.Id.ToString()),
                new Claim(ClaimTypes.Name,modelo.Nombre!),
                new Claim(ClaimTypes.Email,modelo.Correo!),
                 new Claim(ClaimTypes.DateOfBirth, modelo.FechaDeNacimiento.ToString("yyyy-MM-dd") ?? "")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            //Crear detalle del token
            var jwtConfig = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
        }


        public string GenerateRefreshToken()
        {
            var byteArray = new byte[64];

            var refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);

                refreshToken = Convert.ToBase64String(byteArray);
            }

            return refreshToken;
        }

    }


}
