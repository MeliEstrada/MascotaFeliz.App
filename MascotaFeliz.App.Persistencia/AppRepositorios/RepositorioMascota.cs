using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
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

        Mascota IRepositorioMascota.AddMascota(Mascota mascota)
        {
            var mascotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return mascotaAdicionada.Entity;
        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _appContext.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota(Mascota mascota)
        {
            var mascotaEncontrada = 
                _appContext.Mascotas.FirstOrDefault(m => m.Id == mascota.Id);
            if (mascotaEncontrada != null)
            {
                mascotaEncontrada.Nombre = mascota.Nombre;
                mascotaEncontrada.TipoMascota = mascota.TipoMascota;
                mascotaEncontrada.Raza = mascota.Raza;
                mascotaEncontrada.Genero = mascota.Genero;
                mascotaEncontrada.AnioNacimiento = mascota.AnioNacimiento;
                mascotaEncontrada.Propietario = mascota.Propietario;
                _appContext.SaveChanges();
            }
            return mascotaEncontrada;
        }

        void IRepositorioMascota.DeleteMascota(int idMascota)
        {
            var mascotaEncontrada = 
                _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(mascotaEncontrada);
            _appContext.SaveChanges();
        }

        Propietario IRepositorioMascota.AsignarPropietario(
            int idMascota, int idPropietario)
        {
            var mascotaEncontrada = _appContext.Mascotas.FirstOrDefault(
                m => m.Id == idMascota);
            if (mascotaEncontrada != null)
            {
                var propietarioEncontrado =
                    _appContext.Propietarios.FirstOrDefault(
                        p => p.Id == idPropietario);
                if (propietarioEncontrado != null)
                {
                    mascotaEncontrada.Propietario = propietarioEncontrado;
                    _appContext.SaveChanges();
                }
                return propietarioEncontrado;
            }
            return null;
        }

    }
}