El propósito del proyecto:

El propósito principal del proyecto es crear una aplicación interactiva que permita realizar operaciones matemáticas sobre listas de números de diferentes tipos de datos (enteros, flotantes, dobles y decimales) de manera flexible y genérica. La aplicación permite al usuario agregar números a una lista y realizar operaciones como suma, resta, multiplicación y división sobre todos los elementos de la lista. 

El enfoque en genéricos permite que la aplicación sea reutilizable para diferentes tipos de datos sin tener que duplicar el código, mientras que los delegados permiten pasar las operaciones matemáticas como parámetros, haciendo que la aplicación sea más dinámica y flexible al momento de seleccionar las operaciones.

Además, el manejo de excepciones como la división por cero y la verificación de que la lista tenga al menos dos elementos para realizar operaciones matemáticas asegura que la aplicación funcione de manera correcta y evite errores en tiempo de ejecución.

Explicacion General:

La aplicación permite realizar operaciones matemáticas sobre listas de números de diferentes tipos de datos (enteros, flotantes, dobles y decimales). El usuario puede agregar números a la lista y realizar operaciones como sumar, restar, multiplicar o dividir todos los números en la lista. El programa es interactivo y tiene un menú para que el usuario seleccione las acciones. Además, maneja excepciones como la división por cero y verifica si la lista tiene al menos dos elementos para realizar las operaciones.

Explicación de los métodos utilizados:

AgregarNumero(T numero): Este método agrega un número de tipo genérico a la lista interna numeros.
RealizarOperacion(OperacionMatematica<T> operacion): Este método recibe un delegado de tipo OperacionMatematica<T> que define la operación matemática que se realizará sobre los elementos de la lista. Si hay menos de dos elementos, lanza una excepción.
LimpiarLista(): Limpia la lista de números eliminando todos los elementos.
Además, en el menú, se llaman a métodos específicos para realizar las operaciones (como sumar, restar, multiplicar y dividir) para cada tipo de dato.

Descripción de las excepciones manejadas:

FormatException: Se maneja cuando el usuario introduce un valor no válido, por ejemplo, una letra en lugar de un número.
InvalidOperationException: Se lanza si el usuario intenta realizar una operación cuando la lista tiene menos de dos elementos.
DivideByZeroException: Se maneja cuando el usuario intenta dividir por cero, lo que no es permitido.
Utilizacion de genéricos y delegados:

Genéricos: La clase ListaNumeros<T> y los métodos utilizan genéricos para permitir que la lista y las operaciones sean realizadas con cualquier tipo de dato (enteros, flotantes, etc.). Esto permite que la aplicación sea flexible y funcione con varios tipos de datos sin necesidad de escribir código repetitivo para cada uno.

Delegados: El delegado OperacionMatematica<T> es utilizado para pasar las operaciones matemáticas (como suma, resta, multiplicación, división) a los métodos genéricos. Este delegado permite que el método RealizarOperacion ejecute la operación correspondiente dependiendo de la elección del usuario sin necesidad de codificar manualmente cada operación.
