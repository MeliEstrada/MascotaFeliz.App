using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioVeterinario
    {
        Veterinario AddVeterinario(Veterinario nuevoVeterinario);
        IEnumerable<Veterinario> GetAllVeterinarios();
        IEnumerable<Veterinario> GetVeterinariosPorFiltro(string filtro);
        Veterinario GetVeterinario(int idVeterinario);
        Veterinario UpdateVeterinario(Veterinario VeterinarioActualizado);
        void DeleteVeterinario(int idVeterinario);
    }
}
