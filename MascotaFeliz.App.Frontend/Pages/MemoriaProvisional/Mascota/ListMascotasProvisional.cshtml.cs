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
    public class ListMascotasProvisionalModel : PageModel
    {
        private readonly IMemoriaMascota memoriaMascota;
        public IEnumerable<MascotaOriginal> Mascotas {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListMascotasProvisionalModel(IMemoriaMascota memoriaMascota)
        {
            this.memoriaMascota = memoriaMascota;
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Mascotas = memoriaMascota.GetMascotasPorFiltro(filtroBusqueda);
        }
        
    }
}

