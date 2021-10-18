using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Propietario : Persona
    {
        public string Identificacion {get;set;}
        [Required, StringLength(50)]
        public string Direccion {get;set;}
        public int PersonaId {get;set;}
    }
}
