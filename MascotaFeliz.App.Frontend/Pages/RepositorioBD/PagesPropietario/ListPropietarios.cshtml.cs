using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
//using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class ListPropietariosModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario> Propietarios {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListPropietariosModel()
        {
            repositorioPropietario = new RepositorioPropietario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Propietarios = repositorioPropietario.GetPropietariosPorFiltro(
                filtroBusqueda);
            //Propietarios = repositorioPropietario.GetAllPropietarios();
        }

    }
}
