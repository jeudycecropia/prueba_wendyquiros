prueba_wendyquiros
==================

Prueba técnica de Wendy Quirós Ramírez

*Configuración de Base de Datos
Ejecutar el script para generar la base de datos: /BaseDeDatos/PruebaTecWGQR.sql
Usuario de base de datos a utilizar: wquiros, password: wquiros (Se pueden agregar mas usuarios en la instrucción de INSERT al final del script)

*Configuración de la conexión a base de datos
Cambiar la seccion del web.config de la conexion a base de datos (PruebaTecWGQRConnectionString), con la configuración del equipo local (servidor local):

<add name="PruebaTecWGQRConnectionString" connectionString="Data Source=EQUIPOVIRTUAL;Initial Catalog=PruebaTecWGQR;Integrated Security=True"
providerName="System.Data.SqlClient" />




