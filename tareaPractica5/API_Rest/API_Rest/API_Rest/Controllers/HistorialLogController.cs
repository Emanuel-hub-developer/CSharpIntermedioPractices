using API_Rest.DTOs;
using API_Rest.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Rest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HistorialLogController : ControllerBase
    {
        private readonly string filepath = "historialLog.txt";

        [Authorize]
        [HttpGet]
        [Route("obtenerUsuariosDelJson")]
        public async Task<IActionResult> ObtenerUsuariosDelJson()
        {
            try
            {
                // Verifica si el archivo existe
                if (!System.IO.File.Exists(filepath))
                {
                    return NotFound("No hay usuarios registrados en el historial.");
                }

               
                string json = await System.IO.File.ReadAllTextAsync(filepath);

     
                if (string.IsNullOrWhiteSpace(json))
                {
                    return NotFound("No hay usuarios registrados en el historial.");
                }

                // Deserializa el JSON a una lista de usuarios
                var usuarios = JsonSerializer.Deserialize<List<UsuarioDTO>>(json);


                return Ok(usuarios);
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, $"Error al obtener los usuarios del json: {ex.Message}");
            }
        }
    }
    }
