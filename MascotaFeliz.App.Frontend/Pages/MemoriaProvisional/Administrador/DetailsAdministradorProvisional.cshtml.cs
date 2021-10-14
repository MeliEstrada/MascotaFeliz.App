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
    public class DetailsAdministradorProvisionalModel : PageModel
    {
        private readonly IMemoriaAdministrador memoriaAdministrador;
        [BindProperty]
        public Administrador Administrador {get; set;}

        public DetailsAdministradorProvisionalModel(
            IMemoriaAdministrador memoriaAdministrador)
        {
            this.memoriaAdministrador = memoriaAdministrador;
        }

        public IActionResult OnGet(int administradorId)
        {
            Administrador =
                memoriaAdministrador.GetAdministrador(administradorId);
            if (Administrador == null) return RedirectToPage("./NotFound");
            else return Page();            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaAdministrador.DeleteAdministrador(Administrador.Id);
            return RedirectToPage("./ListAdministradoresProvisional");
        }
        
    }
}
