En esta tarea se encuentra una API_Rest creada mediante unos requerimientos,acontinuacion estaré detallando su funcionamiento.


DESCRIPCION DE LOS METODOS HTTP:

Metodos con los que cuenta la API llamada "API_Rest" 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/e8a91a1520e97a8543dbc1e0e317ca9fb26e2a14/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/swagger_users.png)

API_Rest cuenta con metodos http que son los siguientes:

GET: /usuario/listar , permite ver todos los usuarios que hay en la base de datos, como se puede ver en la siguiente demostracion:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/0b9e405af722f8bf628ee5090844aa71df0ed9c2/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/listarAPI.png)


GET: /usuario/{id} , permite ver los usuarios que hay en la base de datos mediante el id: 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/0b9e405af722f8bf628ee5090844aa71df0ed9c2/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/listarAPI_id.png)

POST: /usuario/crearUsuario , permite crear un usuario en la base de datos que hace una validacion de que el correo que sea ingresado no puede ser uno que esté en uso:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/0b9e405af722f8bf628ee5090844aa71df0ed9c2/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/post_Usuario.png)

Validacion en accion: 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/27d61345c60c3d7af32a2e06273ba86d5a00b6c4/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/error_alcrear_Usuario_conMismoEmail.png)


PUT: /usuario/actualizar/{id} , permite actualizar la informacion de un usuario mediante id, como el ejemplo acontinuacion que cambia el correo y hora de nacimiento de el usuario con id 4 que es Alfonso 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/27d61345c60c3d7af32a2e06273ba86d5a00b6c4/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/put_id.png)

Comprobacion: 

Antes del PUT

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/27d61345c60c3d7af32a2e06273ba86d5a00b6c4/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/example_change-emailAndBirthdate.png)

Despues del PUT

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/27d61345c60c3d7af32a2e06273ba86d5a00b6c4/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/email-changed.png)

DELETE: /usuario/eliminar/{id} , esta como post pero realiza la eliminacion de un usuario mediante el id: 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/27d61345c60c3d7af32a2e06273ba86d5a00b6c4/tareaPractica5/API_Rest/API_Rest/Image_References_For_Documentation/delete_by_id.png)

en esta demostracion se a eliminado el usuario con id 4 de la base de datos que es Alonso.

--Hasta aqui ha llegado la documentacion, gracias por leer. :)) ---


