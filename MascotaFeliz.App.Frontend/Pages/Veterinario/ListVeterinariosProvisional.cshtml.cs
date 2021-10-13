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
    public class ListVeterinariosProvisionalModel : PageModel
    {
        private readonly IMemoriaVeterinario memoriaVeterinario;
        public IEnumerable<Veterinario> Veterinarios {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListVeterinariosProvisionalModel(
            IMemoriaVeterinario memoriaVeterinario)
        {
            this.memoriaVeterinario = memoriaVeterinario;
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Veterinarios = memoriaVeterinario.GetVeterinariosPorFiltro(
                filtroBusqueda);
        }
        
    }
}
