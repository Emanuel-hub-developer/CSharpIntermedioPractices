using API_Rest.DB;
using API_Rest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

