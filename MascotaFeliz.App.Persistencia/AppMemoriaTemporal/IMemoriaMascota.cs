using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaMascota
    {
        IEnumerable<MascotaOriginal> GetAllMascotas();
        IEnumerable<MascotaOriginal> GetMascotasPorFiltro(string filtro);
        MascotaOriginal GetMascota(int mascotaId);
        MascotaOriginal UpdateMascota(MascotaOriginal mascotaActualizada);
        MascotaOriginal AddMascota(MascotaOriginal nuevaMascota);
        void DeleteMascota(int mascotaId);
        MascotaOriginal AsignarPropietario(
            MascotaOriginal mascotaAModificar, int idPropietario);
    }
 }
 