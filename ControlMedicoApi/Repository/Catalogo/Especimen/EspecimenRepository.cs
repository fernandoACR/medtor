using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class EspecimenRepository : IEspecimenRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEspecimen(Especiman especimen)
        {
            db.Especimen.Add(especimen);
            db.SaveChanges();

            return especimen.IdEspecimen;
        }

        public bool UpdateEspecimen(Especiman especimen)
        {
            Especiman especimenDb = db.Especimen.Where(x => x.IdEspecimen == especimen.IdEspecimen).FirstOrDefault();
            especimenDb.Descripcion = especimen.Descripcion;
            especimenDb.Activo = especimen.Activo;
            especimenDb.IdMedico = especimen.IdMedico;

            db.SaveChanges();

            return true;
        }

        public List<EspecimenModel> GetAllEspecimenes()
        {
            return (from c in db.Especimen
                    select new EspecimenModel
                    {
                        IdEspecimen = c.IdEspecimen,
                        Descripcion = c.Descripcion,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EspecimenModel GetEspecimenById(EspecimenModel especimen)
        {
            return (from c in db.Especimen
                    select new EspecimenModel
                    {
                        IdEspecimen = c.IdEspecimen,
                        Descripcion = c.Descripcion,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEspecimen == especimen.IdEspecimen).FirstOrDefault();
        }

        public List<EspecimenModel> GetEspecimenByIdMedico(EspecimenModel especimen)
        {
            return (from c in db.Especimen
                    select new EspecimenModel
                    {
                        IdEspecimen = c.IdEspecimen,
                        Descripcion = c.Descripcion,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo
                    }
                    ).Where(d => d.Medico.IdMedico == especimen.Medico.IdMedico).ToList();
        }

        public List<EspecimenModel> GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen)
        {
            return (from c in db.Especimen
                    select new EspecimenModel
                    {
                        IdEspecimen = c.IdEspecimen,
                        Descripcion = c.Descripcion,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo
                    }
                    ).Where(x=> x.Activo == especimen.Activo && x.Medico.IdMedico == especimen.Medico.IdMedico).ToList();
        }
    }
}