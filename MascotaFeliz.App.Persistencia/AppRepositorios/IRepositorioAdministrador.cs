using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioAdministrador
    {
        Administrador AddAdministrador(Administrador nuevoAdministrador);
        IEnumerable<Administrador> GetAllAdministradores();
        IEnumerable<Administrador> GetAdministradoresPorFiltro(string filtro);
        Administrador GetAdministrador(int idAdministrador);
        Administrador UpdateAdministrador(Administrador administradorActualizado);
        void DeleteAdministrador(int idAdministrador);
    }
}
