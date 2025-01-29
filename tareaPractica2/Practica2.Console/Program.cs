internal class Program
{
   
        // Definicion de un delegado para operaciones matematicas
        public delegate T OperacionMatematica<T>(T a, T b);

        // Clase generica que maneja una lista de numeros y realiza operaciones matematicas
        public class ListaNumeros<T>
        {
            private List<T> numeros;

            public ListaNumeros()
            {
                numeros = new List<T>();
            }

            // Metodo para agregar numeros a la lista
            public void AgregarNumero(T numero)
            {
                numeros.Add(numero);
            }

            // Metodo para realizar operaciones matematicas
            public T RealizarOperacion(OperacionMatematica<T> operacion)
            {
                if (numeros.Count < 2)
                    throw new InvalidOperationException("La lista debe contener al menos dos elementos para realizar la operacion.");

                T resultado = numeros[0];

                for (int i = 1; i < numeros.Count; i++)
                {
                    resultado = operacion(resultado, numeros[i]);
                }

                return resultado;
            }

            public void LimpiarLista()
            {
                numeros.Clear();
            }
        }

        class CalculadoraGenerica
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Calculadora Generica\n");

                Console.WriteLine("Elige el tipo de datos con el que deseas trabajar:");
                Console.WriteLine("1. Enteros (int)\n2. Flotantes (float)\n3. Dobles (double)\n4. Decimales (decimal)");
                Console.Write("Opcion: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        EjecutarAplicacion(int.Parse, SumarInt, RestarInt, MultiplicarInt, DividirInt);
                        break;
                    case "2":
                        EjecutarAplicacion(float.Parse, SumarFloat, RestarFloat, MultiplicarFloat, DividirFloat);
                        break;
                    case "3":
                        EjecutarAplicacion(double.Parse, SumarDouble, RestarDouble, MultiplicarDouble, DividirDouble);
                        break;
                    case "4":
                        EjecutarAplicacion(decimal.Parse, SumarDecimal, RestarDecimal, MultiplicarDecimal, DividirDecimal);
                        break;
                    default:
                        Console.WriteLine("Opcion invalida.");
                        break;
                }
            }

            static void EjecutarAplicacion<T>(Func<string, T> parse, OperacionMatematica<T> sumar, OperacionMatematica<T> restar, OperacionMatematica<T> multiplicar, OperacionMatematica<T> dividir)
            {
                var listaNumeros = new ListaNumeros<T>();

                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1. Agregar numero");
                    Console.WriteLine("2. Sumar numeros");
                    Console.WriteLine("3. Restar numeros");
                    Console.WriteLine("4. Multiplicar numeros");
                    Console.WriteLine("5. Dividir numeros");
                    Console.WriteLine("6. Salir");
                    Console.Write("Selecciona una opcion: ");

                    string eleccion = Console.ReadLine();
                    try
                    {
                        switch (eleccion)
                        {
                            case "1":
                                Console.Write("Ingresa un numero: ");
                                string entrada = Console.ReadLine();
                                try
                                {
                                    T numero = parse(entrada);
                                    listaNumeros.AgregarNumero(numero);
                                    Console.WriteLine($"Numero {numero} agregado.");
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Entrada no valida. Por favor, ingresa un numero en el formato correcto.");
                                }
                                break;

                            case "2":
                                Console.WriteLine($"Resultado de la suma: {listaNumeros.RealizarOperacion(sumar)}");
                                break;

                            case "3":
                                Console.WriteLine($"Resultado de la resta: {listaNumeros.RealizarOperacion(restar)}");
                                break;

                            case "4":
                                Console.WriteLine($"Resultado de la multiplicacion: {listaNumeros.RealizarOperacion(multiplicar)}");
                                break;

                            case "5":
                                Console.WriteLine($"Resultado de la division: {listaNumeros.RealizarOperacion(dividir)}");
                                break;

                            case "6":
                                Console.WriteLine("Saliendo de la aplicacion...");
                                return;

                            default:
                                Console.WriteLine("Opcion no valida. Intentalo nuevamente.");
                                break;
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            // Operaciones para enteros
            static int SumarInt(int a, int b) => a + b;
            static int RestarInt(int a, int b) => a - b;
            static int MultiplicarInt(int a, int b) => a * b;
            static int DividirInt(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException("Division por cero no permitida.");

            // Operaciones para flotantes
            static float SumarFloat(float a, float b) => a + b;
            static float RestarFloat(float a, float b) => a - b;
            static float MultiplicarFloat(float a, float b) => a * b;
            static float DividirFloat(float a, float b) => b != 0 ? a / b : throw new DivideByZeroException("Division por cero no permitida.");

            // Operaciones para dobles
            static double SumarDouble(double a, double b) => a + b;
            static double RestarDouble(double a, double b) => a - b;
            static double MultiplicarDouble(double a, double b) => a * b;
            static double DividirDouble(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException("Division por cero no permitida.");

            // Operaciones para decimales
            static decimal SumarDecimal(decimal a, decimal b) => a + b;
            static decimal RestarDecimal(decimal a, decimal b) => a - b;
            static decimal MultiplicarDecimal(decimal a, decimal b) => a * b;
            static decimal DividirDecimal(decimal a, decimal b) => b != 0 ? a / b : throw new DivideByZeroException("Division por cero no permitida.");
        }
    }
