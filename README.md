prueba_wendyquiros
==================

Prueba técnica de Wendy Quirós

*Configuración de proyecto Web Service

Para el proyecto PruebaRest => Web services RESTful, la base de datos es Prueba.mdf y requiere la ruta absoluta de donde se descargue el proyecto.

En la sección del web.config cambiar la sección "SQLEXPRESS;AttachDbFilename=" por la dirección del equipo local:

<add name="ConectionString" connectionString="Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Documents and Settings\Wendy\Mis documentos\Visual Studio 2010\Projects\PruebaRest\WcfRestService1\App_Data\Prueba.mdf';Integrated Security=True;User Instance=True"
providerName=".NET Framework Data Provider for SQL Server" />

Usuario de base de datos a utilizar: wquiros, password: wquiros

Se requiere tener disponible el puerto 4083

*Configuración de proyecto WEB

El proyecto PruebaTecnicaWGQR => simplemente ejecutar
