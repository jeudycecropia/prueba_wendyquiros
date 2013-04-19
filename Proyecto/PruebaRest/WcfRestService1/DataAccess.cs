using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;

public class DataAccess
{
    public PerfilUsuario ConsultarDetalleUsuario(string token)
    {
        try
        {
            //Asigna la conexión a BD
            string connectionString = ConfigurationManager.ConnectionStrings["ConectionString"].ToString();
            
            //Realiza la sentencia
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {

                // Asigna la sentencia
                string queryString = "SELECT * FROM Usuario where Token = '" + token + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                //Crea el dataset
                DataSet customers = new DataSet();

                connection.Open();
                //Llena el dataset con la información
                adapter.Fill(customers, "Customers");
                //Valida que haya tablas en el dataset
                if (customers.Tables.Count > 0)
                {
                    //Valida que haya resultados o registros en la tabla
                    if (customers.Tables[0].Rows.Count > 0)
                    {
                        return new PerfilUsuario
                        {
                            //Asigna los valores a la clase
                            nombre = customers.Tables[0].Rows[0]["nombre"].ToString(),
                            apellidos = customers.Tables[0].Rows[0]["apellidos"].ToString(),
                            email = customers.Tables[0].Rows[0]["email"].ToString(),
                            direccion = customers.Tables[0].Rows[0]["direccion"].ToString(),
                            telefonos = customers.Tables[0].Rows[0]["telefonos"].ToString(),
                            CodError= 0
                        };
                    }
                        //Retorna codigo de error al no haber registros
                    else
                        return new PerfilUsuario
                        {
                            CodError = 99
                        };
                }
                else
                    //Retorna codigo de error al no haber tablas
                    return new PerfilUsuario
                    {
                        CodError = 99
                    };
            }
        }
        catch (Exception ex)
        {

            return new PerfilUsuario
            {
                CodError = 99
            };
        }

    }

    public PerfilUsuario ConsultarDetalleUsuario(string usuario, string contrasenna)
    {
        try
        {
            //Asigna la conexión a BD
            string connectionString = ConfigurationManager.ConnectionStrings["ConectionString"].ToString();

            //Realiza la sentencia
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {

                // Asigna la sentencia
                string queryString = "SELECT * FROM Usuario where Usuario = '" + usuario + "' AND Contrasenna = '"+ contrasenna + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
                //Crea el dataset
                DataSet customers = new DataSet();

                connection.Open();
                //Llena el dataset con la información
                adapter.Fill(customers, "Customers");
                //Valida que haya tablas en el dataset
                if (customers.Tables.Count > 0)
                {
                    //Valida que haya resultados o registros en la tabla
                    if (customers.Tables[0].Rows.Count > 0)
                    {
                        return new PerfilUsuario
                        {
                            //Asigna los valores a la clase
                            nombre = customers.Tables[0].Rows[0]["nombre"].ToString(),
                            apellidos = customers.Tables[0].Rows[0]["apellidos"].ToString(),
                            email = customers.Tables[0].Rows[0]["email"].ToString(),
                            direccion = customers.Tables[0].Rows[0]["direccion"].ToString(),
                            telefonos = customers.Tables[0].Rows[0]["telefonos"].ToString(),
                            CodError = 0
                        };
                    }
                    //Retorna codigo de error al no haber registros
                    else
                        return new PerfilUsuario
                        {
                            CodError = 99
                        };
                }
                else
                    //Retorna codigo de error al no haber tablas
                    return new PerfilUsuario
                    {
                        CodError = 99
                    };
            }
        }
        catch (Exception ex)
        {

            return new PerfilUsuario
            {
                CodError = 99
            };
        }

    }

    public Boolean DeleteToken(string token)
    {
        try
        {
            if (ConsultarDetalleUsuario(token).CodError == 0)
            {
                //Asigna el string de conexión
                string connectionString = ConfigurationManager.ConnectionStrings["ConectionString"].ToString();
                
                using (SqlConnection connection =
                new SqlConnection(connectionString))
                {

                    //Asigna la sentencia que actualiza la BD
                    string queryString = "Update Usuario SET Token = NULL where Token = '" + token + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataSet customers = new DataSet();

                    connection.Open();
                    //Ejecuta la sentencia
                    adapter.Fill(customers, "Customers");
                }

                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public Resultado CrearToken(String Usuario, String Contrasenna)
    {
        try
        {
            if (ConsultarDetalleUsuario(Usuario,Contrasenna).CodError == 0)
            {
                //Asigna el string de conexión
                string connectionString = ConfigurationManager.ConnectionStrings["ConectionString"].ToString();
                string token = RandomString(10);

                using (SqlConnection connection =
                new SqlConnection(connectionString))
                {

                    //Asigna la sentencia que actualiza la BD
                    string queryString = "Update Usuario SET Token = '" + token + "' where Usuario = '" + Usuario + "' AND Contrasenna = '" + Contrasenna + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataSet usuario = new DataSet();

                    connection.Open();
                    //Ejecuta la sentencia
                    adapter.Fill(usuario, "Usuario");
                }

                return new Resultado
                {
                    resultado = true,
                    token = token,
                    mensaje = "Valido"
                };
            }
            else
                return new Resultado
                {
                    resultado = false,
                    mensaje = "El usuario y contraseña no coinciden con los que se encuentran en BD."
                };
        }
        catch (Exception ex)
        {
            return new Resultado
            {
                resultado = false,
                mensaje = "Error capturado"
            };
        }

    }

    private string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        return builder.ToString();
    }

}
