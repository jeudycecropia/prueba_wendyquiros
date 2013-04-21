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

namespace ClienteWEB.Controllers
{
    public class LogoutController: ApiController
    {
        private PruebaWGQRDataContext _context = new PruebaWGQRDataContext(ConfigurationManager.ConnectionStrings["PruebaTecWGQRConnectionString"].ToString());

        [System.Web.Mvc.HttpDelete]
        public JsonResult  DELETE(string token)
        {

            ResultadoModels resultado = new ResultadoModels();
            bool bValido = false;
            JsonResult jsonToken = new JsonResult();

            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    object[] parametros = new object[1];
                    parametros[0] = token;

                    int rowCount = _context.ExecuteCommand("sp_BorrarToken " + "@Token={0}", parametros);

                    if (rowCount > 0)
                    {
                        bValido = true;
                    }
                }
                else
                {
                    resultado.Mensaje = "No se encontro el usuario";
                }

                //Se registra el resultado
                resultado.Resultado = bValido;
            }
            catch (Exception ex)
            {
                resultado.Resultado = false;
                resultado.Mensaje = "Error capturado";
            }
            finally
            {
                jsonToken.Data = resultado;
            }
            return jsonToken;
        }

    }
}