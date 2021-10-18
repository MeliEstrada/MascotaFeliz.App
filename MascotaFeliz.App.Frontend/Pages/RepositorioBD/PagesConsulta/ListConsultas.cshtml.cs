using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
//using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListConsultasModel : PageModel
    {
        private readonly IRepositorioConsulta repositorioConsulta;
        private readonly IRepositorioMascota repositorioMascota; // Adición
        private readonly IRepositorioVeterinario repositorioVeterinario; // Adición
        public IEnumerable<ConsultaDomiciliaria> Consultas {get;set;}
        //[BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Mascota> Mascotas {get;set;} // Adición
        //[BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Veterinario> Veterinarios {get;set;} // Adición
        [BindProperty(SupportsGet = true)]
        public int FiltroIdMascota {get;set;}
        [BindProperty(SupportsGet = true)]
        public int FiltroIdVeterinario {get;set;}

        public ListConsultasModel()
        {
            repositorioConsulta = new RepositorioConsulta(
                new MascotaFeliz.App.Persistencia.AppContext());
            // Adición
            repositorioMascota = new RepositorioMascota(
                new MascotaFeliz.App.Persistencia.AppContext());
            // Adición
            repositorioVeterinario = new RepositorioVeterinario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(int filtroIdMascota, int filtroIdVeterinario)
        {
            Mascotas = repositorioMascota.GetAllMascotas(); // Adición
            Veterinarios = repositorioVeterinario.GetAllVeterinarios(); // Adición
            FiltroIdMascota = filtroIdMascota;
            FiltroIdVeterinario = filtroIdVeterinario;
            Consultas = repositorioConsulta.GetAllConsultas();
            Consultas = repositorioConsulta.GetConsultasPorMascota(
                Consultas, filtroIdMascota);
            Consultas = repositorioConsulta.GetConsultasPorVeterinario(
                Consultas, filtroIdVeterinario);
        }

        public string GetNombreMascota(int mascotaId)
        {
            var mascota = repositorioMascota.GetMascota(mascotaId);
            var nombreMascota = mascota.Nombre;
            return nombreMascota;
        }
        
        public TipoMascota GetTipoMascota(int mascotaId)
        {
            var mascota = repositorioMascota.GetMascota(mascotaId);
            var tipoMascota = mascota.TipoMascota;
            return tipoMascota;
        }

        public string GetNombreApellidosVeterinario(int veterinarioId)
        {
            var veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);
            var NombreApellidos = veterinario.Nombre + " " + veterinario.Apellidos;
            return NombreApellidos;
        }

    }
}
