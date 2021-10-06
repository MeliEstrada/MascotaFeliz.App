using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioPropietario
    {
        Propietario AddPropietario(Propietario propietario);
        IEnumerable<Propietario> GetAllPropietarios();
        Propietario GetPropietario(int idPropietario);
        Propietario UpdatePropietario(Propietario propietario);
        void DeletePropietario(int idPropietario);
    }
}