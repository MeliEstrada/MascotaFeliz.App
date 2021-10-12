using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaConsulta : IMemoriaConsulta
    {
        List<Propietario> propietarios;
        List<Mascota> mascotas;
        List<Veterinario> veterinarios;
        List<ConsultaDomiciliaria> consultas;

        public MemoriaConsulta()
        {
             propietarios = new List<Propietario>
            {
                new Propietario{Id=1, Nombre="Andrea Jaqueline",
                Apellidos="Solarte Canaval", NumeroTelefono="3133853491",
                CorreoElectronico="Andrea.solarte72@gmail.com"},
                new Propietario{Id=2, Nombre="Daniela Marcela",
                Apellidos="Becerra Sosa", NumeroTelefono="3214952185",
                CorreoElectronico="danielabecerrasosa@gmail.com"},
                new Propietario{Id=3, Nombre="Juan Carlos",
                Apellidos="Carvajal Tapias", NumeroTelefono="3158556483",
                CorreoElectronico="juanc.carvajal72@gmail.com"},
                new Propietario{Id=4, Nombre="Melissa Andrea",
                Apellidos="Estrada Marín", NumeroTelefono="3004610198",
                CorreoElectronico="andreita_9815@hotmail.com"},
                new Propietario{Id=5, Nombre="Robin",
                Apellidos="Benítez Mora", NumeroTelefono="3008060020",
                CorreoElectronico="robinbenitez@yahoo.com"}
            };

            mascotas = new List<Mascota>()
            {
                new Mascota{Id=1, Nombre="Hinata",
                    TipoMascota=TipoMascota.Gato, Raza="Persa",
                    Genero=GeneroMascota.Hembra, Propietario=propietarios[0]},
                new Mascota{Id=2, Nombre="Manchas",
                    TipoMascota=TipoMascota.Perro, Raza="Dalmatan",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[1]},
                new Mascota{Id=3, Nombre="Max",
                TipoMascota=TipoMascota.Perro, Raza="Labrador",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[2]},
                new Mascota{Id=4, Nombre="Miss",
                    TipoMascota=TipoMascota.Gato, Raza="Siamés",
                    Genero=GeneroMascota.Hembra,Propietario=propietarios[3]},
                new Mascota{Id=5, Nombre="Firulais",
                    TipoMascota=TipoMascota.Perro, Raza="Pastor Aleman",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[4]}
            };

            veterinarios = new List<Veterinario>
            {
                new Veterinario{Id=1, Nombre="Juanita",
                    Apellidos="Guarnizo", NumeroTelefono="3133213491",
                    CorreoElectronico="Juanita.guarnizo@gmail.com",
                    TarjetaProfesional="78901"},
                
                new Veterinario{Id=2, Nombre="Samuel",
                    Apellidos="Marin", NumeroTelefono="3103205678",
                    CorreoElectronico="Samuel.marin@gmail.com",
                    TarjetaProfesional="12345"},
            };

            consultas = new List<ConsultaDomiciliaria>
            {
                new ConsultaDomiciliaria{Id=1, Mascota=mascotas[1],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Efectuada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F, Peso=3.4F},
                new ConsultaDomiciliaria{Id=2, Mascota=mascotas[2],
                    Veterinario=veterinarios[2], Status=StatusConsulta.Agendada,
                    Fecha=System.DateTime.Today, Hora=System.DateTime.Now,
                    Temperatura=37.5F , Peso=3.4F},
                new ConsultaDomiciliaria{Id=3, Mascota=mascotas[3],
                    Veterinario=veterinarios[1], Status=StatusConsulta.Solicitada,
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

        public IEnumerable<ConsultaDomiciliaria> GetConsultasPorFiltro(
            string filtro=null)
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
                    // Filtra los propietarios que contienen el filtro
                }
            }
            return consultas;
        }

        public ConsultaDomiciliaria UpdateConsulta(
            ConsultaDomiciliaria consultaActualizada)
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