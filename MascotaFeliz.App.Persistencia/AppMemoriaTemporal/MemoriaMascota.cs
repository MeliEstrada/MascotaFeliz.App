using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppMemoriaTemporal
{
    public class MemoriaMascota : IMemoriaMascota
    {
        private readonly IMemoriaPropietario memoriaPropietario;
        List<Propietario> propietarios;
        List<MascotaOriginal> mascotas;

        public MemoriaMascota(IMemoriaPropietario memoriaPropietario)
        {
            this.memoriaPropietario = memoriaPropietario;
            
            propietarios = (List<Propietario>)memoriaPropietario.GetAllPropietarios();
            
            mascotas = new List<MascotaOriginal>()
            {
                new MascotaOriginal{Id=1, Nombre="Hinata",
                    TipoMascota=TipoMascota.Gato, Raza="Persa",
                    Genero=GeneroMascota.Hembra, Propietario=propietarios[0]},
                new MascotaOriginal{Id=2, Nombre="Manchas",
                    TipoMascota=TipoMascota.Perro, Raza="Dalmatan",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[1]},
                new MascotaOriginal{Id=3, Nombre="Max",
                TipoMascota=TipoMascota.Perro, Raza="Labrador",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[2]},
                new MascotaOriginal{Id=4, Nombre="Miss",
                    TipoMascota=TipoMascota.Gato, Raza="Siamés",
                    Genero=GeneroMascota.Hembra,Propietario=propietarios[3]},
                new MascotaOriginal{Id=5, Nombre="Firulais",
                    TipoMascota=TipoMascota.Perro, Raza="Pastor Aleman",
                    Genero=GeneroMascota.Macho, Propietario=propietarios[4]}
            };
        }

        public MascotaOriginal AddMascota(MascotaOriginal nuevaMascota)
        {
            nuevaMascota.Id = mascotas.Max(r => r.Id) + 1;
            mascotas.Add(nuevaMascota);
            return nuevaMascota;
        }

        public MascotaOriginal AsignarPropietario(
            MascotaOriginal mascotaAModificar, int idPropietario)
        {
            var propietarioEncontrado =
                propietarios.FirstOrDefault(p => p.Id == idPropietario);
            if (propietarioEncontrado != null)
                mascotaAModificar.Propietario = propietarioEncontrado;
            return mascotaAModificar;
        }

        public void DeleteMascota(int mascotaId)
        {
            var mascotaEncontrada = GetMascota(mascotaId);
            if (mascotaEncontrada != null)
                mascotas.Remove(mascotaEncontrada);
        }

        public IEnumerable<MascotaOriginal> GetAllMascotas()
        {
            return mascotas;
        }
        public MascotaOriginal GetMascota(int mascotaId)
        {
            return mascotas.SingleOrDefault(m => m.Id == mascotaId);
        }
        public IEnumerable<MascotaOriginal> GetMascotasPorFiltro(
            string filtro = null)
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
        public MascotaOriginal UpdateMascota(MascotaOriginal mascotaActualizada)
        {
            var mascota =  GetMascota(mascotaActualizada.Id);
            if (mascota != null)
            {
                mascota.Nombre = mascotaActualizada.Nombre;
                mascota.Raza = mascotaActualizada.Raza;
                mascota.TipoMascota = mascotaActualizada.TipoMascota;
                mascota.Propietario = mascotaActualizada.Propietario;
            }
            return mascota;
        }

    }
}
