using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        Mascota AddMascota(Mascota mascota);
        IEnumerable<Mascota> GetAllMascotas();
        Mascota GetMascota(int idMascota);
        Mascota UpdateMascota(Mascota mascota);
        void DeleteMascota(int idMascota);
        Propietario AsignarPropietario(int idMascota, int idPropietario);
    }
}