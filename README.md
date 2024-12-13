# CRUD de Catálogo de Personas

Este proyecto es un servicio API que permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre un catálogo de personas. Está diseñado para interactuar con una base de datos en el ambiente **sandbox** de Paycash. La aplicación utiliza AWS Lambda para manejar las solicitudes y exponer los métodos de la API.

## Requisitos Previos

Antes de ejecutar la aplicación, asegúrate de tener los siguientes elementos configurados:

1. **Conexión a la base de datos**: La aplicación se conecta a la base de datos `paycash_middle_sb` en el entorno **sandbox**. El script para crear la base de datos se encuentra en el proyecto **EB_Persona_Test** en la carpeta **Script**.

2. **AWS Lambda**: El proyecto contiene varias funciones Lambda que realizan las operaciones CRUD. Estas Lambdas están configuradas para recibir las credenciales de conexión a la base de datos desde las variables de etapa de API Gateway.

3. **Swagger**: La documentación de la API, que describe los métodos disponibles, se encuentra en el siguiente enlace:
   - [Swagger API Documentation](https://bucket-test-paycash.s3.us-east-2.amazonaws.com/swagger/EB/eb_index.html)

## Instalación

No es necesario realizar una instalación manual, ya que la aplicación está configurada para ejecutar pruebas unitarias directamente desde el proyecto.

## Estructura del Proyecto

El proyecto tiene la siguiente estructura:

- **EB_Persona_Test**: Contiene el código para las pruebas unitarias.
- **Script**: Contiene el script para la configuración de la base de datos **paycash_middle_sb**.
- **Lambdas**: Contiene las funciones Lambda que realizan las operaciones CRUD:
  - **EB_Persona_Crear**: Función Lambda encargada de crear un nuevo registro de persona en la base de datos.
  - **EB_Persona_Consultar**: Función Lambda encargada de consultar los detalles de una persona existente en la base de datos.
  - **EB_Persona_Editar**: Función Lambda encargada de actualizar los datos de una persona en la base de datos.
  - **EB_Persona_Eliminar**: Función Lambda encargada de eliminar un registro de persona de la base de datos.

## Ejecución de las Pruebas

Las pruebas unitarias se ejecutan utilizando **xUnit**. Sigue estos pasos para ejecutar las pruebas unitarias:

1. **Abrir el proyecto en Visual Studio**: Asegúrate de tener la solución abierta en Visual Studio.

2. **Ejecutar las pruebas**: Desde el menú de Visual Studio, selecciona `Test` -> `Run All Tests` o utiliza el siguiente comando en la Consola del Administrador de Paquetes:
   ```bash
   dotnet test
Esto ejecutará las pruebas unitarias de xUnit y mostrará los resultados en la ventana de salida de Visual Studio.

3. **Ver los resultados**: Una vez ejecutadas las pruebas, Visual Studio mostrará el resultado de cada prueba en la ventana de Test Explorer. Si alguna prueba falla, revisa los detalles en el reporte para solucionar el error, en caso de exito debes observar los resultados de la siguiente manera.
![image](https://github.com/user-attachments/assets/e04656d9-3574-43d2-b1ef-5a0339fd5726)


## Métodos de la API

La API tiene los siguientes métodos disponibles, gestionados por las funciones Lambda:

- **GET**: Consulta los detalles de una persona en la base de datos.
- **POST**: Crea un nuevo registro de persona en la base de datos.
- **PUT**: Actualiza los datos de una persona existente en la base de datos.
- **DELETE**: Elimina un registro de persona en la base de datos.

La ruta principal de la API es: https://2ngnoydav8.execute-api.us-east-2.amazonaws.com/sandbox/v1/eb
Para detalles completos de los métodos y cómo interactuar con ellos, consulta la documentación de la API a través del siguiente enlace de **Swagger**:

- [Swagger API Documentation](https://bucket-test-paycash.s3.us-east-2.amazonaws.com/swagger/EB/eb_index.html)

## Despliegue en AWS Lambda

El proyecto contiene las siguientes funciones Lambda que gestionan el CRUD de personas:

1. **EB_Persona_Crear**: Esta Lambda se encarga de crear un nuevo registro de persona en la base de datos.
2. **EB_Persona_Consultar**: Esta Lambda se encarga de consultar los detalles de una persona a partir de su identificador.
3. **EB_Persona_Editar**: Esta Lambda se encarga de actualizar los datos de una persona existente en la base de datos.
4. **EB_Persona_Eliminar**: Esta Lambda se encarga de eliminar un registro de persona de la base de datos.

Cada Lambda recibe las credenciales de conexión a la base de datos a través de las **variables de etapa** de API Gateway. Las funciones Lambda utilizan estas credenciales para interactuar con la base de datos **paycash_middle_sb** en el entorno sandbox.

### Variables de Etapa en API Gateway

Las variables de etapa deben contener las siguientes configuraciones para que las Lambdas puedan acceder a la base de datos:

- **Host**: Dirección del servidor de la base de datos.
- **User**: Usuario de la base de datos.
- **Pass**: Contraseña de la base de datos.
- **Schema**: Nombre de la base de datos (debe estar configurado como `paycash_middle_sb`).
- **Port**: Puerto de la conexión.

## Contribuir

Si deseas contribuir al proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu contribución (`git checkout -b nombre-rama`).
3. Realiza los cambios y haz commit de ellos (`git commit -am 'Descripción de los cambios'`).
4. Envía un pull request describiendo tus cambios y por qué deberían ser aceptados.

## Licencia

Este proyecto está bajo la licencia **MIT**.
