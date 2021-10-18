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
    public class DetailsConsultaProvisionalModel : PageModel
    {
        private readonly IMemoriaConsulta memoriaConsulta;
        [BindProperty]
        public ConsultaDomiciliariaOriginal ConsultaDomiciliaria {get;set;}

        public DetailsConsultaProvisionalModel(
            IMemoriaConsulta memoriaConsulta)
        {
            this.memoriaConsulta = memoriaConsulta;
        }

        public IActionResult OnGet(int consultaId)
        {
            ConsultaDomiciliaria = memoriaConsulta.GetConsulta(consultaId);
            if (ConsultaDomiciliaria == null)
                return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaConsulta.DeleteConsulta(ConsultaDomiciliaria.Id);
            return RedirectToPage("./ListConsultasProvisional");
        }

    }
}
