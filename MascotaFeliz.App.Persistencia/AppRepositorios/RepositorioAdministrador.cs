using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
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

        Administrador IRepositorioAdministrador.AddAdministrador(
            Administrador administrador)
        {
            var administradorAdicionado =
                _appContext.Administradores.Add(administrador);
            _appContext.SaveChanges();
            return administradorAdicionado.Entity;
        }

        IEnumerable<Administrador> IRepositorioAdministrador.GetAllAdministradores()
        {
            return _appContext.Administradores;
        }

        Administrador IRepositorioAdministrador.GetAdministrador(
            int idAdministrador)
        {
            return _appContext.Administradores.FirstOrDefault(
                a => a.Id == idAdministrador);
        }

        Administrador IRepositorioAdministrador.UpdateAdministrador(
            Administrador administrador)
        {
            var administradorEncontrado =
                _appContext.Administradores.FirstOrDefault(
                    a => a.Id == administrador.Id);
            if (administradorEncontrado != null)
            {
                administradorEncontrado.Nombre = administrador.Nombre;
                administradorEncontrado.Apellidos = administrador.Apellidos;
                administradorEncontrado.NumeroTelefono =
                    administrador.NumeroTelefono;
                administradorEncontrado.CorreoElectronico =
                    administrador.CorreoElectronico;
                administradorEncontrado.Usuario = administrador.Usuario;
                administradorEncontrado.Contrasenia = administrador.Contrasenia;
                administradorEncontrado.TipoUsuario = administrador.TipoUsuario;
                _appContext.SaveChanges();
            }
            return administradorEncontrado;
        }

        void IRepositorioAdministrador.DeleteAdministrador(int idAdministrador)
        {
            var administradorEncontrado =
                _appContext.Administradores.FirstOrDefault(
                    a => a.Id == idAdministrador);
            if (administradorEncontrado == null)
                return;
            _appContext.Administradores.Remove(administradorEncontrado);
            _appContext.SaveChanges();
        }

    }
}