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

        public ConsultaDomiciliaria AsignarMascota(
            ConsultaDomiciliaria consultaAModificar, int idMascota)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(
                m => m.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                consultaAModificar.Mascota = mascotaEncontrada;
                // _appContext.SaveChanges();
            }
            return consultaAModificar;
        }

        public ConsultaDomiciliaria AsignarVeterinario(
            ConsultaDomiciliaria consultaAModificar, int idVeterinario)
        {
            var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(
                v => v.Id == idVeterinario);
            if (veterinarioEncontrado != null)
            {
                consultaAModificar.Veterinario = veterinarioEncontrado;
                // _appContext.SaveChanges();
            }
            return consultaAModificar;
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

        public IEnumerable<ConsultaDomiciliaria> GetConsultasPorFiltro(
            string filtro = null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var consultas = GetAllConsultas(); // Todas las consultas
            if (consultas != null) // Si se tienen consultas
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    consultas = consultas.Where(
                        c => (c.Mascota.Nombre).Contains(filtro));
                    // Filtra las consultas que contienen el filtro
                }
            }
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
                consultaEncontrada.Mascota =
                    consultaActualizada.Mascota;
                consultaEncontrada.Veterinario =
                    consultaActualizada.Veterinario;
                _appContext.SaveChanges();
            }
            return consultaEncontrada;
        }

    }
}
