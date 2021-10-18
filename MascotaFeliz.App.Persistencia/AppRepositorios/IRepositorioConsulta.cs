using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioConsulta
    {
        ConsultaDomiciliaria AddConsulta(ConsultaDomiciliaria nuevaConsulta);
        IEnumerable<ConsultaDomiciliaria> GetAllConsultas();
        IEnumerable<ConsultaDomiciliaria> GetConsultasPorMascota(
            IEnumerable<ConsultaDomiciliaria> previousList, int idMascota);
        IEnumerable<ConsultaDomiciliaria> GetConsultasPorVeterinario(
            IEnumerable<ConsultaDomiciliaria> previousList, int idVeterinario);
        ConsultaDomiciliaria GetConsulta(int idConsulta);
        ConsultaDomiciliaria UpdateConsulta(
            ConsultaDomiciliaria consultaActualizada);
        void DeleteConsulta(int idConsulta);
        /*
        ConsultaDomiciliaria AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota);
        ConsultaDomiciliaria AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario);
        */
        Mascota AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota);
        Veterinario AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario);
    }
}
