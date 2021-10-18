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
    public class DetailsConsultaModel : PageModel
    {
        private readonly IRepositorioConsulta repositorioConsulta;
        private readonly IRepositorioMascota repositorioMascota; // Adición
        private readonly IRepositorioVeterinario repositorioVeterinario; // Adición
        [BindProperty]
        public ConsultaDomiciliaria Consulta {get;set;}
        public Mascota Mascota {get;set;} // Adición
        public Veterinario Veterinario; // Adición

        public DetailsConsultaModel()
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

        public IActionResult OnGet(int consultaId)
        {
            Consulta = repositorioConsulta.GetConsulta(consultaId);
            // Adición
            Mascota = repositorioMascota.GetMascota(Consulta.MascotaId);
            // Adición
            Veterinario =
                repositorioVeterinario.GetVeterinario(Consulta.VeterinarioId);
            if (Consulta == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (Consulta.Id > 0) repositorioConsulta.DeleteConsulta(Consulta.Id);
            return RedirectToPage("./ListConsultas");
        }

    }
}
