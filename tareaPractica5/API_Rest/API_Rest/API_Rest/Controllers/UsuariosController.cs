using API_Rest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_Rest.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuariosController : ControllerBase
    {

        private readonly DB.API_RestContext _context;

        public UsuariosController(DB.API_RestContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("listar")]
        public IEnumerable<Models.Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }


        [HttpGet]
        [Route("listar/{id}")]
        public IActionResult ListarUsuarioPorId(int id)
        {
            // Buscar el usuario por el ID
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound("Usuario no encontrado.");
            }

            // Si el usuario es encontrado, devolverlo con una respuesta 200 OK
            return Ok(usuario);
        }



        [HttpPost]
        [Route("crearUsuario")]
        public IActionResult GuardarUsuario([FromBody] Models.Usuario nuevoUsuario)
        {
            if (nuevoUsuario == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            // Verificar si ya existe un usuario con el mismo correo
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Correo == nuevoUsuario.Correo);

            if (usuarioExistente != null)
            {
                return Conflict("El correo electrónico ya está en uso.");
            }

            // Añadir el nuevo usuario al contexto
            _context.Usuarios.Add(nuevoUsuario);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return CreatedAtAction(nameof(GuardarUsuario), new { id = nuevoUsuario.Id }, nuevoUsuario);
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Models.Usuario usuarioActualizado)
        {
            if (usuarioActualizado == null)
            {
                return BadRequest("Los datos del usuario no pueden ser nulos.");
            }

            // Verificar si ya existe un usuario con el mismo correo, excluyendo al usuario que estamos actualizando
            var correoExistente = _context.Usuarios.FirstOrDefault(u => u.Correo == usuarioActualizado.Correo && u.Id != id);

            if (correoExistente != null)
            {
                return Conflict("El correo electrónico ya está en uso.");
            }

            // Buscar el usuario por ID
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioExistente == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound("Usuario no encontrado.");
            }

            // Actualizar los datos del usuario
            usuarioExistente.Nombre = usuarioActualizado.Nombre;
            usuarioExistente.Correo = usuarioActualizado.Correo;
            usuarioExistente.FechaDeNacimiento = usuarioActualizado.FechaDeNacimiento;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(usuarioExistente);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            // Buscar el usuario por ID
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound(new { success = false, message = "Usuario no encontrado." });
            }

            // Eliminar el usuario
            _context.Usuarios.Remove(usuario);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(new { success = true, message = "Usuario eliminado", result = usuario });
        }
    }
}
