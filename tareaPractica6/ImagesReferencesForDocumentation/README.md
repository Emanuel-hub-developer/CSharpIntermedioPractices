#DOCUMENTACION

En esta carpeta solo se encuentra la documentacion de los cambios hechos a la API_Rest que fue creada mediante unos requerimientos.

Para poder ver los cambios ir a la tarea 5: [Tarea5](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/tree/main/tareaPractica5/API_Rest/API_Rest/API_Rest)

DESCRIPCION DE LOS NUEVOS METODOS HTTP UTILIZANDO JWT:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/2e55611e2c47b0bdf0c632242f1c97211f625d17/tareaPractica6/ImagesReferencesForDocumentation/swagger_Access.png)

POST: api/auth/register , permite registrar un usuario dentro de la base de datos encriptando su clave en un jwtToken.

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/2e55611e2c47b0bdf0c632242f1c97211f625d17/tareaPractica6/ImagesReferencesForDocumentation/register_JWT.png)

Como se ve en la base de datos una vez registrado el usuario: 
![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/3eaacf4f825d6ca186e77bea04e9742bba4286f1/tareaPractica6/ImagesReferencesForDocumentation/dbExampleJwt.png)

POST: api/auth/login , es un login que pide como parametros el correo y la clave con las que el usuario se registro en api/auth/register 
si inicia correctamente se le retorna un token con un tiempo de 30 min antes de su expiracion y un refresh token de 3min antes de su expiracion
que fue lo que utilice para el testing, si ingresa incorrectamente se le envia un mensaje en pantalla que indica que las credenciales son invalidas:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/3eaacf4f825d6ca186e77bea04e9742bba4286f1/tareaPractica6/ImagesReferencesForDocumentation/loginDTO.png)

POST: api/auth/refresh , permite refrescar el token ingresando como parametros el token expirado y el refresh token 
que fue retornado cuando el usuario inició sesion en api/auth/login:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/3eaacf4f825d6ca186e77bea04e9742bba4286f1/tareaPractica6/ImagesReferencesForDocumentation/RefreshToken.png)

Comprobacion en la base de datos en la tabla donde se refresca el token "HistorialRefreshTokens":
![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/3eaacf4f825d6ca186e77bea04e9742bba4286f1/tareaPractica6/ImagesReferencesForDocumentation/refreshTokenExampleDb.png)



SE LE AGREGO DATANOTATTIONS A 4 ENTIDADES QUE FUERON:

Usuario:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/124b2210d558ecabe7033fe9963974fc878718b4/tareaPractica6/ImagesReferencesForDocumentation/user_ApiRest.png)

UsuarioDTO: 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/124b2210d558ecabe7033fe9963974fc878718b4/tareaPractica6/ImagesReferencesForDocumentation/Usuario_DTO.png)

LoginDTO: 

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/124b2210d558ecabe7033fe9963974fc878718b4/tareaPractica6/ImagesReferencesForDocumentation/DTOLogin.png)

HistorialRefreshToken:

![image alt](https://github.com/Emanuel-hub-developer/CSharpIntermedioPractices/blob/124b2210d558ecabe7033fe9963974fc878718b4/tareaPractica6/ImagesReferencesForDocumentation/Historial%20Refresh.png)


-----------------------------------------------------------FIN DE LA DOCUMENTACION-----------------------------------------------
