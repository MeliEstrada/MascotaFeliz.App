using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioMascota
    {
        Mascota AddMascota(Mascota nuevaMascota);
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtroNombreMascota);
        Mascota GetMascota(int idMascota);
        Mascota UpdateMascota(Mascota mascotaActualizada);
        void DeleteMascota(int idMascota);
        Mascota AsignarPropietario(Mascota mascotaAModificar, int idPropietario);
    }
}
