using System;
namespace MascotaFeliz.App.Dominio
{
    public class ConsultaDomiciliaria
    {
        public int Id {get;set;}
        public StatusConsulta Status {get;set;}
        public DateTime Fecha {get;set;}
        public DateTime Hora {get;set;}
        public float Temperatura {get;set;}
        public float Peso {get;set;}
        public float FrecuenciaRespiratoria {get;set;}
        public float FrecuenciaCardiaca {get;set;}
        public string EstadoAnimo {get;set;}
        public string Diagnostico {get;set;}
        public Mascota Mascota {get;set;}
        public Veterinario Veterinario {get;set;}
    }
}
