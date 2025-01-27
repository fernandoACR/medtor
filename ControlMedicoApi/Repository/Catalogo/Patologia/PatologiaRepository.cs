using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class PatologiaRepository : IPatologiaRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddPatologia(Patologia patologia)
        {
            db.Patologias.Add(patologia);
            db.SaveChanges();

            return patologia.IdPatologia;
        }

        public bool UpdatePatologia(Patologia patologia)
        {
            Patologia patologiaDb = db.Patologias.Where(x => x.IdPatologia == patologia.IdPatologia).FirstOrDefault();
            patologiaDb.Descripcion = patologia.Descripcion;
            patologiaDb.Clave = patologia.Clave;
            patologiaDb.Activo = patologia.Activo;
            patologiaDb.IdMedico = patologia.IdMedico;
            
            db.SaveChanges();

            return true;
        }

        public List<PatologiaModel> GetAllPatologias()
        {
            return (from c in db.Patologias
                    select new PatologiaModel
                    {
                        IdPatologia = c.IdPatologia,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico }
                    }
                    ).ToList();
        }

        public PatologiaModel GetPatologiaById(PatologiaModel patologia)
        {
            return (from c in db.Patologias
                    select new PatologiaModel
                    {
                        IdPatologia = c.IdPatologia,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico }
                    }
                    ).Where(d => d.IdPatologia == patologia.IdPatologia).FirstOrDefault();
        }

        public List<PatologiaModel> GetPatologiaByIdMedico(PatologiaModel patologia)
        {
            return (from c in db.Patologias
                    select new PatologiaModel
                    {
                        IdPatologia = c.IdPatologia,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico }
                    }
                    ).Where(d => d.Medico.IdMedico == patologia.Medico.IdMedico).ToList();
        }

        public List<PatologiaModel> GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia)
        {
            return (from c in db.Patologias
                    select new PatologiaModel
                    {
                        IdPatologia = c.IdPatologia,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico }
                    }
                    ).Where(d => d.Activo == patologia.Activo && d.Medico.IdMedico == patologia.Medico.IdMedico).ToList();
        }
    }
}