#DOCUMENTACION 

En esta carpeta solo se encuentra la documentacion de los cambios hechos a la API_Rest que fue creada mediante unos nuevos requerimientos.

Para poder ver los cambios ir a la tarea 5: [Tarea5](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/tree/main/tareaPractica5/API_Rest/API_Rest/API_Rest)

DESCRIPCION DE LOS METODOS HTTP REFACTORIZO Y EL RECIEN AGREGADO:

METODO HTTP MODIFICADO: 

POST: api/auth/register , se refactorizo para que ahora tenga una llamada asincrona que contiene una nueva funcionalidad que es agregar el usuario registrado 
en el archivo de texto llamado "historialLog.txt" que es serializado a un archivo JSON:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/925952c6c54f7ed6ad0aab3b90e780813b6eabd3/tareaPractica8/ImagesReferencesForDocumentation/registroWithJsonDocument.png)

GET: /api/obtenerUsuariosDelJson , obtiene los usuarios que fueron registrados en el JSON mediante la utilizacion del EndPoint anterior: api/auth/register

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/925952c6c54f7ed6ad0aab3b90e780813b6eabd3/tareaPractica8/ImagesReferencesForDocumentation/getDeLaAPIWithJsonDocument.png)


------------------------------FIN DOCUMENTACION--------------------------------------------------------------------------------------------------------
