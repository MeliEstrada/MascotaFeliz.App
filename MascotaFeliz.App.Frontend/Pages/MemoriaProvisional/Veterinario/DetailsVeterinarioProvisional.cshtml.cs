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
    public class DetailsVeterinarioProvisionalModel : PageModel
    {
        private readonly IMemoriaVeterinario memoriaVeterinario;
        [BindProperty]
        public Veterinario Veterinario {get;set;}

        public DetailsVeterinarioProvisionalModel(
            IMemoriaVeterinario memoriaVeterinario)
        {
            this.memoriaVeterinario = memoriaVeterinario;
        }

        public IActionResult OnGet(int veterinarioId)
        {
            Veterinario = memoriaVeterinario.GetVeterinario(veterinarioId);
            if (Veterinario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaVeterinario.DeleteVeterinario(Veterinario.Id);
            return RedirectToPage("./ListVeterinariosProvisional");
        }
        
    }
}
