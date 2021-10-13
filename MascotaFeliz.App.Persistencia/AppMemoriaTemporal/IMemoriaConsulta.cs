using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public interface IMemoriaConsulta
    {
        IEnumerable<ConsultaDomiciliaria> GetAllConsultas();
        IEnumerable<ConsultaDomiciliaria> GetConsultasPorFiltro(string filtro);
        ConsultaDomiciliaria GetConsulta(int consultaId);
        ConsultaDomiciliaria UpdateConsulta(
            ConsultaDomiciliaria consultaActualizada);
        ConsultaDomiciliaria AddConsulta(ConsultaDomiciliaria nuevaConsulta);
        void DeleteConsulta(int consultaId);
        ConsultaDomiciliaria AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota);
        ConsultaDomiciliaria AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario);
    }
}