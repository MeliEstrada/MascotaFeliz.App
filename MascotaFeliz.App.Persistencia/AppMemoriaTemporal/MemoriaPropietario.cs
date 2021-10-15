using System;
using System.Collections.Generic;
using System.Linq;
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
                new Propietario{Id=4, Nombre="Melissa Andrea",
                    Apellidos="Estrada Marín", NumeroTelefono="3004610198",
                    CorreoElectronico="andreita_9815@hotmail.com"},
                new Propietario{Id=5, Nombre="Robin",
                    Apellidos="Benítez Mora", NumeroTelefono="3008060020",
                    CorreoElectronico="robinbenitez@yahoo.com"}
            };
        }

        public Propietario AddPropietario(Propietario nuevoPropietario)
        {
            nuevoPropietario.Id = propietarios.Max(p => p.Id) + 1;
            propietarios.Add(nuevoPropietario);
            return nuevoPropietario;
        }

        public void DeletePropietario(int propietarioId)
        {
            var propietarioEncontrado = GetPropietario(propietarioId);
            if (propietarioEncontrado != null)
                propietarios.Remove(propietarioEncontrado);
        }

        public IEnumerable<Propietario> GetAllPropietarios()
        {
            return propietarios;
        }

        public Propietario GetPropietario(int propietarioId)
        {
            return propietarios.SingleOrDefault(p => p.Id == propietarioId);
        }

        public IEnumerable<Propietario> GetPropietariosPorFiltro(
            string filtro = null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var propietarios = GetAllPropietarios(); // Todos los propietarios
            if (propietarios != null) // Si se tienen propietarios
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    propietarios = propietarios.Where(
                        p => (p.Nombre + " " + p.Apellidos).Contains(filtro));
                    // Filtra los propietarios que contienen el filtro
                }
            }
            return propietarios;
        }

        public Propietario UpdatePropietario(Propietario propietarioActualizado)
        {
            var propietario = GetPropietario(propietarioActualizado.Id);
            if (propietario != null)
            {
                propietario.Nombre = propietarioActualizado.Nombre;
                propietario.Apellidos = propietarioActualizado.Apellidos;
                propietario.NumeroTelefono =
                    propietarioActualizado.NumeroTelefono;
                propietario.CorreoElectronico =
                    propietarioActualizado.CorreoElectronico;
            }
            return propietario;
        }
        
    }
}
