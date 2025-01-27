using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEspecialidad(Especialidad especialidad)
        {
            db.Especialidads.Add(especialidad);
            db.SaveChanges();

            return especialidad.IdEspecialidad;
        }

        public bool UpdateEspecialidad(Especialidad especialidad)
        {
            Especialidad especialidadDb = db.Especialidads.Where(x => x.IdEspecialidad == especialidad.IdEspecialidad).FirstOrDefault();
            especialidadDb.Descripcion = especialidad.Descripcion;
            especialidadDb.Activo = especialidad.Activo;

            db.SaveChanges();

            return true;
        }

        public List<EspecialidadModel> GetAllEspecialidades()
        {
            return (from c in db.Especialidads
                    select new EspecialidadModel
                    {
                        IdEspecialidad = c.IdEspecialidad,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EspecialidadModel GetEspecialidadById(EspecialidadModel especialidad)
        {
            return (from c in db.Especialidads
                    select new EspecialidadModel
                    {
                        IdEspecialidad = c.IdEspecialidad,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEspecialidad == especialidad.IdEspecialidad).FirstOrDefault();
        }

        public List<EspecialidadModel> GetEspecialidadesByActivo(EspecialidadModel especialidad)
        {
            return (from c in db.Especialidads
                    select new EspecialidadModel
                    {
                        IdEspecialidad = c.IdEspecialidad,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(x=> x.Activo == especialidad.Activo).ToList();
        }
    }
}