using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaVeterinario : IMemoriaVeterinario
    {
        List<Veterinario> veterinarios;

        public MemoriaVeterinario()
        {
            veterinarios = new List<Veterinario>
            {
                new Veterinario{Id=1, Nombre="Juanita",
                    Apellidos="Guarnizo", NumeroTelefono="3133213491",
                    CorreoElectronico="Juanita.guarnizo@gmail.com",
                    TarjetaProfesional="78901"},
                
                new Veterinario{Id=2, Nombre="Samuel",
                    Apellidos="Marin", NumeroTelefono="3103205678",
                    CorreoElectronico="Samuel.marin@gmail.com",
                    TarjetaProfesional="12345"},
            };
        }
        
        public Veterinario AddVeterinario(Veterinario nuevoVeterinario)
        {
            nuevoVeterinario.Id = veterinarios.Max(v => v.Id) + 1;
            veterinarios.Add(nuevoVeterinario);
            return nuevoVeterinario;
        }

        public void DeleteVeterinario(int veterinarioId)
        {
            var veterinarioEncontrado = GetVeterinario(veterinarioId);
            if (veterinarioEncontrado != null)
                veterinarios.Remove(veterinarioEncontrado);
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return veterinarios;
        }

        public Veterinario GetVeterinario(int veterinarioId)
        {
            return veterinarios.SingleOrDefault(v => v.Id == veterinarioId);
        }

        public IEnumerable<Veterinario> GetVeterinariosPorFiltro(
            string filtro=null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var veterinarios = GetAllVeterinarios(); // Todos los veterinarios
            if (veterinarios != null) // Si se tienen veterinarios
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    veterinarios = veterinarios.Where(
                        v => (v.Nombre + " " + v.Apellidos).Contains(filtro));
                    // Filtra los veterinarios que contienen el filtro
                }
            }
            return veterinarios;
        }

        public Veterinario UpdateVeterinario(Veterinario veterinarioActualizado)
        {
            var veterinario = GetVeterinario(veterinarioActualizado.Id);
            if (veterinario != null)
            {
                veterinario.Nombre = veterinarioActualizado.Nombre;
                veterinario.Apellidos = veterinarioActualizado.Apellidos;
                veterinario.NumeroTelefono = veterinarioActualizado.NumeroTelefono;
                veterinario.CorreoElectronico = veterinarioActualizado.CorreoElectronico;
                veterinario.TarjetaProfesional = veterinarioActualizado.TarjetaProfesional;
            }
            return veterinario;
        }

    }
}
