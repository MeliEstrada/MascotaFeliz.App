using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaAdministrador : IMemoriaAdministrador
    {
        List<Administrador> administradores;

        public MemoriaAdministrador()
        {
            administradores = new List<Administrador>
            {
                new Administrador{Id=1, Nombre="Carlos Julio",
                    Apellidos="Fadul Vasquez", NumeroTelefono="3022333949",
                    CorreoElectronico="carlosfadultic@gmail.com"},
            };
        }

        public Administrador AddAdministrador(Administrador nuevoAdministrador)
        {
            nuevoAdministrador.Id = administradores.Max(a => a.Id) + 1;
            administradores.Add(nuevoAdministrador);
            return nuevoAdministrador;
        }

        public void DeleteAdministrador(int administradorId)
        {
            var administradorEncontrado = GetAdministrador(administradorId);
            if (administradorEncontrado != null)
                administradores.Remove(administradorEncontrado);
        }

        public IEnumerable<Administrador> GetAllAdministradores()
        {
            return administradores;
        }

        public Administrador GetAdministrador(int administradorId)
        {
            return administradores.SingleOrDefault(a => a.Id == administradorId);
        }

        public IEnumerable<Administrador> GetAdministradoresPorFiltro(
            string filtro=null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var administradores = GetAllAdministradores(); // Todos los administradores
            if (administradores != null) // Si se tienen administradores
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    administradores = administradores.Where(a => (a.Nombre + " " + a.Apellidos).Contains(filtro));
                    // Filtra los administradores que contienen el filtro
                }
            }
            return administradores;
        }

        public Administrador UpdateAdministrador(Administrador administradorActualizado)
        {
            var administrador = GetAdministrador(administradorActualizado.Id);
            if (administrador != null)
            {
                administrador.Nombre = administradorActualizado.Nombre;
                administrador.Apellidos = administradorActualizado.Apellidos;
                administrador.NumeroTelefono = administradorActualizado.NumeroTelefono;
                administrador.CorreoElectronico = administradorActualizado.CorreoElectronico;
            }
            return administrador;
        }
        
    }

}