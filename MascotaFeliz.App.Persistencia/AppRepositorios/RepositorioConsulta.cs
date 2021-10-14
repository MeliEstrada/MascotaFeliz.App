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

        ConsultaDomiciliaria IRepositorioConsulta.AddConsulta(
            ConsultaDomiciliaria consulta)
        {
            var consultaAdicionada =
                _appContext.ConsultasDomiciliarias.Add(consulta);
            _appContext.SaveChanges();
            return consultaAdicionada.Entity;
        }

        IEnumerable<ConsultaDomiciliaria> IRepositorioConsulta.GetAllConsultas()
        {
            return _appContext.ConsultasDomiciliarias;
        }

        ConsultaDomiciliaria IRepositorioConsulta.GetConsulta(int idConsulta)
        {
            return _appContext.ConsultasDomiciliarias.FirstOrDefault(
                cd => cd.Id == idConsulta);
        }

        ConsultaDomiciliaria IRepositorioConsulta.UpdateConsulta(
            ConsultaDomiciliaria consulta)
        {
            var consultaEncontrada =
                _appContext.ConsultasDomiciliarias.FirstOrDefault(
                    cd => cd.Id == consulta.Id);
            if (consultaEncontrada != null)
            {
                consultaEncontrada.Status = consulta.Status;
                consultaEncontrada.Fecha = consulta.Fecha;
                consultaEncontrada.Hora = consulta.Hora;
                consultaEncontrada.Temperatura = consulta.Temperatura;
                consultaEncontrada.Peso = consulta.Peso;
                consultaEncontrada.FrecuenciaRespiratoria =
                    consulta.FrecuenciaRespiratoria;
                consultaEncontrada.FrecuenciaCardiaca =
                    consulta.FrecuenciaCardiaca;
                consultaEncontrada.EstadoAnimo = consulta.EstadoAnimo;
                consultaEncontrada.Diagnostico = consulta.Diagnostico;
                consultaEncontrada.Mascota = consulta.Mascota;
                consultaEncontrada.Veterinario = consulta.Veterinario;
                _appContext.SaveChanges();
            }
            return consultaEncontrada;
        }

        void IRepositorioConsulta.DeleteConsulta(int idConsulta)
        {
            var consultaEncontrada =
                _appContext.ConsultasDomiciliarias.FirstOrDefault(
                    cd => cd.Id == idConsulta);
            if (consultaEncontrada == null)
                return;
            _appContext.ConsultasDomiciliarias.Remove(consultaEncontrada);
            _appContext.SaveChanges();
        }

        Mascota IRepositorioConsulta.AsignarMascota(
            int idConsulta, int idMascota)
        {
            var consultaEncontrada =
                _appContext.ConsultasDomiciliarias.FirstOrDefault(
                    cd => cd.Id == idConsulta);
            if (consultaEncontrada != null)
            {
                var mascotaEncontrada =
                    _appContext.Mascotas.FirstOrDefault(
                        m => m.Id == idMascota);
                if (mascotaEncontrada != null)
                {
                    consultaEncontrada.Mascota = mascotaEncontrada;
                    _appContext.SaveChanges();
                }
                return mascotaEncontrada;
            }
            return null;
        }

        Veterinario IRepositorioConsulta.AsignarVeterinario(
            int idConsulta, int idVeterinario)
        {
            var consultaEncontrada =
                _appContext.ConsultasDomiciliarias.FirstOrDefault(
                    cd => cd.Id == idConsulta);
            if (consultaEncontrada != null)
            {
                var veterinarioEncontrado =
                    _appContext.Veterinarios.FirstOrDefault(
                        v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    consultaEncontrada.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

    }
}