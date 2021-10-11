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
    public class EditVeterinarioProvisionalModel : PageModel
    {
        private readonly IMemoriaVeterinario memoriaVeterinario;
        [BindProperty]
        public Veterinario Veterinario {get;set;}
        
        public EditVeterinarioProvisionalModel(
            IMemoriaVeterinario memoriaVeterinario)
        {
            this.memoriaVeterinario = memoriaVeterinario;
        }
         
        public IActionResult OnGet(int? veterinarioId)
        {
            if (!veterinarioId.HasValue) Veterinario = new Veterinario();
            else Veterinario =
                memoriaVeterinario.GetVeterinario(veterinarioId.Value);
            if (Veterinario == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (Veterinario.Id > 0)
            {
                Veterinario = memoriaVeterinario.UpdateVeterinario(Veterinario);
            }
            else
            {
                Veterinario = memoriaVeterinario.AddVeterinario(Veterinario);
            }
            return Page();
        }

    }
}

