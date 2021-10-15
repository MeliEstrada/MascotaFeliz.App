using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaAdministrador
    {
        IEnumerable<Administrador> GetAllAdministradores();
        IEnumerable<Administrador> GetAdministradoresPorFiltro(string filtro);
        Administrador GetAdministrador(int administradorId);
        Administrador UpdateAdministrador(
            Administrador administradorActualizado);
        Administrador AddAdministrador(Administrador nuevoAdministrador);
        void DeleteAdministrador(int administradorId);
    }
}
