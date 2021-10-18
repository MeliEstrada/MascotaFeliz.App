using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaVeterinario
    {
        IEnumerable<Veterinario> GetAllVeterinarios();
        IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro);
        Veterinario GetVeterinario(int veterinarioId);
        Veterinario UpdateVeterinario(Veterinario veterinarioActualizado);
        Veterinario AddVeterinario(Veterinario nuevoVeterinario);
        void DeleteVeterinario(int veterinarioId);
    }
}
