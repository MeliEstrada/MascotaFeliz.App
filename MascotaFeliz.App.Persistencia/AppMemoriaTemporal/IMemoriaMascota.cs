using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaMascota
    {
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
        Mascota GetMascota(int mascotaId);
        Mascota UpdateMascota(Mascota mascotaActualizada);
        Mascota AddMascota(Mascota nuevaMascota);
        void DeleteMascota(int mascotaId);
        Mascota AsignarPropietario(
            Mascota mascotaAModificar, int idPropietario);
    }
 }