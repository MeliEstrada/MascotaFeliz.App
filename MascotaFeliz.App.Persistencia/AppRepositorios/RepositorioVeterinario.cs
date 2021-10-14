using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        // Referencia al contexto de Veterinario
        private readonly AppContext _appContext;

        // Metodo Constructor
        // Utiiza Inyeccion de dependencias para indicar el contexto a utilizar
        // <param name="appContext"></param>//
        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Veterinario IRepositorioVeterinario.AddVeterinario(
            Veterinario veterinario)
        {
            var veterinarioAdicionado = 
                _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(
                v => v.Id == idVeterinario);
        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(
            Veterinario veterinario)
        {
            var veterinarioEncontrado =
                _appContext.Veterinarios.FirstOrDefault(
                    v => v.Id == veterinario.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinario.Nombre;
                veterinarioEncontrado.Apellidos = veterinario.Apellidos;
                veterinarioEncontrado.NumeroTelefono =
                    veterinario.NumeroTelefono;
                veterinarioEncontrado.CorreoElectronico =
                    veterinario.CorreoElectronico;
                veterinarioEncontrado.Usuario = veterinario.Usuario;
                veterinarioEncontrado.Contrasenia = veterinario.Contrasenia;
                veterinarioEncontrado.TipoUsuario = veterinario.TipoUsuario;
                veterinarioEncontrado.TarjetaProfesional =
                    veterinario.TarjetaProfesional;
                veterinarioEncontrado.Activo = veterinario.Activo;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado =
                _appContext.Veterinarios.FirstOrDefault(
                    v => v.Id == idVeterinario);
            if (veterinarioEncontrado == null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

    }
}