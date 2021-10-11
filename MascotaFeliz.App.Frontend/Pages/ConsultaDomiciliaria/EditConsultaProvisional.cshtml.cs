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
        public ConsultaDomiciliaria ConsultaDomiciliaria {get;set;} //tengo la duda de si es la entidad la que se nombra en ConsultaDomiciliaria
        public EditConsultaProvisionalModel(
            IMemoriaConsulta memoriaConsulta)
        {
            this.memoriaConsulta = memoriaConsulta;
        }
                  

        public IActionResult OnGet(int? consultaId)
        {
            if (!consultaId.HasValue) ConsultaDomiciliaria = new ConsultaDomiciliaria(); //tengo la duda de si es la entidad la que se nombra en ConsultaDomiciliaria
            else ConsultaDomiciliaria =
            memoriaConsulta.GetConsulta(consultaId.Value);
            if (ConsultaDomiciliaria == null) return RedirectToPage("./NotFound"); //tengo la duda de si es la entidad la que se nombra en ConsultaDomiciliaria
            else
            
             return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            if (ConsultaDomiciliaria.Id > 0) //aqui sale el error en Details por que no reconoce Consulta.Id , lo cambie por la escritura de la entidad y funciono 
            {
                ConsultaDomiciliaria = memoriaConsulta.UpdateConsulta(ConsultaDomiciliaria); //tengo la duda del parametro que va entre parentesis 
            }
            else
            {
                ConsultaDomiciliaria = memoriaConsulta.AddConsulta(ConsultaDomiciliaria);
            }
            return Page();
        }

    }
}
