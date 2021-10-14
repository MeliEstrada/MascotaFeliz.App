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
        private readonly IMemoriaPropietario memoriaPropietario; // Adición
        [BindProperty]
        public Mascota Mascota {get;set;}
        [BindProperty(SupportsGet = true)] // Adición
        public int propietarioId {get;set;} // Adición
        [BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Propietario> Propietarios {get;set;} // Adición

        // Parámetro adicionado
        public EditMascotaProvisionalModel(IMemoriaMascota memoriaMascota,
            IMemoriaPropietario memoriaPropietario)
        {
            this.memoriaMascota = memoriaMascota;
            this.memoriaPropietario = memoriaPropietario; // Adición
        }

        public IActionResult OnGet(int? mascotaId)
        {
            Propietarios = memoriaPropietario.GetAllPropietarios(); // Adición
            if (!mascotaId.HasValue) Mascota = new Mascota();
            else
            {
                Mascota = memoriaMascota.GetMascota(mascotaId.Value);
                propietarioId = Mascota.Propietario.Id; // Adición
            }
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            Propietarios = memoriaPropietario.GetAllPropietarios(); // Adición
            if (!ModelState.IsValid) return Page();
            if (Mascota.Id > 0) Mascota = memoriaMascota.UpdateMascota(Mascota);
            else Mascota = memoriaMascota.AddMascota(Mascota);
            Mascota = memoriaMascota.AsignarPropietario(Mascota, propietarioId);
            Mascota = memoriaMascota.UpdateMascota(Mascota);
            return RedirectToPage("./ListMascotasProvisional");
        }

    }
}
