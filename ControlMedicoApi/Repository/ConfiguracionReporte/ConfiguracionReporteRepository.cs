using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ConfiguracionReporteRepository : IConfiguracionReporteRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddConfiguracionReporte(ConfiguracionReporte configuracionReporte)
        {
            db.ConfiguracionReportes.Add(configuracionReporte);
            db.SaveChanges();

            return configuracionReporte.IdConfiguracionReporte;
        }

        public bool UpdateConfiguracionReporte(ConfiguracionReporte configuracionReporte)
        {
            ConfiguracionReporte configuracionReporteDb = db.ConfiguracionReportes.Where(x => x.IdConfiguracionReporte == configuracionReporte.IdConfiguracionReporte).FirstOrDefault();
            configuracionReporteDb.Html = configuracionReporte.Html;
            db.SaveChanges();

            return true;
        }

        public List<ConfiguracionReporteModel> GetAllConfiguracionReportes()
        {
            return (from c in db.ConfiguracionReportes
                    select new ConfiguracionReporteModel
                    {
                        IdConfiguracionReporte = c.IdConfiguracionReporte,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico  },
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Activo = c.Activo,
                        Html = c.Html
                    }
                    ).ToList();
        }

        public ConfiguracionReporteModel GetConfiguracionReporteById(ConfiguracionReporteModel configuracionReporte)
        {
            return (from c in db.ConfiguracionReportes
                    select new ConfiguracionReporteModel
                    {
                        IdConfiguracionReporte = c.IdConfiguracionReporte,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Activo = c.Activo,
                        Html = c.Html
                    }
                    ).Where(d => d.IdConfiguracionReporte == configuracionReporte.IdConfiguracionReporte).FirstOrDefault();
        }

        public List<ConfiguracionReporteModel> GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionReporte)
        {
            return (from c in db.ConfiguracionReportes
                    select new ConfiguracionReporteModel
                    {
                        IdConfiguracionReporte = c.IdConfiguracionReporte,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = c.IdTipoReporte },
                        Activo = c.Activo,
                        Html = c.Html
                    }
                    ).Where(d => d.Medico.IdMedico == configuracionReporte.Medico.IdMedico).ToList();
        }
    }
}