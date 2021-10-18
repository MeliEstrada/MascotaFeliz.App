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
    public class DetailsMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario; // Adición
        [BindProperty]
        public Mascota Mascota {get;set;}
        public Propietario Propietario; // Adición

        public DetailsMascotaModel()
        {
            repositorioMascota = new RepositorioMascota(
                new MascotaFeliz.App.Persistencia.AppContext());
            // Adición
            repositorioPropietario = new RepositorioPropietario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId)
        {
            Mascota = repositorioMascota.GetMascota(mascotaId);
            // Adición
            Propietario =
                repositorioPropietario.GetPropietario(Mascota.PropietarioId);
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (Mascota.Id > 0) repositorioMascota.DeleteMascota(Mascota.Id);
            return RedirectToPage("./ListMascotas");
        }

    }
}
