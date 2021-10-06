using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaPropietario
    {
        IEnumerable<Propietario> GetAll();
    }
}