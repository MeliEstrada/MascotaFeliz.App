using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
    public class ConsultaDomiciliaria
    {
        public int Id {get;set;}
        [Required]
        public StatusConsulta Status {get;set;}
        public DateTime Fecha {get;set;}
        [Required]
        public DateTime Hora {get;set;}
        public float Temperatura {get;set;}
        public float Peso {get;set;}
        public float FrecuenciaRespiratoria {get;set;}
        public float FrecuenciaCardiaca {get;set;}
        public string EstadoAnimo {get;set;}
        public string Diagnostico {get;set;}
        [Required]
        //public Mascota Mascota {get;set;}
        public int MascotaId {get;set;}
        [Required]
        //public Veterinario Veterinario {get;set;}
        public int VeterinarioId {get;set;}
    }
}
