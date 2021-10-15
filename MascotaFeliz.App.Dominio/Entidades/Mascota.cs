using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int Id {get;set;}
        [Required, StringLength(20)]
        public string Nombre {get;set;}
        [Required]
        public TipoMascota TipoMascota {get;set;}
        [Required, StringLength(20)]
        public String Raza {get;set;}
        [Required]
        public GeneroMascota Genero {get;set;}
        [Required]
        public int AnioNacimiento {get;set;}
        [Required]
        public Propietario Propietario {get;set;}
    }
}

