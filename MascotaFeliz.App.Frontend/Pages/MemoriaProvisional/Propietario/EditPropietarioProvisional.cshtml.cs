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
    public class EditPropietarioProvisionalModel : PageModel
    {
        private readonly IMemoriaPropietario memoriaPropietario;
        [BindProperty]
        public Propietario Propietario {get;set;}

        public EditPropietarioProvisionalModel(
            IMemoriaPropietario memoriaPropietario)
        {
            this.memoriaPropietario = memoriaPropietario;
        }

        public IActionResult OnGet(int? propietarioId)
        {
            if (!propietarioId.HasValue) Propietario = new Propietario();
            else Propietario =
                memoriaPropietario.GetPropietario(propietarioId.Value);
            if (Propietario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Propietario.Id > 0)
                Propietario = memoriaPropietario.UpdatePropietario(Propietario);
            else
                Propietario = memoriaPropietario.AddPropietario(Propietario);
            return RedirectToPage("./ListPropietariosProvisional");
        }

    }
}
