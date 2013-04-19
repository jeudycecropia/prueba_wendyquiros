using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode =
               AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file 
    public class Service
    {

        [System.ServiceModel.Web.WebInvoke(UriTemplate = "api/login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //[System.ServiceModel.Web.WebGet(UriTemplate = "api/login/{Usuario}/{Contrasenna}", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        public Resultado POST(String Usuario, String Contrasenna)
        {
            DataAccess oDataAccess = new DataAccess();
            return oDataAccess.CrearToken(Usuario,Contrasenna);
        }

        [System.ServiceModel.Web.WebGet(UriTemplate = "api/perfil/{token}", ResponseFormat = WebMessageFormat.Json)]
        public PerfilUsuario GET(string token)
        {
            DataAccess oDataAccess = new DataAccess();
            return oDataAccess.ConsultarDetalleUsuario(token);
        }

        [System.ServiceModel.Web.WebInvoke(UriTemplate = "api/logout", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //[System.ServiceModel.Web.WebGet(UriTemplate = "api/logout/{token}", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json)]
        public Boolean DELETE(string token)
        {
            DataAccess oDataAccess = new DataAccess();
            return oDataAccess.DeleteToken(token);
        }

    }

}
