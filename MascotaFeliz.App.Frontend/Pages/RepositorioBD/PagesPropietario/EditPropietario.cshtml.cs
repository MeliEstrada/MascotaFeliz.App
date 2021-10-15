using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class EditPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario Propietario {get;set;}

        public EditPropietarioModel()
        {
            repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? propietarioId)
        {
            if (!propietarioId.HasValue) Propietario = new Propietario();
            else Propietario =
                repositorioPropietario.GetPropietario(propietarioId.Value);
            if (Propietario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Propietario.Id > 0)
                Propietario = repositorioPropietario.UpdatePropietario(Propietario);
            else
                Propietario = repositorioPropietario.AddPropietario(Propietario);
            return RedirectToPage("./ListPropietarios");
        }

    }
}
