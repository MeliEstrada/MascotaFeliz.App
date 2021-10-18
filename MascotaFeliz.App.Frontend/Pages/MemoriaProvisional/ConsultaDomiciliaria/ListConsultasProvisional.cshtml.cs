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
    public class ListConsultasProvisionalModel : PageModel
    {
        private readonly IMemoriaConsulta memoriaConsulta;
        public IEnumerable<ConsultaDomiciliariaOriginal> Consultas {get; set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get; set;}

        public ListConsultasProvisionalModel(IMemoriaConsulta memoriaConsulta)
        {
            this.memoriaConsulta = memoriaConsulta;
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Consultas = memoriaConsulta.GetConsultasPorFiltro(filtroBusqueda);
        }

    }
}

