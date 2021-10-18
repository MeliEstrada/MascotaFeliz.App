using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaConsulta
    {
        IEnumerable<ConsultaDomiciliariaOriginal> GetAllConsultas();
        IEnumerable<ConsultaDomiciliariaOriginal> GetConsultasPorFiltro(
            string filtro);
        ConsultaDomiciliariaOriginal GetConsulta(int consultaId);
        ConsultaDomiciliariaOriginal UpdateConsulta(
            ConsultaDomiciliariaOriginal consultaActualizada);
        ConsultaDomiciliariaOriginal AddConsulta(
            ConsultaDomiciliariaOriginal nuevaConsulta);
        void DeleteConsulta(int consultaId);
        ConsultaDomiciliariaOriginal AsignarMascota(
            ConsultaDomiciliariaOriginal consultaAModificar, int idMascota);
        ConsultaDomiciliariaOriginal AsignarVeterinario(
            ConsultaDomiciliariaOriginal consultaAModificar, int idVeterinario);
    }
}
