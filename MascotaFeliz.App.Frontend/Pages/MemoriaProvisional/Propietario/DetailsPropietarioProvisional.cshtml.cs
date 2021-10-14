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
    public class DetailsPropietarioProvisionalModel : PageModel
    {
        private readonly IMemoriaPropietario memoriaPropietario;
        [BindProperty]
        public Propietario Propietario {get;set;}

        public DetailsPropietarioProvisionalModel(
            IMemoriaPropietario memoriaPropietario)
        {
            this.memoriaPropietario = memoriaPropietario;
        }

        public IActionResult OnGet(int propietarioId)
        {
            Propietario = memoriaPropietario.GetPropietario(propietarioId);
            if (Propietario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaPropietario.DeletePropietario(Propietario.Id);
            return RedirectToPage("./ListPropietariosProvisional");
        }
        
    }
}
