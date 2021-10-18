using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia.AppRepositorios
{
    public class RepositorioMascota : IRepositorioMascota
    {
        // Referencia al contexto de Mascota
        private readonly AppContext _appContext;

        // Metodo Constructor
        // Utiiza Inyeccion de dependencias para indicar el contexto a utilizar
        // <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota nuevaMascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(nuevaMascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        //public Mascota AsignarPropietario(
        public Propietario AsignarPropietario(
            Mascota mascotaAModificar, int idPropietario)
        {
            var propietarioEncontrado = 
                _appContext.Propietarios.FirstOrDefault(p => p.Id == idPropietario);
            if (propietarioEncontrado != null)
            {
                //mascotaAModificar.Propietario = propietarioEncontrado;
                mascotaAModificar.PropietarioId = idPropietario;
                // _appContext.SaveChanges();
            }
            //return mascotaAModificar;
            return propietarioEncontrado;
        }

        public void DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = GetMascota(idMascota);
            if (mascotaEncontrada == null) return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

        public IEnumerable<Mascota> GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro = null)
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

        public Mascota UpdateMascota(Mascota mascotaActualizada)
        {
            var mascotaEncontrada = GetMascota(mascotaActualizada.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascotaActualizada.Nombre;
                mascotaEncontrada.TipoMascota = mascotaActualizada.TipoMascota;
                mascotaEncontrada.Raza = mascotaActualizada.Raza;
                mascotaEncontrada.Genero = mascotaActualizada.Genero;
                mascotaEncontrada.AnioNacimiento =
                    mascotaActualizada.AnioNacimiento;
                //mascotaEncontrada.Propietario = mascotaActualizada.Propietario;
                mascotaEncontrada.PropietarioId = mascotaActualizada.PropietarioId;
                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }

    }
}
