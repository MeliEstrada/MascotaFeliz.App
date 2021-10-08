using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Persona
    {
        public int Id {get;set;}
        [Required, StringLength(50)]
        public string Nombre {get;set;}
        [Required, StringLength(50)]
        public string Apellidos {get;set;}
        [Required, StringLength(20)]
        public string NumeroTelefono {get;set;}
        [Required, StringLength(50)]
        public string CorreoElectronico {get;set;}
        // [Required, StringLength(20)]
        public string Usuario {get;set;}
        // [Required, StringLength(20)]
        public string Contrasenia {get;set;}
        public TipoUsuario TipoUsuario {get;set;}
    }
}
