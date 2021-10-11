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
        public ConsultaDomiciliaria ConsultaDomiciliaria {get;set;} //tengo la duda de si ambos hacen referencia a la entidad del dominio

        public DetailsConsultaProvisionalModel(
            IMemoriaConsulta memoriaConsulta)
        {
            this.memoriaConsulta = memoriaConsulta;
        }

        public IActionResult OnGet(int consultaId)
        {
            ConsultaDomiciliaria = memoriaConsulta.GetConsulta(consultaId);
            if (ConsultaDomiciliaria == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            memoriaConsulta.DeleteConsulta(ConsultaDomiciliaria.Id);//aqui es donde me muestra el error que no conoce a consulta 
            return Page();
        }

    }
}
