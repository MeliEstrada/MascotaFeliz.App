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
    public class EditConsultaModel : PageModel
    {
        private readonly IRepositorioConsulta repositorioConsulta;
        private readonly IRepositorioMascota repositorioMascota; // Adición
        private readonly IRepositorioVeterinario repositorioVeterinario; // Adición
        [BindProperty]
        public ConsultaDomiciliaria Consulta {get;set;}
        public Mascota Mascota {get;set;} // Adición
        public Veterinario Veterinario; // Adición
        //[BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Mascota> Mascotas {get;set;} // Adición
        //[BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Veterinario> Veterinarios {get;set;} // Adición

        public EditConsultaModel()
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

        public IActionResult OnGet(int? consultaId)
        {
            Mascotas = repositorioMascota.GetAllMascotas(); // Adición
            Veterinarios = repositorioVeterinario.GetAllVeterinarios(); // Adición
            if (!consultaId.HasValue) Consulta = new ConsultaDomiciliaria();
            else
            {
                Consulta = repositorioConsulta.GetConsulta(consultaId.Value);
                //mascotaId = Consulta.Mascota.Id; // Adición ahora innecesaria
                //veterinarioId = Consulta.Veterinario.Id; // Adición ahora innecesaria
                // Adición
                Mascota = repositorioMascota.GetMascota(Consulta.MascotaId);
                // Adición
                Veterinario =
                    repositorioVeterinario.GetVeterinario(Consulta.VeterinarioId);
            }
            if (Consulta == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            Mascotas = repositorioMascota.GetAllMascotas(); // Adición
            Veterinarios = repositorioVeterinario.GetAllVeterinarios(); // Adición
            if (!ModelState.IsValid) return Page();
            //Consulta = repositorioConsulta.AsignarMascota(Consulta, mascotaId);
            //Consulta = repositorioConsulta.AsignarVeterinario(Consulta, veterinarioId);
            repositorioConsulta.AsignarMascota(Consulta, Consulta.MascotaId);
            repositorioConsulta.AsignarVeterinario(Consulta, Consulta.VeterinarioId);
            if (Consulta.Id > 0) Consulta = repositorioConsulta.UpdateConsulta(Consulta);
            else Consulta = repositorioConsulta.AddConsulta(Consulta);
            return RedirectToPage("./ListConsultas");
        }

    }
}
