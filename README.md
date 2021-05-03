# EdgeApi
La API fue desarrollada con .NET CORE. para consumir datos de https://jsonplaceholder.typicode.com/
Se utilizó una librería externa para ayudar con la implementación de la autenticación por el método JWT, las demás son standard.

Link del collection de Postman para las pruebas es: https://www.getpostman.com/collections/043fbc1395d9637743c3

Indicaciones:
1- Correr el proyecto localmente.
2- En los requests del Postman, editar el puerto de la aplicación si este varía.
3- Ejecutar el request "Authentication" y copiar el token devuelto. Para los fines de este proyecto demo, se utilizan las credenciales:
Usuario: "edge".
Password: "Pa$$w0rd".
4- Copiar el token en la sección de autenticación de los demás requests. 
