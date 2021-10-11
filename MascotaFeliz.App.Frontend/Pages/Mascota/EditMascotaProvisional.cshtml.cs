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
    public class EditMascotaProvisionalModel : PageModel
    {
        private readonly IMemoriaMascota memoriaMascota;
        [BindProperty]
        public Mascota Mascota {get;set;}

        public EditMascotaProvisionalModel(
            IMemoriaMascota memoriaMascota)
        {
            this.memoriaMascota = memoriaMascota;
        }

        public IActionResult OnGet(int? mascotaId)
        {
            if (!mascotaId.HasValue) Mascota = new Mascota();
            else Mascota =
                memoriaMascota.GetMascota(mascotaId.Value);
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Mascota.Id > 0)
            {
              Mascota = memoriaMascota.UpdateMascota(Mascota);
            }
            else
            {
                Mascota = memoriaMascota.AddMascota(Mascota);
            }
            return Page();
        }

    }
}
