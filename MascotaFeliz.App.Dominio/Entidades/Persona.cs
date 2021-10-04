using System;
namespace MascotaFeliz.App.Dominio
{
    public class Persona
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public string Apellidos {get;set;}
        public string NumeroTelefono {get;set;}
        public string CorreoElectronico {get;set;}
        public string Usuario {get;set;}
        public string Contrasenia {get;set;}
        public TipoUsuario TipoUsuario {get;set;}
    }
}
