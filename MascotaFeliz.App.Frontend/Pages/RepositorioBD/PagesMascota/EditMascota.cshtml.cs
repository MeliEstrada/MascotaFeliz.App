using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia.AppRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class EditMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario; // Adición
        [BindProperty]
        public Mascota Mascota {get;set;}
        [BindProperty(SupportsGet = true)] // Adición
        public int propietarioId {get;set;} // Adición
        [BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Propietario> Propietarios {get;set;} // Adición

        // Parámetro adicionado
        public EditMascotaModel(IRepositorioMascota repositorioMascota,
            IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioMascota = repositorioMascota;
            this.repositorioPropietario = repositorioPropietario; // Adición
        }

        public IActionResult OnGet(int? mascotaId)
        {
            Propietarios = repositorioPropietario.GetAllPropietarios(); // Adición
            if (!mascotaId.HasValue) Mascota = new Mascota();
            else
            {
                Mascota = repositorioMascota.GetMascota(mascotaId.Value);
                propietarioId = Mascota.Propietario.Id; // Adición
            }
            if (Mascota == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            Propietarios = repositorioPropietario.GetAllPropietarios(); // Adición
            if (!ModelState.IsValid) return Page();
            if (Mascota.Id > 0) Mascota = repositorioMascota.UpdateMascota(Mascota);
            else Mascota = repositorioMascota.AddMascota(Mascota);
            Mascota = repositorioMascota.AsignarPropietario(Mascota, propietarioId);
            Mascota = repositorioMascota.UpdateMascota(Mascota);
            return RedirectToPage("./ListMascotas");
        }

    }
}
