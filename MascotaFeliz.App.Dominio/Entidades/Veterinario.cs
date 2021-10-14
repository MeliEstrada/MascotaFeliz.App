using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Veterinario : Persona
    {
        [Required, StringLength(5)]
        public string TarjetaProfesional {get;set;}
        public Boolean Activo {get;set;}
        public int PersonaId {get;set;}
    }
}

