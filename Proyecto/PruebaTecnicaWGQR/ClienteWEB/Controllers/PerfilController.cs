using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MvcPruebaTecnicaWGQR.Models;
using ClienteWEB.Data;
using System.Configuration;
using System.Web.Mvc;

namespace ClienteWEB.Controllers
{
    public class PerfilController: ApiController
    {
        private PruebaWGQRDataContext _context = new PruebaWGQRDataContext(ConfigurationManager.ConnectionStrings["PruebaTecWGQRConnectionString"].ToString());
        
        [System.Web.Http.HttpGet]
        public JsonResult  GET(string token)
        {
            UsuarioModels resultado = new UsuarioModels();
            bool bValido = false;

            JsonResult jsonPerfil = new JsonResult();

            try
            {
                //Verificar si existe el usuario
                var usrActual = (from item in _context.Usuarios
                                 where item.Token == token
                                 select new UsuarioModels
                                 {
                                     Usuario = item.Usuario,
                                     Contrasenna = item.Contrasenna,
                                     Nombre = item.Nombre,
                                     Apellidos = item.Apellidos,
                                     Email = item.Email,
                                     Direccion = item.Direccion,
                                     Telefono = item.Telefono,
                                     Token = item.Token
                                 }).FirstOrDefault();


                if (usrActual != null)
                {
                    if (!string.IsNullOrEmpty(usrActual.Usuario) && !string.IsNullOrEmpty(usrActual.Contrasenna))
                    {
                        bValido = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                jsonPerfil.Data = resultado;
            }
            return jsonPerfil;
        }
    }
}