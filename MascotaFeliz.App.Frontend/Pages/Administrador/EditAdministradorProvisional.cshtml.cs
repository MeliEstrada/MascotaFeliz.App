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
    public class EditAdministradorProvisionalModel : PageModel
    {
        private readonly IMemoriaAdministrador memoriaAdministrador;
        [BindProperty]
        public Administrador Administrador {get; set;}

        public EditAdministradorProvisionalModel(IMemoriaAdministrador memoriaAdministrador)
        {
            this.memoriaAdministrador = memoriaAdministrador;
        }

        public IActionResult OnGet(int? administradorId)
        {
            if (!administradorId.HasValue) Administrador = new Administrador();
            else Administrador = memoriaAdministrador.GetAdministrador(administradorId.Value);

            if (Administrador == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Administrador.Id > 0)
                Administrador = memoriaAdministrador.UpdateAdministrador(Administrador);
            else
                Administrador = memoriaAdministrador.AddAdministrador(Administrador);
            return RedirectToPage("./ListAdministradoresProvisional");
        }
        
    }
}
