
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Rest.Custom;
using API_Rest.DTOs;
using Microsoft.AspNetCore.Authorization;
using API_Rest.DB;
using API_Rest.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security;
using System.IdentityModel.Tokens.Jwt;
using API_Rest.Files;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API_Rest.Controllers
{
    [Route("api/")]
    [AllowAnonymous]
    [ApiController]

    public class AccessController : ControllerBase
    {
        private readonly API_RestContext _dbAPIRestContext;
        private readonly Utilities _utilities;
        private readonly UsuarioLog _usuarioLog;

        public AccessController(API_RestContext dbAPIRestContext, Utilities utilidades)
        {
            _dbAPIRestContext = dbAPIRestContext;
            _usuarioLog = new UsuarioLog();
            _utilities = utilidades;

        }

        [HttpPost]
        [Route("auth/register")]
        public async Task<IActionResult> Registrarse(UsuarioDTO objeto)
        {
            var modeloUsuario = new Usuario
            {
                Nombre = objeto.Nombre,
                FechaDeNacimiento = objeto.FechaDeNacimiento,
                Correo = objeto.Correo,
                Clave = _utilities.encriptarSHA256(objeto.Clave)
            };

           await _dbAPIRestContext.Usuarios.AddAsync(modeloUsuario);
           var result =  await _dbAPIRestContext.SaveChangesAsync();

            if (result > 0)
            {
                
                var usuarioDTO = new UsuarioDTO
                {
                    Nombre = objeto.Nombre,
                    FechaDeNacimiento = objeto.FechaDeNacimiento,
                    Correo = objeto.Correo,
                    Clave = objeto.Clave 
                };

                var jsonResult = await _usuarioLog.CrearRegistroUsersJson(usuarioDTO);

                if (jsonResult is ObjectResult objectResult && objectResult.StatusCode != 200)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, message = "Usuario guardado en la base de datos, pero hubo un problema al guardar en el historial." });
                }

         
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, message = "Usuario registrado correctamente en la base de datos y en el historial." });
            }
            else
            {
                
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false, message = "No se pudo registrar el usuario en la base de datos." });
            }
        }


        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            try
            {


                var usuarioEncontrado = await _dbAPIRestContext.Usuarios
                                       .Where(u =>
                                       u.Correo == objeto.Correo &&
                                       u.Clave == _utilities.encriptarSHA256(objeto.Clave)
                                       ).FirstOrDefaultAsync();


                if (usuarioEncontrado == null)
                    return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });



                var jwtToken = _utilities.generateJWT(usuarioEncontrado);

                var refreshToken = _utilities.GenerateRefreshToken();


                // Guardar en la base de datos
                var historialToken = new HistorialRefreshToken
                {
                    UsuarioId = usuarioEncontrado.Id,
                    Token = jwtToken,
                    RefreshToken = refreshToken,
                    FechaCreacion = DateTime.UtcNow,
                    FechaExpiracion = DateTime.UtcNow.AddMinutes(3), // Refresh token válido por 3 minutos
                    EsActivo = true
                };




                _dbAPIRestContext.HistorialRefreshTokens.Add(historialToken);
                await _dbAPIRestContext.SaveChangesAsync();


                return Ok(new { Token = jwtToken, RefreshToken = refreshToken });
            }

            catch (DbUpdateException dbEx)
            {
                // Manejo de excepciones específicas de la base de datos
                var errorMessage = dbEx.InnerException != null ? dbEx.InnerException.Message : "Error desconocido al actualizar la base de datos.";
                Console.WriteLine($"Error al guardar en la base de datos: {errorMessage}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, message = errorMessage });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false, message = "Error inesperado al crear RefreshToken" });
            }
           

        }



        [HttpPost]
        [Route("auth/refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            var storedToken = await _dbAPIRestContext.HistorialRefreshTokens
            .FirstOrDefaultAsync(rt => rt.RefreshToken == refreshTokenDTO.RefreshToken);

            // Verificar si el token es nulo o ha expirado
            if (storedToken == null || storedToken.FechaExpiracion < DateTime.UtcNow)
            {
                return Unauthorized(new { message = "Refresh Token inválido o expirado." });
            }

            // Obtener el usuario asociado al refresh token
            var usuario = await _dbAPIRestContext.Usuarios.FirstOrDefaultAsync(u => u.Id == storedToken.UsuarioId);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Usuario no encontrado." });
            }

            // Generar un nuevo JWT
            var newJwtToken = _utilities.generateJWT(usuario);

            //Refrescar el Token
            var newRefreshToken = _utilities.GenerateRefreshToken();


            await _dbAPIRestContext.SaveChangesAsync();

            return Ok(new { Token = newJwtToken,RefreshToken = newRefreshToken });
        }


    }


}
