using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioConsulta
    {
        ConsultaDomiciliaria AddConsulta(ConsultaDomiciliaria nuevaConsulta);
        IEnumerable<ConsultaDomiciliaria> GetAllConsultas();
        IEnumerable<ConsultaDomiciliaria> GetConsultasPorFiltro(string filtro);
        ConsultaDomiciliaria GetConsulta(int idConsulta);
        ConsultaDomiciliaria UpdateConsulta(
            ConsultaDomiciliaria consultaActualizada);
        void DeleteConsulta(int idConsulta);
        ConsultaDomiciliaria AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota);
        ConsultaDomiciliaria AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario);
    }
}
