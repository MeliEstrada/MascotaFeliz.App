using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
//using MascotaFeliz.App.Persistencia.AppRepositorios;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetcore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetailsMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public Mascota Mascota {get;set;}

        public DetailsMascotaModel(
            IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = repositorioMascota;
        }

        public IActionResult OnGet(int mascotaId)
        {
            Mascota = repositorioMascota.GetMascota(mascotaId);
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            repositorioMascota.DeleteMascota(Mascota.Id);
            return RedirectToPage("./ListMascotasProvisional");
        }

    }
}
