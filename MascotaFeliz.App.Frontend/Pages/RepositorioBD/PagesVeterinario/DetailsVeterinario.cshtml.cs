using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
//using MascotaFeliz.App.Persistencia.AppRepositorios;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetailsVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        [BindProperty]
        public Veterinario Veterinario {get;set;}

        public DetailsVeterinarioModel()
        {
            repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int veterinarioId)
        {
            Veterinario = repositorioVeterinario.GetVeterinario(veterinarioId);
            if (Veterinario == null) return RedirectToPage("./NotFound");
            else return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            repositorioVeterinario.DeleteVeterinario(Veterinario.Id);
            return RedirectToPage("./ListVeterinarios");
        }
        
    }
}
