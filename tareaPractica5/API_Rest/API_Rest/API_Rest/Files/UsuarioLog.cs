using API_Rest.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.IO;
using System.Text.Json;

namespace API_Rest.Files
{
    public class UsuarioLog
    {
        private readonly string filepath = "historialLog.txt";

        public async Task<IActionResult> CrearRegistroUsersJson(UsuarioDTO usuario)
        {

            try
            {
                List<UsuarioDTO> listUsuarios = new List<UsuarioDTO>();

                if (File.Exists(filepath))
                {
                   
                    string jsonExistente = await File.ReadAllTextAsync(filepath);
                    if (!string.IsNullOrWhiteSpace(jsonExistente))
                    {
                        listUsuarios = JsonSerializer.Deserialize<List<UsuarioDTO>>(jsonExistente) ?? new List<UsuarioDTO>();
                    }
                }
                else
                {
                    
                    File.Create(filepath).Close();
                }


                listUsuarios.Add(usuario);

                var json = JsonSerializer.Serialize(listUsuarios, new JsonSerializerOptions { WriteIndented = true});

                await File.WriteAllTextAsync(filepath, json);

                return new OkObjectResult("Usuario regitrado en el historial");

            } catch (Exception ex)
            {
                return new ObjectResult($"Error al registrar el usuario en el json: {ex.Message}") { StatusCode = 500};
            }


        }
    }                                                                                                                       
}
