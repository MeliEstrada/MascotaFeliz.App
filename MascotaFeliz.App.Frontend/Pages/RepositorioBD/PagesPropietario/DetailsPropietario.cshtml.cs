using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
//using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetailsPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario Propietario {get;set;}

        public DetailsPropietarioModel()
        {
            repositorioPropietario = new RepositorioPropietario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? propietarioId)
        {
            Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            if (Propietario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (Propietario.Id > 0)
                repositorioPropietario.DeletePropietario(Propietario.Id);
            return RedirectToPage("./ListPropietarios");
        }
        
    }
}
