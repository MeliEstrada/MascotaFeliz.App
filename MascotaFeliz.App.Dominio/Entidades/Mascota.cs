using System;
namespace MascotaFeliz.App.Dominio
{
    public class Mascota
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        public TipoMascota TipoMascota {get;set;}
        public String Raza {get;set;}
        public GeneroMascota Genero {get;set;}
        public int AnioNacimiento {get;set;}
        public Propietario Propietario {get;set;}
    }
}
