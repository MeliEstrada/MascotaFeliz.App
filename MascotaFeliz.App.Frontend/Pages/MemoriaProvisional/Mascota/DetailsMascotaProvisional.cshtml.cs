using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppMemoriaTemporal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetailsMascotaProvisionalModel : PageModel
    {
        private readonly IMemoriaMascota memoriaMascota;
        [BindProperty]
        public Mascota Mascota {get;set;}

        public DetailsMascotaProvisionalModel(
            IMemoriaMascota memoriaMascota)
        {
            this.memoriaMascota = memoriaMascota;
        }

        public IActionResult OnGet(int mascotaId)
        {
            Mascota = memoriaMascota.GetMascota(mascotaId);
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaMascota.DeleteMascota(Mascota.Id);
            return RedirectToPage("./ListMascotasProvisional");
        }

    }
}

