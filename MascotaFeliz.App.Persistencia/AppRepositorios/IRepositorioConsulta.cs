using System.Collections.Generic;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public interface IRepositorioConsulta
    {
        ConsultaDomiciliaria AddConsulta(ConsultaDomiciliaria consulta);
        IEnumerable<ConsultaDomiciliaria> GetAllConsultas();
        ConsultaDomiciliaria GetConsulta(int idConsulta);
        ConsultaDomiciliaria UpdateConsulta(ConsultaDomiciliaria consulta);
        void DeleteConsulta(int idConsulta);
        Mascota AsignarMascota(int idConsulta, int idMascota);
        Veterinario AsignarVeterinario(int idConsulta, int idVeterinario);
    }
}