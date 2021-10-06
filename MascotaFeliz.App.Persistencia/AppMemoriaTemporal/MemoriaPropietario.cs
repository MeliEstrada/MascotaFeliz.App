using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaPropietario : IMemoriaPropietario
    {
        List<Propietario> propietarios;

        public MemoriaPropietario()
        {
            propietarios = new List<Propietario>
            {
                new Propietario{Id=1, Nombre="Andrea Jaqueline",
                    Apellidos="Solarte Canaval", NumeroTelefono="3133853491",
                    CorreoElectronico="Andrea.solarte72@gmail.com"},
                new Propietario{Id=2, Nombre="Daniela Marcela",
                    Apellidos="Becerra Sosa", NumeroTelefono="3214952185",
                    CorreoElectronico="danielabecerrasosa@gmail.com"},
                new Propietario{Id=3, Nombre="Juan Carlos",
                    Apellidos="Carvajal Tapias", NumeroTelefono="3158556483",
                    CorreoElectronico="juanc.carvajal72@gmail.com"},
                new Propietario{Id=3, Nombre="Melissa Andrea",
                    Apellidos="Estrada Marín", NumeroTelefono="3004610198",
                    CorreoElectronico="andreita_9815@hotmail.com"},
                new Propietario{Id=3, Nombre="Robin",
                    Apellidos="Benítez Mora", NumeroTelefono="3008060020",
                    CorreoElectronico="robinbenitez@yahoo.com"}
            };
        }

        public IEnumerable<Propietario> GetAll()
        {
            return propietarios;
        }
    }
}