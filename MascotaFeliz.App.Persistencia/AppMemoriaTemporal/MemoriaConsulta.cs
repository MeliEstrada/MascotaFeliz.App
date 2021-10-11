using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaConsulta : IMemoriaConsulta
    {
        List<Mascota> mascotas;
        List<Veterinario> veterinarios;
        List<ConsultaDomiciliaria> consultas;

        public MemoriaConsulta()
        {
            mascotas = new List<Mascota>
            {
                new Mascota{Nombre="Firulais", TipoMascota=TipoMascota.Perro},
                new Mascota{Nombre="Minino", TipoMascota=TipoMascota.Gato},
                new Mascota{Nombre="Rocko", TipoMascota=TipoMascota.Perro}
            };
            veterinarios = new List<Veterinario>
            {
                new Veterinario{Nombre="Marcos Antonio ", Apellidos="Suarez"},
                new Veterinario{Nombre="Marcos Antonio ", Apellidos="Suarez"},
                new Veterinario{Nombre="Maria Isabel", Apellidos="Jimenez"}
            };
            consultas = new List<ConsultaDomiciliaria>
            {
                new ConsultaDomiciliaria{Id=1, Mascota=mascotas[1],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Agendada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F, Peso=3.4F},
                new ConsultaDomiciliaria{Id=2, Mascota=mascotas[1],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Agendada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F , Peso=3.4F},
                new ConsultaDomiciliaria{Id=3, Mascota=mascotas[1],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Agendada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F , Peso=3.4F},
            };
        }

        public ConsultaDomiciliaria AddConsulta(ConsultaDomiciliaria nuevaConsulta)
        {
            nuevaConsulta.Id = consultas.Max(c => c.Id) + 1;
            consultas.Add(nuevaConsulta);
            return nuevaConsulta;
        }

        public void DeleteConsulta(int consultaId)
        {
          var consultaEncontrada = GetConsulta(consultaId);
            if (consultaEncontrada != null)
                consultas.Remove(consultaEncontrada);
        }

        public IEnumerable<ConsultaDomiciliaria> GetAllConsultas()
        {
            return consultas;
        }

        public ConsultaDomiciliaria GetConsulta(int consultaId)
        {
            return consultas.SingleOrDefault(c => c.Id == consultaId);
        }

        public IEnumerable<ConsultaDomiciliaria> GetConsultasPorFiltro(string filtro=null)
        
             // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var consultas = GetAllConsultas(); // Todas las consultas
            if (consultas != null) // Si se tienen consultas
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    consultas = consultas.Where(
                        c => (c.Fecha + " " + c.Hora + c.Mascota).Contains(filtro)); //elegi los atributos fecha hora y mascota //
                    // Filtra los propietarios que contienen el filtro
                }
            }
            return consultas;
        }

        public ConsultaDomiciliaria UpdateConsulta(ConsultaDomiciliaria consultaActualizada)
        {
            var consulta = GetConsulta(consultaActualizada.Id);
            if (consulta != null)
            {
                consulta.Status = consultaActualizada.Status;
                consulta.Fecha = consultaActualizada.Fecha;
                consulta.Hora = consultaActualizada.Hora;
                consulta.Mascota = consultaActualizada.Mascota;	
		        consulta.Veterinario = consultaActualizada.Veterinario;
                //no estoy segura si estos atributos quedaron bien, es necesario revisarlos!!!.
            }
            return consulta;
        
        }
    }
}