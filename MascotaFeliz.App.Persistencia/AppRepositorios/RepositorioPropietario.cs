using System;
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

        public Propietario AddPropietario(Propietario nuevoPropietario)
        {
            var propietarioAdicionado =
                _appContext.Propietarios.Add(nuevoPropietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        public void DeletePropietario(int idPropietario)
        {
            var propietarioEncontrado = GetPropietario(idPropietario);
            if (propietarioEncontrado == null) return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Propietario> GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        public Propietario GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(
                p => p.Id == idPropietario);
        }

        public IEnumerable<Propietario> GetPropietariosPorFiltro(
            string filtroNombreApellidos = null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var propietarios = GetAllPropietarios(); // Todos los propietarios
            if (propietarios != null) // Si se tienen propietarios
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtroNombreApellidos))
                {
                    propietarios = propietarios.Where(
                        p => (p.Nombre + " " + p.Apellidos).Contains(filtroNombreApellidos));
                    // Filtra los propietarios que contienen el filtro
                }
            }
            return propietarios;
        }

        public Propietario UpdatePropietario(
            Propietario propietarioActualizado)
        {
            var propietarioEncontrado =
                GetPropietario(propietarioActualizado.Id);
            if (propietarioEncontrado != null)
            {
                propietarioEncontrado.Nombre = propietarioActualizado.Nombre;
                propietarioEncontrado.Apellidos =
                    propietarioActualizado.Apellidos;
                propietarioEncontrado.NumeroTelefono =
                    propietarioActualizado.NumeroTelefono;
                propietarioEncontrado.CorreoElectronico =
                    propietarioActualizado.CorreoElectronico;
                propietarioEncontrado.Usuario =
                    propietarioActualizado.Usuario;
                propietarioEncontrado.Contrasenia =
                    propietarioActualizado.Contrasenia;
                propietarioEncontrado.TipoUsuario =
                    propietarioActualizado.TipoUsuario;
                propietarioEncontrado.Identificacion =
                    propietarioActualizado.Identificacion;
                propietarioEncontrado.Direccion =
                    propietarioActualizado.Direccion;
                _appContext.SaveChanges();
            }
            return propietarioEncontrado;
        }

    }
}
