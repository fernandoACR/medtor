using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class ConfiguracionMedicoBusiness : IConfiguracionMedicoBusiness
    {
        public readonly IConfiguracionMedicoRepository configuracionMedicoRepository;
        public readonly IMedicoRepository medicoRepository;

        public ConfiguracionMedicoBusiness(IConfiguracionMedicoRepository configuracionMedicoRepository, IMedicoRepository medicoRepository)
        {
            this.configuracionMedicoRepository = configuracionMedicoRepository;
            this.medicoRepository = medicoRepository;
        }

        public int AddConfiguracionMedico(ConfiguracionMedicoModel configuracionMedico)
        {
            ConfiguracionMedico configuracionMedicoDb = new ConfiguracionMedico();
            configuracionMedicoDb.Descripcion = configuracionMedico.Descripcion;
            configuracionMedicoDb.IdMedico = configuracionMedico.Medico.IdMedico;
            configuracionMedicoDb.TipoConfiguracion = configuracionMedico.TipoConfiguracion;
            configuracionMedicoDb.Activo = 1;
            configuracionMedicoDb.Valor = configuracionMedico.Valor;
            configuracionMedicoDb.Nombre = configuracionMedico.Nombre;

            return configuracionMedicoRepository.AddConfiguracionMedico(configuracionMedicoDb);
        }

        public bool UpdateConfiguracionMedico(List<ConfiguracionMedicoModel> configuracionMedico)
        {
            foreach (ConfiguracionMedicoModel configuracion in configuracionMedico)
            {
                ConfiguracionMedico configuracionMedicoDb = new ConfiguracionMedico();
                configuracionMedicoDb.IdConfiguracionMedico = configuracion.IdConfiguracionMedico;
                configuracionMedicoDb.Descripcion = configuracion.Descripcion;
                configuracionMedicoDb.IdMedico = configuracion.Medico.IdMedico;
                configuracionMedicoDb.TipoConfiguracion = configuracion.TipoConfiguracion;
                configuracionMedicoDb.Activo = 1;
                configuracionMedicoDb.Valor = configuracion.Valor;
                configuracionMedicoDb.Nombre = configuracion.Nombre;

                configuracionMedicoRepository.UpdateConfiguracionMedico(configuracionMedicoDb);
            }

            return true;
        }

        public List<ConfiguracionMedicoModel> GetAllConfiguracionMedicos()
        {
            List<ConfiguracionMedicoModel> listConfiguracionMedicos = new List<ConfiguracionMedicoModel>();
            listConfiguracionMedicos = configuracionMedicoRepository.GetAllConfiguracionMedicos();
            listConfiguracionMedicos.Where(d=> d.Medico.IdMedico > 0).ToList().ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = (int)x.Medico.IdMedico }));

            return listConfiguracionMedicos;
        }

        public ConfiguracionMedicoModel GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionMedico)
        {
            ConfiguracionMedicoModel configuracionMedicoDb = new ConfiguracionMedicoModel();
            configuracionMedicoDb = configuracionMedicoRepository.GetConfiguracionMedicoById(configuracionMedico);

            if(configuracionMedicoDb.Medico.IdMedico > 0)
                configuracionMedicoDb.Medico = medicoRepository.GetMedicoById(new MedicoModel { IdMedico = configuracionMedicoDb.Medico.IdMedico });

            return configuracionMedicoDb;
        }

        public List<ConfiguracionMedicoModel> GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionMedico)
        {
            List<ConfiguracionMedicoModel> listConfiguracionMedicos = new List<ConfiguracionMedicoModel>();
            listConfiguracionMedicos = configuracionMedicoRepository.GetConfiguracionMedicoByIdMedico(configuracionMedico);

            foreach (var configuracionMedicoDb in listConfiguracionMedicos)
            {
                if (configuracionMedicoDb.Medico.IdMedico > 0 && configuracionMedicoDb.Medico != null)
                    configuracionMedicoDb.Medico = medicoRepository.GetMedicoById(new MedicoModel { IdMedico = configuracionMedicoDb.Medico.IdMedico });
            }

            return listConfiguracionMedicos;
        }
    }
}