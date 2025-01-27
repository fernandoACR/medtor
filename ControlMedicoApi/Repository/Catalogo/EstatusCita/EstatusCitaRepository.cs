using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class EstatusCitaRepository : IEstatusCitaRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEstatusCita(EstatusCita estatusCita)
        {
            db.EstatusCitas.Add(estatusCita);
            db.SaveChanges();

            return estatusCita.IdEstatusCita;
        }

        public bool UpdateEstatusCita(EstatusCita estatusCita)
        {
            EstatusCita estatusCitaDb = db.EstatusCitas.Where(x => x.IdEstatusCita == estatusCita.IdEstatusCita).FirstOrDefault();
            estatusCitaDb.Descripcion = estatusCita.Descripcion;
            estatusCitaDb.Clave = estatusCita.Clave;
            estatusCitaDb.Activo = estatusCita.Activo;
            db.SaveChanges();

            return true;
        }

        public List<EstatusCitaModel> GetAllEstatusCitas()
        {
            return (from c in db.EstatusCitas
                    select new EstatusCitaModel
                    {
                        IdEstatusCita = c.IdEstatusCita,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EstatusCitaModel GetEstatusCitaById(EstatusCitaModel estatusCita)
        {
            return (from c in db.EstatusCitas
                    select new EstatusCitaModel
                    {
                        IdEstatusCita = c.IdEstatusCita,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEstatusCita == estatusCita.IdEstatusCita).FirstOrDefault();
        }
    }
}