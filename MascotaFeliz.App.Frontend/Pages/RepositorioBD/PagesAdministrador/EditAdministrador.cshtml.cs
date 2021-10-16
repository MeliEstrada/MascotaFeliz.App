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
    public class EditAdministradorModel : PageModel
    {
        private readonly IRepositorioAdministrador repositorioAdministrador;
        [BindProperty]
        public Administrador Administrador {get;set;}

        public EditAdministradorModel()
        {
            repositorioAdministrador = new RepositorioAdministrador(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? administradorId)
        {
            if (!administradorId.HasValue) Administrador = new Administrador();
            else Administrador =
                repositorioAdministrador.GetAdministrador(administradorId.Value);
            if (Administrador == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Administrador.Id > 0)
                Administrador = repositorioAdministrador.UpdateAdministrador(Administrador);
            else
                Administrador = repositorioAdministrador.AddAdministrador(Administrador);
            return RedirectToPage("./ListAdministradores");
        }

    }
}
