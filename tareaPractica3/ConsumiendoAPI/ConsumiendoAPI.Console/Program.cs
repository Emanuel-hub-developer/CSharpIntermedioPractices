
using ConsumiendoAPI.Console.Clases;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Json;

//Si ve un dynamic en postcode no se sorprenda jajaja XD

string respuesta;

do
{
    string value = string.Empty;

    var amount = 0;

    bool cantidadValida = false;

    Console.WriteLine("Iniciando Programa,Favor espere...\n");

    await Task.Delay(3000);

    while (!cantidadValida)
    {
        Console.WriteLine("Ingrese la cantidad de usuarios que desea obtener: ");
         value  = Console.ReadLine()?.Trim();

        if (int.TryParse(value, out amount) && amount > 0)
        {
            cantidadValida = true; // Salir del ciclo si la cantidad es valida
        }
        else
        {
            Console.WriteLine("Error: La cantidad debe ser un numero valido mayor a 0.\n");
        }
    }

    //API RANDOM USER
    string url = $"https://randomuser.me/api/?results={amount}";

    try
    {
        var result = await GetUser(url);

        async Task<Root> GetUser(string url)
        {
            var http = new HttpClient();

            var result = await http.GetFromJsonAsync<Root>(url);

            return result!;
        }

        Console.WriteLine("\nLlamando a la API,Espere...\n");

        await Task.Delay(5000);

        Console.WriteLine("Gracias Por la Espera.\n");

        Console.WriteLine("USUARIOS GENERADOS: \n");

        foreach (var item in result.results)
        {
            Console.WriteLine($"Usuario Random:");
            Console.WriteLine("Nombre Completo: {0} {1} {2}", item.name.title, item.name.first, item.name.last);
            Console.WriteLine("Genero: {0}", item.gender);
            Console.WriteLine("Email: {0}", item.email);
            Console.WriteLine("Pais: {0}\n", item.location.country);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ha ocurrido un error inesperado, favor intente de nuevo.{ex.Message}");

    }

    Console.WriteLine("¿Desea buscar mas usuarios? s/n");
    respuesta = Console.ReadLine()?.Trim().ToLower();
    
    
} while (respuesta == "s");

    Console.WriteLine("Cerrando Programa, Gracias por su visita. :D");




