using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaConsulta : IMemoriaConsulta
    {
        private readonly IMemoriaMascota memoriaMascota;
        private readonly IMemoriaVeterinario memoriaVeterinario;
        List<MascotaOriginal> mascotas;
        List<Veterinario> veterinarios;
        List<ConsultaDomiciliariaOriginal> consultas;

        public MemoriaConsulta(IMemoriaMascota memoriaMascota,
            IMemoriaVeterinario memoriaVeterinario)
        {
            this.memoriaMascota = memoriaMascota;
            this.memoriaVeterinario = memoriaVeterinario;

            mascotas = (List<MascotaOriginal>)memoriaMascota.GetAllMascotas();
            veterinarios =
                (List<Veterinario>)memoriaVeterinario.GetAllVeterinarios();

            consultas = new List<ConsultaDomiciliariaOriginal>
            {
                new ConsultaDomiciliariaOriginal{Id=1, Mascota=mascotas[0],
                    Veterinario=veterinarios[0], Status=StatusConsulta.Efectuada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F, Peso=3.4F},
                new ConsultaDomiciliariaOriginal{Id=2, Mascota=mascotas[1],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Agendada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F , Peso=3.4F},
                new ConsultaDomiciliariaOriginal{Id=3, Mascota=mascotas[2],
                    Veterinario=veterinarios[0], Status=StatusConsulta.Solicitada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F , Peso=3.4F},
            };
        }

        public ConsultaDomiciliariaOriginal AddConsulta(
            ConsultaDomiciliariaOriginal nuevaConsulta)
        {
            nuevaConsulta.Id = consultas.Max(c => c.Id) + 1;
            consultas.Add(nuevaConsulta);
            return nuevaConsulta;
        }

        public ConsultaDomiciliariaOriginal AsignarMascota(
            ConsultaDomiciliariaOriginal consultaAModificar, int idMascota)
        {
            var mascotaEncontrada =
                mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada != null)
                consultaAModificar.Mascota = mascotaEncontrada;
            return consultaAModificar;
        }

        public ConsultaDomiciliariaOriginal AsignarVeterinario(
            ConsultaDomiciliariaOriginal consultaAModificar, int idVeterinario)
        {
            var veterinarioEncontrado =
                veterinarios.FirstOrDefault(m => m.Id == idVeterinario);
            if (veterinarioEncontrado != null)
                consultaAModificar.Veterinario = veterinarioEncontrado;
            return consultaAModificar;
        }

        public void DeleteConsulta(int consultaId)
        {
            var consultaEncontrada = GetConsulta(consultaId);
            if (consultaEncontrada != null)
                consultas.Remove(consultaEncontrada);
        }

        public IEnumerable<ConsultaDomiciliariaOriginal> GetAllConsultas()
        {
            return consultas;
        }

        public ConsultaDomiciliariaOriginal GetConsulta(int consultaId)
        {
            return consultas.SingleOrDefault(c => c.Id == consultaId);
        }

        public IEnumerable<ConsultaDomiciliariaOriginal> GetConsultasPorFiltro(
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

        public ConsultaDomiciliariaOriginal UpdateConsulta(
            ConsultaDomiciliariaOriginal consultaActualizada)
        {
            var consulta = GetConsulta(consultaActualizada.Id);
            if (consulta != null)
            {
                consulta.Status = consultaActualizada.Status;
                consulta.Fecha = consultaActualizada.Fecha;
                consulta.Hora = consultaActualizada.Hora;
                consulta.Temperatura = consultaActualizada.Temperatura;
                consulta.Peso = consultaActualizada.Peso;
                consulta.FrecuenciaRespiratoria =
                    consultaActualizada.FrecuenciaRespiratoria;
                consulta.FrecuenciaCardiaca =
                    consultaActualizada.FrecuenciaCardiaca;
                consulta.EstadoAnimo = consultaActualizada.EstadoAnimo;
                consulta.Diagnostico = consultaActualizada.Diagnostico;
                consulta.Mascota = consultaActualizada.Mascota;	
		        consulta.Veterinario = consultaActualizada.Veterinario;
            }
            return consulta;
        }
        
    }
}
