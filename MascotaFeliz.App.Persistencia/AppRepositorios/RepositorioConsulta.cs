using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioConsulta : IRepositorioConsulta
    {
        // Referencia al contexto de Consulta
        private readonly AppContext _appContext;

        // Metodo Constructor
        // Utiiza Inyeccion de dependencias para indicar el contexto a utilizar
        // <param name="appContext"></param>//
        public RepositorioConsulta(AppContext appContext)
        {
            _appContext = appContext;
        }

        public ConsultaDomiciliaria AddConsulta(
            ConsultaDomiciliaria nuevaConsulta)
        {
            var consultaAdicionada =
                _appContext.ConsultasDomiciliarias.Add(nuevaConsulta);
            _appContext.SaveChanges();
            return consultaAdicionada.Entity;
        }

        //public ConsultaDomiciliaria AsignarMascota(
        public Mascota AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota)
        {
            var mascotaEncontrada =
                _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                //consultaAModificar.Mascota = mascotaEncontrada;
                consultaAModificar.MascotaId = idMascota;
                // _appContext.SaveChanges();
            }
            //return consultaAModificar;
            return mascotaEncontrada;
        }

        //public ConsultaDomiciliaria AsignarVeterinario(
        public Veterinario AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario)
        {
            var veterinarioEncontrado =
                _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
            if (veterinarioEncontrado != null)
            {
                //consultaAModificar.Veterinario = veterinarioEncontrado;
                consultaAModificar.VeterinarioId = idVeterinario;
                // _appContext.SaveChanges();
            }
            //return consultaAModificar;
            return veterinarioEncontrado;
        }

        public void DeleteConsulta(int idConsulta)
        {
            var consultaEncontrada = GetConsulta(idConsulta);
            if (consultaEncontrada == null) return;
            _appContext.ConsultasDomiciliarias.Remove(consultaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<ConsultaDomiciliaria> GetAllConsultas()
        {
            return _appContext.ConsultasDomiciliarias;
        }

        public ConsultaDomiciliaria GetConsulta(int idConsulta)
        {
            return _appContext.ConsultasDomiciliarias.FirstOrDefault(
                cd => cd.Id == idConsulta);
        }

        public IEnumerable<ConsultaDomiciliaria> GetConsultasPorMascota(
            IEnumerable<ConsultaDomiciliaria> previousList, int mascotaId)
        {
            var consultas = previousList; // Todas las consultas que se reciben
            // Si se tienen consultas
            if (consultas != null)
                // Si el filtro tiene algun valor
                if (mascotaId > 0) consultas = consultas.Where(
                    c => (c.MascotaId == mascotaId));
                    // Filtra las consultas que corresponden a la mascota
            return consultas;
        }

        public IEnumerable<ConsultaDomiciliaria> GetConsultasPorVeterinario(
            IEnumerable<ConsultaDomiciliaria> previousList, int veterinarioId)
        {
            var consultas = previousList; // Todas las consultas que se reciben
            // Si se tienen consultas
            if (consultas != null)
                // Si el filtro tiene algun valor
                if (veterinarioId > 0) consultas = consultas.Where(
                    c => (c.VeterinarioId == veterinarioId));
                    // Filtra las consultas que corresponden al veterinario
            return consultas;
        }

        public ConsultaDomiciliaria UpdateConsulta(
            ConsultaDomiciliaria consultaActualizada)
        {
            var consultaEncontrada = GetConsulta(consultaActualizada.Id);
            if (consultaEncontrada != null)
            {
                consultaEncontrada.Status = consultaActualizada.Status;
                consultaEncontrada.Fecha = consultaActualizada.Fecha;
                consultaEncontrada.Hora = consultaActualizada.Hora;
                consultaEncontrada.Temperatura =
                    consultaActualizada.Temperatura;
                consultaEncontrada.Peso = consultaActualizada.Peso;
                consultaEncontrada.FrecuenciaRespiratoria =
                    consultaActualizada.FrecuenciaRespiratoria;
                consultaEncontrada.FrecuenciaCardiaca =
                    consultaActualizada.FrecuenciaCardiaca;
                consultaEncontrada.EstadoAnimo =
                    consultaActualizada.EstadoAnimo;
                consultaEncontrada.Diagnostico =
                    consultaActualizada.Diagnostico;
                /*
                consultaEncontrada.Mascota =
                    consultaActualizada.Mascota;
                consultaEncontrada.Veterinario =
                    consultaActualizada.Veterinario;
                */
                consultaEncontrada.MascotaId =
                    consultaActualizada.MascotaId;
                consultaEncontrada.VeterinarioId =
                    consultaActualizada.VeterinarioId;
                _appContext.SaveChanges();
            }
            return consultaEncontrada;
        }

    }
}
