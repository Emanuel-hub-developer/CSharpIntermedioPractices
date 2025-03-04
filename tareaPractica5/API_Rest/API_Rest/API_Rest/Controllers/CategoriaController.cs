using API_Rest.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API_Rest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly API_RestContext _context;
        public CategoriaController(API_RestContext context)
        {
            _context = context;

        }


        [HttpGet]
        [Route("obtenerCategorias")]
        public IEnumerable<Models.Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }


        [HttpPost]
        [Route("crearCategoria")]
        public IActionResult CrearProveedor([FromBody] Models.Categoria nuevaCategoria)
        {
            if (nuevaCategoria == null)
            {
                return BadRequest("La categoria no puede ser nula.");
            }


            _context.Categorias.Add(nuevaCategoria);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return CreatedAtAction(nameof(CrearProveedor), new { id = nuevaCategoria.Id }, nuevaCategoria);
        }

        [HttpPut]
        [Route("actualizarCategoria/{id}")]
        public IActionResult ActualizarProveedor(int id, [FromBody] Models.Categoria categoriaActualizada)
        {
            if (categoriaActualizada == null)
            {
                return BadRequest("Los datos del proveedor no pueden ser nulos.");
            }


            var categoriaExistente = _context.Categorias.FirstOrDefault(u => u.Id == id);

            if (categoriaExistente == null)
            {
                return NotFound("categoria no encontrado.");
            }


            categoriaExistente.Nombre = categoriaActualizada.Nombre;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(categoriaActualizada);
        }

        [HttpDelete]
        [Route("eliminarCategoria/{id}")]
        public IActionResult EliminarProveedor(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(u => u.Id == id);

            if (categoria == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound(new { success = false, message = "categoria no encontrada." });
            }


            _context.Categorias.Remove(categoria);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(new { success = true, message = "Categoria eliminada", result = categoria });
        }
    }

}
