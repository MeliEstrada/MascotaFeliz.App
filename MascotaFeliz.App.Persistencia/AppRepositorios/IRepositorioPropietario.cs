using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPropietario
    {
        Propietario AddPropietario(Propietario nuevoPropietario);
        IEnumerable<Propietario> GetAllPropietarios();
        IEnumerable<Propietario> GetPropietariosPorFiltro(string filtro);
        Propietario GetPropietario(int idPropietario);
        Propietario UpdatePropietario(Propietario propietarioActualizado);
        void DeletePropietario(int idPropietario);
    }
}
