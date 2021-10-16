using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
//using MascotaFeliz.App.Persistencia.AppRepositorios;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetcore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListAdministradoresModel : PageModel
    {
        private readonly IRepositorioAdministrador repositorioAdministrador;
        public IEnumerable<Administrador> Administradores {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListAdministradoresModel()
        {
            repositorioAdministrador = new RepositorioAdministrador(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            //Administradores = repositorioAdministrador.GetAdministradoresPorFiltro(
            //    filtroBusqueda);
            Administradores = repositorioAdministrador.GetAllAdministradores();
        }

    }
}
