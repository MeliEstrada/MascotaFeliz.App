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
    public class ListMascotasModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario; // Adición
        public IEnumerable<Mascota> Mascotas {get;set;}
        [BindProperty(SupportsGet = true)]
        public string FiltroBusqueda {get;set;}

        public ListMascotasModel()
        {
            repositorioMascota = new RepositorioMascota(
                new MascotaFeliz.App.Persistencia.AppContext());
            // Adición
            repositorioPropietario = new RepositorioPropietario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public void OnGet(string filtroBusqueda)
        {
            FiltroBusqueda = filtroBusqueda;
            Mascotas = repositorioMascota.GetMascotasPorFiltro(filtroBusqueda);
            //Mascotas = repositorioMascota.GetAllMascotas();
        }

        public string GetNombreApellidosPropietario(int propietarioId)
        {
            var propietario = repositorioPropietario.GetPropietario(propietarioId);
            var NombreApellidos = propietario.Nombre + " " + propietario.Apellidos;
            return NombreApellidos;
        }
        
    }
}
