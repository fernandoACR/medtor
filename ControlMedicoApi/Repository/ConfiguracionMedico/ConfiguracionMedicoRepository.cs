using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ConfiguracionMedicoRepository : IConfiguracionMedicoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddConfiguracionMedico(ConfiguracionMedico configuracionMedico)
        {
            db.ConfiguracionMedicoes.Add(configuracionMedico);
            db.SaveChanges();

            return configuracionMedico.IdConfiguracionMedico;
        }

        public bool UpdateConfiguracionMedico(ConfiguracionMedico configuracionMedico)
        {
            ConfiguracionMedico configuracionMedicoDb = db.ConfiguracionMedicoes.Where(x => x.IdConfiguracionMedico == configuracionMedico.IdConfiguracionMedico).FirstOrDefault();
            configuracionMedicoDb.Valor = configuracionMedico.Valor;

            db.SaveChanges();

            return true;
        }

        public List<ConfiguracionMedicoModel> GetAllConfiguracionMedicos()
        {
            return (from c in db.ConfiguracionMedicoes
                    select new ConfiguracionMedicoModel
                    {
                        IdConfiguracionMedico = c.IdConfiguracionMedico,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico  },
                        Descripcion = c.Descripcion,
                        TipoConfiguracion = c.TipoConfiguracion,
                        Activo = c.Activo,
                        Valor = c.Valor,
                        Nombre = c.Nombre
                    }
                    ).ToList();
        }

        public ConfiguracionMedicoModel GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionMedico)
        {
            return (from c in db.ConfiguracionMedicoes
                    select new ConfiguracionMedicoModel
                    {
                        IdConfiguracionMedico = c.IdConfiguracionMedico,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        TipoConfiguracion = c.TipoConfiguracion,
                        Activo = c.Activo,
                        Valor = c.Valor,
                        Nombre = c.Nombre
                    }
                    ).Where(d => d.IdConfiguracionMedico == configuracionMedico.IdConfiguracionMedico).FirstOrDefault();
        }

        public List<ConfiguracionMedicoModel> GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionMedico)
        {
            return (from c in db.ConfiguracionMedicoes
                    select new ConfiguracionMedicoModel
                    {
                        IdConfiguracionMedico = c.IdConfiguracionMedico,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        TipoConfiguracion = c.TipoConfiguracion,
                        Activo = c.Activo,
                        Valor = c.Valor,
                        Nombre = c.Nombre
                    }
                    ).Where(d => d.Medico.IdMedico == configuracionMedico.Medico.IdMedico).ToList();
        }
    }
}