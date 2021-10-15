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
    public class ListAdministradoresProvisionalModel : PageModel
    {
        private readonly IMemoriaAdministrador memoriaAdministrador;
        public IEnumerable<Administrador> Administradores {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListAdministradoresProvisionalModel(
            IMemoriaAdministrador memoriaAdministrador)
        {
            this.memoriaAdministrador = memoriaAdministrador;
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Administradores = memoriaAdministrador.GetAdministradoresPorFiltro(
                filtroBusqueda);
        }

    }
}

