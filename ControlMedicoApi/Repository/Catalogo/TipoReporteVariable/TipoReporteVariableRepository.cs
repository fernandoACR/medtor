using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class TipoReporteVariableRepository : ITipoReporteVariableRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddTipoReporteVariable(TipoReporteVariable tipoReporteVariable)
        {
            db.TipoReporteVariables.Add(tipoReporteVariable);
            db.SaveChanges();

            return tipoReporteVariable.IdTipoReporteVariable;
        }

        public bool UpdateTipoReporteVariable(TipoReporteVariable tipoReporteVariable)
        {
            TipoReporteVariable tipoReporteVariableDb = db.TipoReporteVariables.Where(x => x.IdTipoReporteVariable == tipoReporteVariable.IdTipoReporteVariable).FirstOrDefault();
            tipoReporteVariableDb.Descripcion = tipoReporteVariable.Descripcion;
            tipoReporteVariableDb.Propiedad = tipoReporteVariable.Propiedad;
            tipoReporteVariableDb.Activo = tipoReporteVariable.Activo;

            db.SaveChanges();

            return true;
        }

        public List<TipoReporteVariableModel> GetAllTipoReporteVariables()
        {
            return (from c in db.TipoReporteVariables
                    select new TipoReporteVariableModel
                    {
                        IdTipoReporteVariable = c.IdTipoReporteVariable,
                        Descripcion = c.Descripcion,
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Propiedad = c.Propiedad,
                        Entidad = c.Entidad,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public TipoReporteVariableModel GetTipoReporteVariableById(TipoReporteVariableModel tipoReporteVariable)
        {
            return (from c in db.TipoReporteVariables
                    select new TipoReporteVariableModel
                    {
                        IdTipoReporteVariable = c.IdTipoReporteVariable,
                        Descripcion = c.Descripcion,
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Propiedad = c.Propiedad,
                        Entidad = c.Entidad,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdTipoReporteVariable == tipoReporteVariable.IdTipoReporteVariable).FirstOrDefault();
        }

        public List<TipoReporteVariableModel> GetTipoReporteVariableByIdTipoReporte(TipoReporteVariableModel tipoReporteVariable)
        {
            return (from c in db.TipoReporteVariables
                    select new TipoReporteVariableModel
                    {
                        IdTipoReporteVariable = c.IdTipoReporteVariable,
                        Descripcion = c.Descripcion,
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Propiedad = c.Propiedad,
                        Entidad = c.Entidad,
                        Activo = c.Activo
                    }
                    ).Where(r=>r.TipoReporte.IdTipoReporte == tipoReporteVariable.TipoReporte.IdTipoReporte).ToList();
        }
    }
}