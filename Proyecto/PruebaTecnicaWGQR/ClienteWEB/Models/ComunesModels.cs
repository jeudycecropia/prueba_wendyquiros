using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcPruebaTecnicaWGQR.Models
{
    public class UsuarioModels
    {
        [Required]
        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Contraseña")]
        public string Contrasenna { get; set; }        
   
        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Apellidos")]
        public string Apellidos { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Telefono")]
        public string Telefono { get; set; }

        [DisplayName("Token")]
        public string Token { get; set; }
    }

    public class ResultadoModels
    {
        [DisplayName("Resultado")]
        public bool  Resultado { get; set; }

        [DisplayName("Mensaje")]
        public string Mensaje { get; set; }

        [DisplayName("Token")]
        public string Token { get; set; }
    }
}