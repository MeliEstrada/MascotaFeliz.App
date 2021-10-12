using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaMascota : IMemoriaMascota
    {
        List<Propietario> propietarios;
        List<Mascota> mascotas;

        public MemoriaMascota()
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
        }

        public Mascota AddMascota(Mascota nuevaMascota)
        {
            nuevaMascota.Id = mascotas.Max(r => r.Id) + 1;
            mascotas.Add(nuevaMascota);
            return nuevaMascota;
        }

        public void DeleteMascota(int mascotaId)
        {
            var mascotaEncontrada = GetMascota(mascotaId);
            if (mascotaEncontrada != null)
                mascotas.Remove(mascotaEncontrada);
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return mascotas;
        }
        public Mascota GetMascota(int MascotaId)
        {
            return mascotas.SingleOrDefault(m => m.Id == MascotaId);
        }
        public IEnumerable<Mascota> GetMascotasPorFiltro(
            string filtro=null)
        // La asignación filtro=null indica que el parámetro filtro es opcional
        {
            var mascotas = GetAllMascotas(); // Todas las mascotas
            if (mascotas != null) // Si se tienen mascotas
            {
                // Si el filtro tiene algun valor
                if (!String.IsNullOrEmpty(filtro))
                {
                    mascotas = mascotas.Where(
                        m => (m.Nombre).Contains(filtro));
                    // Filtra las mascotas que contienen el filtro
                }
            }
            return mascotas;
        }
        public Mascota UpdateMascota(Mascota mascotaActualizado)
        {
            var mascota = mascotas.SingleOrDefault(r => r.Id == mascotaActualizado.Id);
            if (mascota != null)
            {
                mascota.Nombre=mascotaActualizado.Nombre;
                mascota.Raza=mascotaActualizado.Raza;
                mascota.TipoMascota=mascotaActualizado.TipoMascota;
                mascota.Propietario=mascotaActualizado.Propietario;
            }
            return mascota;
        }
    }

}