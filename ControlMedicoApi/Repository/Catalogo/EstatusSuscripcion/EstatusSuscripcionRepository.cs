using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository 
{
    public class EstatusSuscripcionRepository : IEstatusSuscripcionRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEstatusSuscripcion(EstatusSuscripcion estatusSuscripcion)
        {
            db.EstatusSuscripcions.Add(estatusSuscripcion);
            db.SaveChanges();

            return estatusSuscripcion.IdEstatusSuscriptor;
        }

        public bool UpdateEstatusSuscripcion(EstatusSuscripcion estatusSuscripcion)
        {
            EstatusSuscripcion estatusSuscripcionDb = db.EstatusSuscripcions.Where(x => x.IdEstatusSuscriptor == estatusSuscripcion.IdEstatusSuscriptor).FirstOrDefault();
            estatusSuscripcionDb.Descripcion = estatusSuscripcion.Descripcion;
            estatusSuscripcionDb.Activo = estatusSuscripcion.Activo;

            db.SaveChanges();

            return true;
        }

        public List<EstatusSuscripcionModel> GetAllEstatusSuscripciones()
        {
            return (from c in db.EstatusSuscripcions
                    select new EstatusSuscripcionModel
                    {
                        IdEstatusSuscriptor = c.IdEstatusSuscriptor,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EstatusSuscripcionModel GetEstatusSuscripcionById(EstatusSuscripcionModel estatusSuscripcion)
        {
            return (from c in db.EstatusSuscripcions
                    select new EstatusSuscripcionModel
                    {
                        IdEstatusSuscriptor = c.IdEstatusSuscriptor,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEstatusSuscriptor == estatusSuscripcion.IdEstatusSuscriptor).FirstOrDefault();
        }
    }
}