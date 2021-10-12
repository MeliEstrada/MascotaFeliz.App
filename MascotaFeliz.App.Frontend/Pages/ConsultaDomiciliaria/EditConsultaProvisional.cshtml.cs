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
public class EditConsultaProvisionalModel : PageModel
    {
        private readonly IMemoriaConsulta memoriaConsulta;
        [BindProperty]
        public ConsultaDomiciliaria ConsultaDomiciliaria {get;set;}
        public EditConsultaProvisionalModel(
            IMemoriaConsulta memoriaConsulta)
        {
            this.memoriaConsulta = memoriaConsulta;
        }

        public IActionResult OnGet(int? consultaId)
        {
            if (!consultaId.HasValue) ConsultaDomiciliaria = new ConsultaDomiciliaria();
            else ConsultaDomiciliaria =
            memoriaConsulta.GetConsulta(consultaId.Value);
            if (ConsultaDomiciliaria == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (ConsultaDomiciliaria.Id > 0)
            {
                ConsultaDomiciliaria = memoriaConsulta.UpdateConsulta(ConsultaDomiciliaria);
            }
            else
            {
                ConsultaDomiciliaria = memoriaConsulta.AddConsulta(ConsultaDomiciliaria);
            }
            return Page();
        }

    }
}
