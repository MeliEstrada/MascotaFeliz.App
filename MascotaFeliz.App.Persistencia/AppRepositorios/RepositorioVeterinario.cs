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

        public Veterinario AddVeterinario(Veterinario nuevoVeterinario)
        {
            var veterinarioAdicionado =
                _appContext.Veterinarios.Add(nuevoVeterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        public void DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado = GetVeterinario(idVeterinario);
            if (veterinarioEncontrado == null) return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(
                p => p.Id == idVeterinario);
        }

        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(
            string filtro = null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var veterinarios = GetAllVeterinarios(); // Todos los veterinarios
            if (veterinarios != null) // Si se tienen veterinarios
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    veterinarios = veterinarios.Where(
                        p => (p.Nombre + " " + p.Apellidos).Contains(filtro));
                    // Filtra los veterinarios que contienen el filtro
                }
            }
            return veterinarios;
        }

        public Veterinario UpdateVeterinario(
            Veterinario veterinarioActualizado)
        {
            var veterinarioEncontrado =
                GetVeterinario(veterinarioActualizado.Id);
            if (veterinarioEncontrado != null)
            {
                veterinarioEncontrado.Nombre = veterinarioActualizado.Nombre;
                veterinarioEncontrado.Apellidos =
                    veterinarioActualizado.Apellidos;
                veterinarioEncontrado.NumeroTelefono =
                    veterinarioActualizado.NumeroTelefono;
                veterinarioEncontrado.CorreoElectronico =
                    veterinarioActualizado.CorreoElectronico;
                veterinarioEncontrado.Usuario =
                    veterinarioActualizado.Usuario;
                veterinarioEncontrado.Contrasenia =
                    veterinarioActualizado.Contrasenia;
                veterinarioEncontrado.TipoUsuario =
                    veterinarioActualizado.TipoUsuario;
                veterinarioEncontrado.TarjetaProfesional =
                    veterinarioEncontrado.TarjetaProfesional;
                veterinarioEncontrado.Activo = veterinarioEncontrado.Activo;
                _appContext.SaveChanges();
            }
            return veterinarioEncontrado;
        }

    }
}
