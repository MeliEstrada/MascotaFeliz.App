using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaPropietario
    {
        IEnumerable<Propietario> GetAllPropietarios();
        IEnumerable<Propietario> GetPropietariosPorFiltro(string filtro);
        Propietario GetPropietario(int propietarioId);
        Propietario UpdatePropietario(Propietario propietarioActualizado);
        Propietario AddPropietario(Propietario nuevoPropietario);
        void DeletePropietario(int propietarioId);
    }
}
