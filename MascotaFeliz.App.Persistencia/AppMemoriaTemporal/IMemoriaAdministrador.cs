using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaAdministrador
    {
        IEnumerable<Administrador> GetAllAdministradores();
        IEnumerable<Administrador> GetAdministradoresPorFiltro(string filtro);
        Propietario GetAdministrador(int administradorId);
        Propietario UpdateAdminsitrador(Propietario administradorActualizado);
        Propietario AddAdministrador(Propietario nuevoAdministrador);
        void DeleteAdministrador(int administradorId);
    }
}