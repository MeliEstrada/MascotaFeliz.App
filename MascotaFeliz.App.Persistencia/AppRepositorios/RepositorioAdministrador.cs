using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioAdministrador : IRepositorioAdministrador
    {
        // Referencia al contexto de Administrador
        private readonly AppContext _appContext;

        // Metodo Constructor
        // Utiiza Inyeccion de dependencias para indicar el contexto a utilizar
        // <param name="appContext"></param>//
        public RepositorioAdministrador(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Administrador AddAdministrador(Administrador nuevoAdministrador)
        {
            var administradorAdicionado =
                _appContext.Administradores.Add(nuevoAdministrador);
            _appContext.SaveChanges();
            return administradorAdicionado.Entity;
        }

        public void DeleteAdministrador(int idAdministrador)
        {
            var administradorEncontrado = GetAdministrador(idAdministrador);
            if (administradorEncontrado == null) return;
            _appContext.Administradores.Remove(administradorEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Administrador> GetAllAdministradores()
        {
            return _appContext.Administradores;
        }

        public Administrador GetAdministrador(int idAdministrador)
        {
            return _appContext.Administradores.FirstOrDefault(
                p => p.Id == idAdministrador);
        }

        public IEnumerable<Administrador> GetAdministradoresPorFiltro(
            string filtro = null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var administradores = GetAllAdministradores(); // Todos los administradores
            if (administradores != null) // Si se tienen administradores
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    administradores = administradores.Where(
                        p => (p.Nombre + " " + p.Apellidos).Contains(filtro));
                    // Filtra los administradores que contienen el filtro
                }
            }
            return administradores;
        }

        public Administrador UpdateAdministrador(
            Administrador administradorActualizado)
        {
            var administradorEncontrado =
                GetAdministrador(administradorActualizado.Id);
            if (administradorEncontrado != null)
            {
                administradorEncontrado.Nombre = administradorActualizado.Nombre;
                administradorEncontrado.Apellidos =
                    administradorActualizado.Apellidos;
                administradorEncontrado.NumeroTelefono =
                    administradorActualizado.NumeroTelefono;
                administradorEncontrado.CorreoElectronico =
                    administradorActualizado.CorreoElectronico;
                administradorEncontrado.Usuario =
                    administradorActualizado.Usuario;
                administradorEncontrado.Contrasenia =
                    administradorActualizado.Contrasenia;
                administradorEncontrado.TipoUsuario =
                    administradorActualizado.TipoUsuario;
                _appContext.SaveChanges();
            }
            return administradorEncontrado;
        }

    }
}
