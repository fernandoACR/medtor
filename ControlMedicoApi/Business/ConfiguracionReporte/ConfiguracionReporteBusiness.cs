using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class ConfiguracionReporteBusiness : IConfiguracionReporteBusiness
    {
        public readonly IConfiguracionReporteRepository configuracionReporteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly ITipoReporteRepository tipoReporteRepository;
        public readonly ITipoReporteVariableRepository tipoReporteVariableRepository;

        public ConfiguracionReporteBusiness(IConfiguracionReporteRepository configuracionReporteRepository, IMedicoRepository medicoRepository, ITipoReporteRepository tipoReporteRepository, ITipoReporteVariableRepository tipoReporteVariableRepository)
        {
            this.configuracionReporteRepository = configuracionReporteRepository;
            this.medicoRepository = medicoRepository;
            this.tipoReporteRepository = tipoReporteRepository;
            this.tipoReporteVariableRepository = tipoReporteVariableRepository;
        }

        public int AddConfiguracionReporte(ConfiguracionReporteModel configuracionReporte)
        {
            ConfiguracionReporte configuracionReporteDb = new ConfiguracionReporte();
            configuracionReporteDb.Html = configuracionReporte.Html;
            configuracionReporteDb.IdMedico = configuracionReporte.Medico.IdMedico;
            configuracionReporteDb.IdConfiguracionReporte = configuracionReporte.Medico.IdMedico;
            configuracionReporteDb.Activo = 1;
            configuracionReporteDb.IdTipoReporte = configuracionReporte.TipoReporte.IdTipoReporte;

            return configuracionReporteRepository.AddConfiguracionReporte(configuracionReporteDb);
        }

        public bool UpdateConfiguracionReporte(ConfiguracionReporteModel configuracionReporte)
        {
            ConfiguracionReporte configuracionReporteDb = new ConfiguracionReporte();
            configuracionReporteDb.IdConfiguracionReporte = configuracionReporte.IdConfiguracionReporte;
            configuracionReporteDb.Html = configuracionReporte.Html;

            configuracionReporteRepository.UpdateConfiguracionReporte(configuracionReporteDb);

            return true;
        }

        public List<ConfiguracionReporteModel> GetAllConfiguracionReportes()
        {
            List<ConfiguracionReporteModel> listConfiguracionReportes = new List<ConfiguracionReporteModel>();
            listConfiguracionReportes = configuracionReporteRepository.GetAllConfiguracionReportes();
            listConfiguracionReportes.Where(d=> d.Medico.IdMedico > 0).ToList().ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = (int)x.Medico.IdMedico }));

            return listConfiguracionReportes;
        }

        public ConfiguracionReporteModel GetConfiguracionReporteById(ConfiguracionReporteModel configuracionReporte)
        {
            ConfiguracionReporteModel configuracionReporteDb = new ConfiguracionReporteModel();
            configuracionReporteDb = configuracionReporteRepository.GetConfiguracionReporteById(configuracionReporte);

            if(configuracionReporteDb.Medico.IdMedico > 0)
                configuracionReporteDb.Medico = medicoRepository.GetMedicoById(new MedicoModel { IdMedico = configuracionReporteDb.Medico.IdMedico });

            return configuracionReporteDb;
        }

        public List<ConfiguracionReporteModel> GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionReporte)
        {
            List<ConfiguracionReporteModel> listConfiguracionReportes = new List<ConfiguracionReporteModel>();
            listConfiguracionReportes = configuracionReporteRepository.GetConfiguracionReporteByIdMedico(configuracionReporte);

            foreach (var configuracionReporteDb in listConfiguracionReportes)
            {
                if (configuracionReporteDb.Medico.IdMedico > 0 && configuracionReporteDb.Medico != null)
                {
                    configuracionReporteDb.Medico = medicoRepository.GetMedicoById(new MedicoModel { IdMedico = configuracionReporteDb.Medico.IdMedico });
                    configuracionReporteDb.TipoReporte = tipoReporteRepository.GetTipoReporteById(new TipoReporteModel { IdTipoReporte = configuracionReporteDb.TipoReporte.IdTipoReporte });
                    configuracionReporteDb.TipoReporte.Variables = new List<TipoReporteVariableModel>();

                    var tipoReporteVariableModel = new TipoReporteVariableModel()
                    {
                        TipoReporte = new TipoReporteModel() { IdTipoReporte = configuracionReporteDb.TipoReporte.IdTipoReporte }
                    };

                    configuracionReporteDb.TipoReporte.Variables.AddRange(tipoReporteVariableRepository.GetTipoReporteVariableByIdTipoReporte(tipoReporteVariableModel));
                }
            }

            return listConfiguracionReportes;
        }
    }
}