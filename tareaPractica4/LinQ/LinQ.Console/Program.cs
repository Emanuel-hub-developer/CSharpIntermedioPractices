
using LinQ.Console;
using System.ComponentModel;
using System.Linq;
using static LinQ.Console.Producto;

          List<Producto> listaProductos = new List<Producto>()
        {
         //----50 Productos Agregados Manualmente
            new Producto { Id = 1, Nombre = "Laptop", Descripcion = "Laptop potente", Precio = 1200, Stock = 15, Categoria = "Electrónica", FechaCreacion = new DateTime(2022, 12, 20) },
            new Producto { Id = 2, Nombre = "Celular", Descripcion = "Celular de alta gama", Precio = 900, Stock = 8, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 1, 15) },
            new Producto { Id = 3, Nombre = "Auriculares", Descripcion = "Auriculares con cancelación de ruido", Precio = 250, Stock = 25, Categoria = "Audio", FechaCreacion = new DateTime(2023, 3, 10) },
            new Producto { Id = 4, Nombre = "Teclado", Descripcion = "Teclado mecánico", Precio = 150, Stock = 5, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 5, 5) },
            new Producto { Id = 5, Nombre = "Monitor", Descripcion = "Monitor 4K", Precio = 600, Stock = 12, Categoria = "Electrónica", FechaCreacion = new DateTime(2022, 12, 20) },
            new Producto { Id = 6, Nombre = "Disco Duro", Descripcion = "Almacenamiento de 2TB", Precio = 180, Stock = 30, Categoria = "Almacenamiento", FechaCreacion = new DateTime(2023, 4, 20) },
            new Producto { Id = 7, Nombre = "Mouse", Descripcion = "Mouse inalámbrico", Precio = 90, Stock = 50, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 2, 18) },
            new Producto { Id = 8, Nombre = "Impresora", Descripcion = "Impresora multifuncional", Precio = 400, Stock = 6, Categoria = "Oficina", FechaCreacion = new DateTime(2023, 6, 11) },
            new Producto { Id = 9, Nombre = "Router", Descripcion = "Router de alta velocidad", Precio = 200, Stock = 20, Categoria = "Redes", FechaCreacion = new DateTime(2023, 7, 5) },
            new Producto { Id = 10, Nombre = "Cámara", Descripcion = "Cámara profesional", Precio = 750, Stock = 10, Categoria = "Fotografía", FechaCreacion = new DateTime(2022, 12, 20) },
            new Producto { Id = 11, Nombre = "Televisor", Descripcion = "Televisor OLED", Precio = 1500, Stock = 4, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 8, 21) },
            new Producto { Id = 12, Nombre = "Parlantes", Descripcion = "Sistema de sonido envolvente", Precio = 500, Stock = 18, Categoria = "Audio", FechaCreacion = new DateTime(2023, 9, 14) },
            new Producto { Id = 13, Nombre = "Consola", Descripcion = "Consola de videojuegos", Precio = 550, Stock = 9, Categoria = "Juegos", FechaCreacion = new DateTime(2023, 10, 30) },
            new Producto { Id = 14, Nombre = "SSD", Descripcion = "Unidad de estado sólido 1TB", Precio = 250, Stock = 22, Categoria = "Almacenamiento", FechaCreacion = new DateTime(2023, 11, 1) },
            new Producto { Id = 15, Nombre = "Fuente de Poder", Descripcion = "Fuente de 750W", Precio = 130, Stock = 15, Categoria = "Componentes", FechaCreacion = new DateTime(2023, 5, 5) },
            new Producto { Id = 16, Nombre = "Microondas", Descripcion = "Microondas digital", Precio = 200, Stock = 10, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 2, 14) },
            new Producto { Id = 17, Nombre = "Refrigerador", Descripcion = "Refrigerador inteligente", Precio = 1300, Stock = 5, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 1, 30) },
            new Producto { Id = 18, Nombre = "Horno", Descripcion = "Horno eléctrico", Precio = 450, Stock = 8, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2022, 12, 10) },
            new Producto { Id = 19, Nombre = "Lámpara", Descripcion = "Lámpara LED", Precio = 80, Stock = 40, Categoria = "Iluminación", FechaCreacion = new DateTime(2023, 4, 5) },
            new Producto { Id = 20, Nombre = "Bocinas", Descripcion = "Bocinas Bluetooth", Precio = 220, Stock = 15, Categoria = "Audio", FechaCreacion = new DateTime(2023, 1, 10) },
            new Producto { Id = 21, Nombre = "Cargador", Descripcion = "Cargador rápido USB-C", Precio = 50, Stock = 25, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 6, 20) },
            new Producto { Id = 22, Nombre = "Router", Descripcion = "Router de alta velocidad", Precio = 200, Stock = 20, Categoria = "Redes", FechaCreacion = new DateTime(2023, 7, 5) },
            new Producto { Id = 23, Nombre = "Licuadora", Descripcion = "Licuadora de alta potencia", Precio = 120, Stock = 14, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 3, 5) },
            new Producto { Id = 24, Nombre = "Cafetera", Descripcion = "Cafetera programable", Precio = 180, Stock = 11, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 4, 12) },
            new Producto { Id = 25, Nombre = "Smartwatch", Descripcion = "Reloj inteligente", Precio = 300, Stock = 13, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 5, 8) },
            new Producto { Id = 26, Nombre = "Freidora de Aire", Descripcion = "Air Frier", Precio = 450, Stock = 7, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 6, 2) },
            new Producto { Id = 27, Nombre = "Bicicleta", Descripcion = "Bicicleta de montaña", Precio = 850, Stock = 9, Categoria = "Deportes", FechaCreacion = new DateTime(2023, 7, 10) },
            new Producto { Id = 28, Nombre = "Smartphone", Descripcion = "Smartphone con pantalla OLED", Precio = 1000, Stock = 20, Categoria = "Electrónica", FechaCreacion = new DateTime(2022, 11, 1) },
            new Producto { Id = 29, Nombre = "Laptop Gaming", Descripcion = "Laptop para videojuegos de alto rendimiento", Precio = 2000, Stock = 10, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 1, 5) },
            new Producto { Id = 30, Nombre = "Micrófono", Descripcion = "Micrófono de condensador", Precio = 150, Stock = 30, Categoria = "Audio", FechaCreacion = new DateTime(2023, 2, 10) },
            new Producto { Id = 31, Nombre = "Mouse Gaming", Descripcion = "Mouse con sensores de alta precisión", Precio = 90, Stock = 45, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 3, 25) },
            new Producto { Id = 32, Nombre = "Proyector", Descripcion = "Proyector Full HD", Precio = 650, Stock = 12, Categoria = "Electrónica", FechaCreacion = new DateTime(2022, 10, 20) },
            new Producto { Id = 33, Nombre = "Teclado Inalámbrico", Descripcion = "Teclado compacto con conexión Bluetooth", Precio = 120, Stock = 35, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 4, 15) },
            new Producto { Id = 34, Nombre = "SSD 512GB", Descripcion = "Unidad de almacenamiento rápido", Precio = 100, Stock = 50, Categoria = "Almacenamiento", FechaCreacion = new DateTime(2023, 5, 5) },
            new Producto { Id = 35, Nombre = "Bocinas Bluetooth", Descripcion = "Bocinas portátiles con Bluetooth", Precio = 80, Stock = 60, Categoria = "Audio", FechaCreacion = new DateTime(2023, 6, 11) },
            new Producto { Id = 36, Nombre = "Router Mesh", Descripcion = "Sistema de router de malla para mejor cobertura", Precio = 350, Stock = 15, Categoria = "Redes", FechaCreacion = new DateTime(2023, 7, 20) },
            new Producto { Id = 37, Nombre = "Cámara Digital", Descripcion = "Cámara digital de alta definición", Precio = 800, Stock = 8, Categoria = "Fotografía", FechaCreacion = new DateTime(2023, 3, 10) },
            new Producto { Id = 38, Nombre = "Televisor 8K", Descripcion = "Televisor ultra alta definición", Precio = 5000, Stock = 3, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 8, 21) },
            new Producto { Id = 39, Nombre = "Altavoces Inalámbricos", Descripcion = "Altavoces con conectividad Bluetooth", Precio = 300, Stock = 22, Categoria = "Audio", FechaCreacion = new DateTime(2023, 9, 15) },
            new Producto { Id = 40, Nombre = "Consola PS5", Descripcion = "Consola de videojuegos PlayStation 5", Precio = 900, Stock = 5, Categoria = "Juegos", FechaCreacion = new DateTime(2023, 6, 5) },
            new Producto { Id = 41, Nombre = "Almacenamiento Externo 4TB", Descripcion = "Disco duro externo de 4TB", Precio = 200, Stock = 12, Categoria = "Almacenamiento", FechaCreacion = new DateTime(2023, 7, 18) },
            new Producto { Id = 42, Nombre = "Fuente de Poder 850W", Descripcion = "Fuente de poder para PC de 850W", Precio = 180, Stock = 25, Categoria = "Componentes", FechaCreacion = new DateTime(2023, 5, 25) },
            new Producto { Id = 43, Nombre = "Smartwatch 2.0", Descripcion = "Reloj inteligente con pantalla AMOLED", Precio = 250, Stock = 40, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 3, 30) },
            new Producto { Id = 44, Nombre = "Horno de Microondas", Descripcion = "Microondas con funciones automáticas", Precio = 180, Stock = 20, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 2, 7) },
            new Producto { Id = 45, Nombre = "Lavadora", Descripcion = "Lavadora automática con capacidad de 10kg", Precio = 650, Stock = 10, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 4, 20) },
            new Producto { Id = 46, Nombre = "Batidora", Descripcion = "Batidora de mano con varias velocidades", Precio = 70, Stock = 30, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 5, 15) },
            new Producto { Id = 47, Nombre = "Secadora de Ropa", Descripcion = "Secadora de ropa con capacidad de 8kg", Precio = 400, Stock = 8, Categoria = "Electrodomésticos", FechaCreacion = new DateTime(2023, 6, 1) },
            new Producto { Id = 48, Nombre = "Reproductor de DVD", Descripcion = "Reproductor de DVD con conexión HDMI", Precio = 40, Stock = 50, Categoria = "Electrónica", FechaCreacion = new DateTime(2023, 5, 30) },
            new Producto { Id = 49, Nombre = "Cámara de Seguridad", Descripcion = "Cámara de vigilancia con visión nocturna", Precio = 120, Stock = 35, Categoria = "Seguridad", FechaCreacion = new DateTime(2023, 4, 12) },
            new Producto { Id = 50, Nombre = "Bicicleta Eléctrica", Descripcion = "Bicicleta eléctrica de montaña", Precio = 1200, Stock = 6, Categoria = "Deportes", FechaCreacion = new DateTime(2023, 7, 15) },
            new Producto { Id = 51, Nombre = "Mochila Antirrobo", Descripcion = "Mochila con sistema antirrobo", Precio = 100, Stock = 50, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 1, 20) },
            new Producto { Id = 52, Nombre = "Silla Gaming", Descripcion = "Silla ergonómica para gamers", Precio = 250, Stock = 18, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 8, 2) },
            new Producto { Id = 53, Nombre = "Cargador Solar", Descripcion = "Cargador solar portátil", Precio = 50, Stock = 40, Categoria = "Accesorios", FechaCreacion = new DateTime(2023, 6, 25) },
            new Producto { Id = 54, Nombre = "Camara GoPro", Descripcion = "Cámara deportiva GoPro", Precio = 400, Stock = 14, Categoria = "Fotografía", FechaCreacion = new DateTime(2023, 5, 12) }

    };


//EJERCICIOS

// 1. Obtener todos los productos de la lista.

foreach (var producto in listaProductos)
{
    Console.WriteLine($"Nombre: {producto.Nombre} | Descripcion: {producto.Descripcion} | Precio: {producto.Precio} | Stock: {producto.Stock} | Categoria: {producto.Categoria} | Fecha Creacion: {producto.FechaCreacion}");
}



//2.Obtener los nombres de todos los productos.

foreach (var producto in listaProductos)
{
    Console.WriteLine($"Nombre: {producto.Nombre}");
}


//3.Obtener los productos cuyo precio sea mayor a 500.

var productosMayorA500 = listaProductos.Where(p => p.Precio > 500);

foreach (var mayorA500 in productosMayorA500)
{
    Console.WriteLine($"Producto: {mayorA500.Nombre} | Precio: {mayorA500.Precio}");
}


//4.Obtener los productos con stock menor a 10.


var menorA10 = listaProductos.Where(p => p.Stock < 10);

foreach (var menorStock in menorA10)
{
    Console.WriteLine($"Producto: {menorStock.Nombre} | Stock: {menorStock.Stock}");
}

//5.Obtener los productos de la categoría "Electrónica".

var categoriaElectronica = listaProductos.Where(p=>p.Categoria.Contains("Electrónica"));
foreach (var catElectronica in categoriaElectronica)
{
    Console.WriteLine($"{catElectronica.Nombre} | Categoria: {catElectronica.Categoria}");
}


// 6. Obtener los productos cuyo nombre comience con la letra 'L'.

var containL = listaProductos.Where(p => p.Nombre.StartsWith("L"));

foreach (var contL in containL)
{
    Console.WriteLine($"Producto: {contL.Nombre}");
}

// 7. Obtener los productos cuyo precio esté entre 100 y 500.

var precioEntre = listaProductos.Where(p => p.Precio >= 100 && p.Precio <= 500);

foreach (var precEntre in precioEntre)
{
    Console.WriteLine($"{precEntre.Nombre } | Precio: {precEntre.Precio}");
}



// 8. Obtener los productos ordenados por precio ascendente.

var ordenAsc = listaProductos.OrderBy(p => p.Precio);

foreach (var orderAsc in listaProductos)
{
    Console.WriteLine($"{orderAsc.Nombre} | Precio: {orderAsc.Precio}");
}



// 9. Obtener los productos ordenados por precio descendente.

var ordenDesc = listaProductos.OrderByDescending(p => p.Precio);

foreach (var orderDsc in listaProductos)
{
    Console.WriteLine($"{orderDsc.Nombre} | Precio: {orderDsc.Precio}");
}

// 10. Obtener los productos ordenados por nombre en orden alfabético.

var productoAsc = listaProductos.OrderBy(p => p.Nombre);

foreach (var productAsc in listaProductos)
{
    Console.WriteLine($"{productAsc.Nombre}");
}



// 11. Obtener los productos ordenados por stock de mayor a menor.


var StockAsc = listaProductos.OrderBy(p => p.Stock);

foreach (var stockAsc in listaProductos)
{
    Console.WriteLine($"{stockAsc.Nombre} Stock: {stockAsc.Stock}");
}



// 12. Obtener los primeros 5 productos más caros.


var masCaro = listaProductos
    .OrderByDescending(p => p.Precio)
    .Take(5);

foreach (var mascaro in listaProductos)
{
    Console.WriteLine($"{mascaro.Nombre} Precio: {mascaro.Precio}");
}

// 13. Obtener los 10 productos con menor stock.


var mStock = listaProductos.OrderBy(p => p.Stock).Take(10);

foreach (var meStock in mStock)
{
    Console.WriteLine($"{meStock.Nombre} Stock: {meStock.Stock}");
}


// 14. Obtener la cantidad total de productos en la lista.


 var totalProductos = listaProductos.Count;
 Console.WriteLine($"La cantidad total de productos es: {totalProductos}");



// 15. Obtener la suma de todos los precios de los productos.


var SumTotal = listaProductos.Sum(p => p.Precio);

Console.WriteLine($"La suma total de todos los precios es: {SumTotal}");



// 16. Obtener el precio promedio de los productos.

var promedioProductos = listaProductos.Average(p => p.Precio);

Console.WriteLine($"El promedio de los precios de los productos es: {promedioProductos}");


// 17. Obtener el producto más caro.

var productoCaro = listaProductos.OrderByDescending(p => p.Precio).FirstOrDefault();

Console.WriteLine($"El producto mas caro es: {productoCaro?.Nombre} Precio: {productoCaro?.Precio}");


// 18. Obtener el producto más barato.

var productoBarato = listaProductos.OrderBy(p => p.Precio).FirstOrDefault();

Console.WriteLine($"El producto mas barato es: {productoBarato?.Nombre} |  Precio: {productoBarato?.Precio}");



// 19. Verificar si hay algún producto con precio mayor a 1000.

var mayorA1000 = listaProductos.Any(p => p.Precio > 1000);

 if (mayorA1000 == false)
{
    Console.WriteLine("No hay productos mayor a 1000");
} else
{
    Console.WriteLine("Si hay productos mayor a 1000");
}


// 20. Verificar si todos los productos tienen stock mayor a 5.


var mayorAMil= listaProductos.All(p => p.Stock > 5);

 if (mayorAMil == false)
{
    Console.WriteLine("No todos los productos tienen un Stock mayor a 5");
} else
{
    Console.WriteLine("Todos los productos tienen Stock mayor a 5");
}


// 21. Contar cuántos productos hay en la categoría "Audio".

var contAudio = listaProductos.Count(p => p.Categoria == "Audio");
Console.WriteLine($"Hay {contAudio} productos en la categoria de audio. ");



// 22. Agrupar los productos por categoría.

 var agruparCat = listaProductos.GroupBy(p=> p.Categoria).ToList();

Console.WriteLine("Las categorias de los grupos son: ");
foreach (var cat in agruparCat)
{
    Console.WriteLine($"{cat.Key}");
}


// 23. Obtener la categoría con más productos.


var catConMasproductos = listaProductos.GroupBy(p => p.Categoria)
                                       .OrderByDescending(g => g.Count())
                                       .FirstOrDefault();

if(catConMasproductos != null)
{
    Console.WriteLine($"Categoría con más productos: {catConMasproductos.Key} ({catConMasproductos.Count()} productos)");
}
else
{
    Console.WriteLine("No hay productos en la lista.");
}


// 24. Obtener el stock total de todos los productos.


var stockTotal = listaProductos.Sum(p => p.Stock);

Console.WriteLine($"El stock total de todos los productos es: {stockTotal}");


// 25. Obtener el producto con el nombre más largo.

 var nombreMasLargo = listaProductos.OrderByDescending(p => p.Nombre.Length).FirstOrDefault();

Console.WriteLine($"El producto con el nombre mas largo es: {nombreMasLargo.Nombre} ({nombreMasLargo.Nombre.Length} caracteres)");


// 26. Obtener el producto con la descripción más corta.


var descripcionMasCorta = listaProductos.OrderBy(p => p.Nombre.Length).FirstOrDefault();

Console.WriteLine($"El producto con la descripcion mas corta es: {descripcionMasCorta.Descripcion} ({descripcionMasCorta.Descripcion.Length} caracteres)");



// 27. Filtrar los productos cuya descripción contenga la palabra "pantalla".


var contgPantalla = listaProductos.Where(p => p.Descripcion.Contains("pantalla")).ToList();

foreach (var contg in contgPantalla)
{
    Console.WriteLine($"{contg.Nombre} | Descripcion: {contg.Descripcion}");
}



// 28. Obtener el promedio de stock de los productos de la categoría "Almacenamiento".



var promStockCat = listaProductos.Where(p => p.Categoria == "Almacenamiento")
                                  .Select(p => p.Stock)
                                  .DefaultIfEmpty(0)
                                  .Average();

Console.WriteLine($"El promedio de stock de los productos de la categoria 'Almacenamiento' es: {promStockCat} ");




// 29. Obtener los productos creados en una fecha específica (20/12/2022).


 var porFecha = listaProductos.Where(p => p.FechaCreacion.Date == new DateTime(2022, 12, 20)).ToList();

foreach (var fecha in porFecha)
{
    Console.WriteLine($"{fecha.Nombre} | FechaCreacion: {fecha.FechaCreacion}");
}



// 30. Obtener los productos cuya ID sea par.

var parId = listaProductos.Where(p=> p.Id % 2 == 0).ToList();

foreach (var par in parId)
{
    Console.WriteLine($"Id: {par.Id} | {par.Nombre}");
}


// 31. Obtener los productos cuya ID sea impar.

var imparId = listaProductos.Where(p => p.Id % 2 != 0).ToList();

foreach (var impar in imparId)
{
    Console.WriteLine($"Id: {impar.Id} | {impar.Nombre}");
}

// 32. Obtener los productos cuyo precio tenga un decimal mayor a .50.


var conDecimal = listaProductos.Where(p => (p.Precio % 1) > 0.50m).ToList();

foreach (var cnDecimal in conDecimal)
{
    Console.WriteLine($"{cnDecimal.Nombre} | Precio: {cnDecimal.Precio}");
}


// 33. Obtener los productos cuyo nombre tenga más de 10 caracteres.


 var nombreMasCaract = listaProductos.Where(p => p.Nombre.Length > 10).ToList();

 foreach (var caract  in nombreMasCaract)
{
    Console.WriteLine($"{caract.Nombre}");
}



// 34. Obtener los productos cuyo stock sea un número primo.

bool EsPrimo(int numero)
{
    if (numero < 2) return false;
    for (int i = 2; i * i <= numero; i++)
    {
        if (numero % i == 0) return false;
    }
    return true;
}

var productosStockPrimo = listaProductos
    .Where(p => EsPrimo(p.Stock))
    .ToList();

foreach (var prodct in productosStockPrimo) 
{
    Console.WriteLine($"{prodct.Nombre} | Stock: {prodct.Stock}");
}


// 35. Obtener los productos cuyo nombre contenga la palabra "Pro".


var contgPro = listaProductos.Where(p => p.Nombre.Contains("Pro")).ToList();

foreach (var contgP in contgPro)
{
    Console.WriteLine($"{contgP.Nombre}");
}


// 36. Obtener los productos cuyo stock sea un múltiplo de 5.


var multiploDeCinco = listaProductos.Where(p => p.Stock % 5 == 0).ToList();

foreach (var multiplo in multiploDeCinco)
{
    Console.WriteLine($"{multiplo.Nombre} | Stock: {multiplo.Stock}");
}


// 37. Obtener los productos que tengan una descripción con más de 20 caracteres.

var contCaract = listaProductos.Where(p => p.Descripcion.Length > 20).ToList();

foreach (var caract in contCaract)
{
    Console.WriteLine($"{caract.Nombre} | Descripcion: {caract.Descripcion}");
}


// 38. Obtener los productos cuyo precio sea un número redondo (sin decimales).


var numRedondo = listaProductos.Where(p => p.Precio % 1 == 0).ToList();

foreach (var redond in numRedondo)
{
    Console.WriteLine($"{redond.Nombre} | Precio: {redond.Precio}");

}


// 39. Obtener los productos que tengan exactamente dos palabras en su nombre.

var contgDospalabras = listaProductos.Where(p => p.Nombre.Split(' ').Length == 2).ToList();

foreach(var dosP in contgDospalabras)
{
    Console.WriteLine($"{dosP.Nombre}");
}


// 40. Obtener la cantidad de productos que no pertenecen a la categoría "General".
 
var noGeneral = listaProductos.Where(p => p.Categoria != "General").ToList();

foreach (var noG in noGeneral)
{
    Console.WriteLine($"{noG.Nombre} | Categoria: {noG.Categoria}");
}






