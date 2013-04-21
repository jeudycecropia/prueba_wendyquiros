using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPruebaTecnicaWGQR.Models;
using System.Configuration;
using System.Text;
using System.Web.Http;
using ClienteWEB.Data;
using System.Web.Security;
using Newtonsoft.Json;
using System.Net.Http;


namespace MvcPruebaTecnicaWGQR.Controllers
{
    public class LogInController : ApiController
    {

        private PruebaWGQRDataContext _context = new PruebaWGQRDataContext(ConfigurationManager.ConnectionStrings["PruebaTecWGQRConnectionString"].ToString());
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usr"></param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public JsonResult   POST(UsuarioModels  usr)
        {
            ResultadoModels resultado = new ResultadoModels();

            bool bValido = false;

            JsonResult jsonLogin = new JsonResult();

            try
            {
                //Verificar si existe el usuario
                var usrActual = (from item in _context.Usuarios
                                 where item.Usuario == usr.Usuario & item.Contrasenna == usr.Contrasenna
                                 select new UsuarioModels
                                 {
                                     Usuario = item.Usuario,
                                     Contrasenna = item.Contrasenna
                                 }).FirstOrDefault();

                if (usrActual != null)
                {
                    if (!string.IsNullOrEmpty(usrActual.Usuario) && !string.IsNullOrEmpty(usrActual.Contrasenna))
                    {
                        bValido = true;
                        string token = RandomString(10);

                        if (string.IsNullOrEmpty(usrActual.Token))
                        {
                            object[] parametros = new object[2];
                            parametros[0] = usrActual.Usuario;
                            parametros[1] = token;

                            int rowCount = _context.ExecuteCommand("sp_ActualizarToken " + "@Usuario={0}, @Token={1}", parametros);
                        }

                        //Se agregan los datos del resultado
                        resultado.Resultado = bValido;
                        resultado.Token = token;
                    }
                    else
                    {
                        resultado.Resultado = bValido;
                        resultado.Mensaje = "El usuario no existe.";
                    }
                }
                else
                {
                    resultado.Resultado = bValido;
                    resultado.Mensaje = "El usuario no existe.";
                }
            }
            catch (Exception ex)
            {
                resultado.Resultado = false;
                resultado.Mensaje = "Error capturado";
            }
            finally
            {
                jsonLogin.Data = resultado;
            }

            return jsonLogin;
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
}