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
    public class DetailsAdministradorModel : PageModel
    {
        private readonly IRepositorioAdministrador repositorioAdministrador;
        [BindProperty]
        public Administrador Administrador {get;set;}

        public DetailsAdministradorModel()
        {
            repositorioAdministrador = new RepositorioAdministrador(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int administradorId)
        {
            Administrador = repositorioAdministrador.GetAdministrador(administradorId);
            if (Administrador == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (Administrador.Id > 0)
                repositorioAdministrador.DeleteAdministrador(Administrador.Id);
            return RedirectToPage("./ListAdministradores");
        }
        
    }
}
