using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[System.Runtime.Serialization.DataContract]
public class PerfilUsuario
{
    [System.Runtime.Serialization.DataMember]
    public int CodError
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string nombre
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string apellidos
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string email
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string direccion
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string telefonos
    {
        get;
        set;
    }
}
[System.Runtime.Serialization.DataContract]
public class Resultado
{
    [System.Runtime.Serialization.DataMember]
    public bool resultado
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string mensaje
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string token
    {
        get;
        set;
    }
}
public class LoginUsuario
{
    [System.Runtime.Serialization.DataMember]
    public string usuario
    {
        get;
        set;
    }
    [System.Runtime.Serialization.DataMember]
    public string contrasenna
    {
        get;
        set;
    }
}