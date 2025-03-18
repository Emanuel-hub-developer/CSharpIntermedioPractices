using API_Rest.DB;
using API_Rest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API_Rest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly API_RestContext _DbAPIRestContext;

        public ProductoController(API_RestContext DbAPIRestContext)
        {
            _DbAPIRestContext = DbAPIRestContext;
        }

        [Authorize]
        [HttpGet]
        [Route("obtenerProductos")]
        public IEnumerable<Models.Producto> GetProductos()
        {
            return _DbAPIRestContext.Productos.ToList();
        }

        [Authorize]
        [HttpPost]
        [Route("crearProducto")]
        public IActionResult CrearProducto([FromBody] DTOs.ProductoDTO nuevoProducto)
        {
            if (nuevoProducto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            var productoEntidad = new Models.Producto
            {
                Nombre = nuevoProducto.Nombre,
                Precio = nuevoProducto.Precio,
                Stock = nuevoProducto.Stock,
                idProveedor = nuevoProducto.IdProveedor,
                idCategoria = nuevoProducto.IdCategoria
            };

            
            _DbAPIRestContext.Productos.Add(productoEntidad);

            // Guardar los cambios en la base de datos
            _DbAPIRestContext.SaveChanges();

            // Devolver una respuesta exitosa
            return CreatedAtAction(nameof(CrearProducto), new { id = productoEntidad.Id }, productoEntidad);
        }

        [Authorize]
        [HttpPut]
        [Route("actualizarProducto")]
        public IActionResult ActualizarProducto(int id, [FromBody] DTOs.ProductoDTO productoActualizado)
        {
            if (productoActualizado == null)
            {
                return BadRequest("Los datos del producto no pueden ser nulos.");
            }

            // Buscar el producto por ID
            var productoExistente = _DbAPIRestContext.Productos.Find(id);

            if (productoExistente == null)
            {
                // Si no se encuentra el usuario, devolver un error 404
                return NotFound("producto no encontrado.");
            }

            // Actualizar los datos del usuario
            productoExistente.Nombre = productoActualizado.Nombre;
            productoExistente.Precio = productoActualizado.Precio;
            productoExistente.Stock = productoActualizado.Stock;
            productoExistente.idCategoria = productoActualizado.IdCategoria;
            productoExistente.idProveedor = productoActualizado.IdProveedor;


            // Guardar los cambios en la base de datos
            _DbAPIRestContext.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(new
            {
                productoExistente.Id,
                productoExistente.Nombre,
                productoExistente.Precio,
                productoExistente.Stock,
                productoExistente.idCategoria,
                productoExistente.idProveedor
            });
        }


        [HttpDelete("eliminarProducto/{id}")]
        public IActionResult EliminarProducto(int id)
        {
            
            var producto = _DbAPIRestContext.Productos.FirstOrDefault(u => u.Id == id);

            if (producto == null)
            {
                
                return NotFound(new { success = false, message = "producto no encontrado." });
            }

            // Eliminar el producto
            _DbAPIRestContext.Productos.Remove(producto);

            // Guardar los cambios en la base de datos
            _DbAPIRestContext.SaveChanges();

            // Devolver una respuesta exitosa
            return Ok(new { success = true, message = "Producto eliminado", result = producto });
        }

        [HttpGet]
        [Route("productos/estadisticas")]
        public IActionResult GetEstadisticaProductos()
        {
            var precioMasAlto = _DbAPIRestContext.Productos.Max(p => p.Precio);

            var productoMasCaro = _DbAPIRestContext.Productos
            .Where(p => p.Precio == precioMasAlto)
            .FirstOrDefault();

            var precioMasBajo = _DbAPIRestContext.Productos.Min(p => p.Precio);

            var productoMasBarato = _DbAPIRestContext.Productos
           .Where(p => p.Precio == precioMasBajo)
           .FirstOrDefault();

            var sumTotalPrecios = _DbAPIRestContext.Productos.Sum(p => p.Precio);

            var promedioPrecioProductos = _DbAPIRestContext.Productos.Average(p => p.Precio);

            var estadisticas = new
            {
                ProductoMasCaro = productoMasCaro != null ? new { productoMasCaro.Nombre, productoMasCaro.Precio } : null,
                ProductoMasBarato = productoMasBarato != null ? new { productoMasBarato.Nombre, productoMasBarato.Precio } : null,
                SumaTotalPrecios = sumTotalPrecios,
                PromedioPrecioProductos = promedioPrecioProductos
            };

            return Ok(estadisticas);
        }

        [HttpGet]
        [Route("productos/cantidadTotal")]
        public IActionResult GetCantidadTotal()
        {
            var cantidadTotal = _DbAPIRestContext.Productos.Count();

            return Ok($"Cantidad total productos registrados: {cantidadTotal}");
        }


        [HttpGet]
        [Route("productos/categoriaEspecifica")]
        public IActionResult GetCatEspecifica(string categoriaNombre)
        {
            var categoria = _DbAPIRestContext.Categorias
            .FirstOrDefault(c => c.Nombre == categoriaNombre);

            if (categoria == null)
            {
                return NotFound($"No se encontró una categoría con el nombre {categoriaNombre}.");
            }

            
                var productosCategoria = _DbAPIRestContext.Productos
                .Where(p => p.idCategoria == categoria.Id)
                .Select(p => new
                {
                    p.Nombre,
                    p.Precio,
                    p.Stock,
                    Proveedor = p.Proveedor.Nombre, 
                    Categoria = categoria.Nombre    
                })
                .ToList();

            if (productosCategoria.Count == 0)
            {
                return NotFound($"No se encontraron productos para la categoría {categoriaNombre}.");
            }

            return Ok(productosCategoria);
        }


        [HttpGet]
        [Route("productos/proveedorEspecifico")]
        public IActionResult GetProvEspecifico(string provNombre)
        {
            var proveedor = _DbAPIRestContext.Proveedores
            .FirstOrDefault(p => p.Nombre ==  provNombre);

            if (proveedor == null)
            {
                return NotFound($"No se encontró un proveedor con el nombre {provNombre}.");
            }

              var productosProveedor = _DbAPIRestContext.Productos
              .Where(p => p.idProveedor == proveedor.Id)
              .Select(p => new
              {
                  Proveedor = p.Proveedor.Nombre,
                  Contacto = p.Proveedor.Contacto,
                  Producto = p.Nombre,
                  p.Precio,
                  p.Stock,
                  Categoria = p.Categoria.Nombre
        
              })
              .ToList();

            return Ok(productosProveedor);
        }
    }

    }

