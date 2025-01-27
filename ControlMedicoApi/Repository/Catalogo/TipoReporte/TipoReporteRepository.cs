using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class TipoReporteRepository : ITipoReporteRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddTipoReporte(TipoReporte tipoReporte)
        {
            db.TipoReportes.Add(tipoReporte);
            db.SaveChanges();

            return tipoReporte.IdTipoReporte;
        }

        public bool UpdateTipoReporte(TipoReporte tipoReporte)
        {
            TipoReporte tipoReporteDb = db.TipoReportes.Where(x => x.IdTipoReporte == tipoReporte.IdTipoReporte).FirstOrDefault();
            tipoReporteDb.Descripcion = tipoReporte.Descripcion;
            tipoReporteDb.Activo = tipoReporte.Activo;

            db.SaveChanges();

            return true;
        }

        public List<TipoReporteModel> GetAllTipoReportes()
        {
            return (from c in db.TipoReportes
                    select new TipoReporteModel
                    {
                        IdTipoReporte = c.IdTipoReporte,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public TipoReporteModel GetTipoReporteById(TipoReporteModel tipoReporte)
        {
            return (from c in db.TipoReportes
                    select new TipoReporteModel
                    {
                        IdTipoReporte = c.IdTipoReporte,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdTipoReporte == tipoReporte.IdTipoReporte).FirstOrDefault();
        }
    }
}