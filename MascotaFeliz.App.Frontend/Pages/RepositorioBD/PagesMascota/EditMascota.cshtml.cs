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
    public class EditMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario; // Adición
        [BindProperty]
        public Mascota Mascota {get;set;}
        //[BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Propietario> Propietarios {get;set;} // Adición

        public EditMascotaModel()
        {
            repositorioMascota = new RepositorioMascota(
                new MascotaFeliz.App.Persistencia.AppContext());
            // Adición
            repositorioPropietario = new RepositorioPropietario(
                new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int? mascotaId)
        {
            Propietarios = repositorioPropietario.GetAllPropietarios(); // Adición
            if (!mascotaId.HasValue) Mascota = new Mascota();
            else
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
                //propietarioId = Mascota.Propietario.Id; // Adición ahora innecesaria
            }
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            Propietarios = repositorioPropietario.GetAllPropietarios(); // Adición
            if (!ModelState.IsValid) return Page();
            //Mascota = repositorioMascota.AsignarPropietario(Mascota, propietarioId);
            repositorioMascota.AsignarPropietario(Mascota, Mascota.PropietarioId);
            if (Mascota.Id > 0) Mascota = repositorioMascota.UpdateMascota(Mascota);
            else Mascota = repositorioMascota.AddMascota(Mascota);
            return RedirectToPage("./ListMascotas");
        }

    }
}
