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
        private readonly IMemoriaMascota memoriaMascota; // Adición
        private readonly IMemoriaVeterinario memoriaVeterinario; // Adición
        [BindProperty]
        public ConsultaDomiciliaria ConsultaDomiciliaria {get;set;}
        [BindProperty(SupportsGet = true)] // Adición
        public int mascotaId {get;set;} // Adición
        [BindProperty(SupportsGet = true)] // Adición
        public int veterinarioId {get;set;} // Adición
        [BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Mascota> Mascotas {get;set;} // Adición
        [BindProperty(SupportsGet = true)] // Adición
        public IEnumerable<Veterinario> Veterinarios {get;set;} // Adición

        // Parámetro adicionado8
        public EditConsultaProvisionalModel(IMemoriaConsulta memoriaConsulta,
            IMemoriaMascota memoriaMascota,
            IMemoriaVeterinario memoriaVeterinario)
        {
            this.memoriaConsulta = memoriaConsulta;
            this.memoriaMascota = memoriaMascota; // Adición
            this.memoriaVeterinario = memoriaVeterinario; // Adición
        }

        public IActionResult OnGet(int? consultaId)
        {
            Mascotas = memoriaMascota.GetAllMascotas(); // Adición
            Veterinarios = memoriaVeterinario.GetAllVeterinarios(); // Adición
            if (!consultaId.HasValue)
                ConsultaDomiciliaria = new ConsultaDomiciliaria();
            else
            {
                ConsultaDomiciliaria =
                    memoriaConsulta.GetConsulta(consultaId.Value);
                mascotaId = ConsultaDomiciliaria.Mascota.Id; // Adición
                veterinarioId = ConsultaDomiciliaria.Veterinario.Id; // Adición
            }
            if (ConsultaDomiciliaria == null) return RedirectToPage("./NotFound");
            else return Page();
        }

        public IActionResult OnPost()
        {
            Mascotas = memoriaMascota.GetAllMascotas(); // Adición
            Veterinarios = memoriaVeterinario.GetAllVeterinarios(); // Adición
            if (!ModelState.IsValid) return Page();
            if (ConsultaDomiciliaria.Id > 0) ConsultaDomiciliaria =
                    memoriaConsulta.UpdateConsulta(ConsultaDomiciliaria);
            else ConsultaDomiciliaria =
                memoriaConsulta.AddConsulta(ConsultaDomiciliaria);
            ConsultaDomiciliaria = memoriaConsulta.AsignarMascota(
                ConsultaDomiciliaria, mascotaId);
            ConsultaDomiciliaria = memoriaConsulta.AsignarVeterinario(
                ConsultaDomiciliaria, veterinarioId);
            ConsultaDomiciliaria = memoriaConsulta.UpdateConsulta(
                ConsultaDomiciliaria);
            return RedirectToPage("./ListConsultasProvisional");
        }

    }
}
