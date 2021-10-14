using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios

{
    public interface IRepositorioAdministrador
    {
        Administrador AddAdministrador(Administrador administrador);
        IEnumerable<Administrador> GetAllAdministradores();
        Administrador GetAdministrador(int idAdministrador);
        Administrador UpdateAdministrador(Administrador administrador);
        void DeleteAdministrador(int idAdministrador);
    }
}