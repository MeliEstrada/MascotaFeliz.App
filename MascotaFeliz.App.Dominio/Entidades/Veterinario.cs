using System;
namespace MascotaFeliz.App.Dominio
{
    public class Veterinario : Persona
    {
        public string TarjetaProfesional {get;set;}
        public Boolean Activo {get;set;}
        public int PersonaId {get;set;}
    }
}
