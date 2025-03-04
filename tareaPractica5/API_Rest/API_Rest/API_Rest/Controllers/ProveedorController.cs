using API_Rest.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Rest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        private readonly API_RestContext _context;
        public ProveedorController(API_RestContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("obtenerProveedores")]
        public IEnumerable<Models.Proveedor> GetProveedores()
        {
            return _context.Proveedores.ToList();
        }

        [HttpPost]
        [Route("crearProveedor")]
        public IActionResult CrearProveedor([FromBody] Models.Proveedor nuevoProveedor)
        {
            if (nuevoProveedor == null)
            {
                return BadRequest("El proveedor no puede ser nulo.");
            }

           
            _context.Proveedores.Add(nuevoProveedor);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return CreatedAtAction(nameof(CrearProveedor), new { id = nuevoProveedor.Id }, nuevoProveedor);
        }

        [HttpPut]
        [Route("actualizarProveedor/{id}")]
        public IActionResult ActualizarProveedor(int id, [FromBody] Models.Proveedor proveedorActualizado)
        {
            if (proveedorActualizado == null)
            {
                return BadRequest("Los datos del proveedor no pueden ser nulos.");
            }

           
            var proveedorExistente = _context.Proveedores.FirstOrDefault(u => u.Id == id);

            if (proveedorExistente == null)
            {
                
                return NotFound("proveedor no encontrado.");
            }

            
            proveedorExistente.Nombre = proveedorActualizado.Nombre;
            proveedorExistente.Contacto = proveedorActualizado.Contacto;
           

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(proveedorExistente);
        }

        [HttpDelete]
        [Route("eliminarProveedor/{id}")]
        public IActionResult EliminarProveedor(int id)
        {

            var proveedor = _context.Proveedores.FirstOrDefault(u => u.Id == id);

            if (proveedor == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound(new { success = false, message = "proveedor no encontrado." });
            }

            
            _context.Proveedores.Remove(proveedor);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(new { success = true, message = "Proveedor eliminado", result = proveedor });
        }
    }
}
