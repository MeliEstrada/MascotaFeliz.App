using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        // Referencia al contexto de Propietario
        private readonly AppContext _appContext;

        // Metodo Constructor
        // Utiiza Inyeccion de dependencias para indicar el contexto a utilizar
        // <param name="appContext"></param>//
        public RepositorioPropietario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Propietario IRepositorioPropietario.AddPropietario(
            Propietario propietario)
        {
            var propietarioAdicionado =
                _appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(
                p => p.Id == idPropietario);
        }

        Propietario IRepositorioPropietario.UpdatePropietario(
            Propietario propietario)
        {
            var propietarioEncontrado =
                _appContext.Propietarios.FirstOrDefault(
                    p => p.Id == propietario.Id);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Nombre = propietario.Nombre;
                propietarioEncontrado.Apellidos = propietario.Apellidos;
                propietarioEncontrado.NumeroTelefono =
                    propietario.NumeroTelefono;
                propietarioEncontrado.CorreoElectronico =
                    propietario.CorreoElectronico;
                propietarioEncontrado.Usuario = propietario.Usuario;
                propietarioEncontrado.Contrasenia = propietario.Contrasenia;
                propietarioEncontrado.TipoUsuario = propietario.TipoUsuario;
                propietarioEncontrado.Identificacion =
                    propietario.Identificacion;
                propietarioEncontrado.Direccion = propietario.Direccion;
                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }

        void IRepositorioPropietario.DeletePropietario(int idPropietario)
        {
            var propietarioEncontrado =
                _appContext.Propietarios.FirstOrDefault(
                    p => p.Id == idPropietario);
            if (propietarioEncontrado == null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();
        }

    }
}