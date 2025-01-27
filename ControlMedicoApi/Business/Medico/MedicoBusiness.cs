using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class MedicoBusiness : IMedicoBusiness
    {
        public readonly IMedicoRepository medicoRepository;
        public readonly IEspecialidadRepository especialidadRepository;
        public readonly IArchivoMedicoRepository archivoMedicoRepository;
        public readonly IConfiguracionMedicoRepository configuracionMedicoRepository;
        public MedicoBusiness(IMedicoRepository medicoRepository, IEspecialidadRepository especialidadRepository, IArchivoMedicoRepository archivoMedicoRepository, IConfiguracionMedicoRepository configuracionMedicoRepository)
        {
            this.medicoRepository = medicoRepository;
            this.especialidadRepository = especialidadRepository;
            this.archivoMedicoRepository = archivoMedicoRepository;
            this.configuracionMedicoRepository = configuracionMedicoRepository;
        }

        public int AddMedico(MedicoModel medico)
        {
            Medico medicoDb = new Medico();
            medicoDb.Nombre = medico.Nombre;
            medicoDb.IdEspecialidad = medico.Especialidad.IdEspecialidad;
            medicoDb.Telefono = medico.Telefono;
            medicoDb.Activo = 1;
            medicoDb.Correo = medico.Correo;
            medicoDb.IdSuscripcion = medico.Suscripcion.IdSuscriptor;
            medicoDb.CedulaProfesional = medico.CedulaProfesional;

            int idMedico = medicoRepository.AddMedico(medicoDb);

            if (idMedico > 0)
            {
                List<ConfiguracionMedico> configuracionMedico = new List<ConfiguracionMedico>();
                
                var section = ConfigurationManager.GetSection("defaultConfigMedico");

                if (section != null)
                {
                    var initialMedicoConfiguration = (section as DefaultConfigMedico).InitialMedicoConfigurations;

                    for (int i = 0; i < initialMedicoConfiguration.Count; i++)
                    {
                        configuracionMedico.Add(new ConfiguracionMedico()
                        {
                            Descripcion = initialMedicoConfiguration[i].Descripcion,
                            TipoConfiguracion = initialMedicoConfiguration[i].TipoConfiguracion,
                            IdMedico = idMedico,
                            Valor = initialMedicoConfiguration[i].Valor,
                            Activo = 1,
                            Nombre = initialMedicoConfiguration[i].Nombre
                        });
                    }
                }                

                foreach (ConfiguracionMedico configuracion in configuracionMedico)
                {
                    configuracionMedicoRepository.AddConfiguracionMedico(configuracion);
                }
            }            
            
            return idMedico;
        }

        public bool UpdateMedico(MedicoModel medico)
        {
            Medico medicoDb = new Medico();
            medicoDb.IdMedico = medico.IdMedico;
            medicoDb.Nombre = medico.Nombre;
            medicoDb.IdEspecialidad = medico.Especialidad.IdEspecialidad;
            medicoDb.Telefono = medico.Telefono;
            medicoDb.Activo = medico.Activo;
            medicoDb.Correo = medico.Correo;
            medicoDb.CedulaProfesional = medico.CedulaProfesional;

            if (medico.Logo != null)
            {
                if (medico.Logo.IdArchivoMedico > 0)
                {
                    archivoMedicoRepository.UpdateArchivoMedico(new ArchivoMedico()
                    {
                        IdArchivoMedico = medico.Logo.IdArchivoMedico,
                        IdMedico = medico.IdMedico,
                        IdTipoArchivo = medico.Logo.TipoArchivo.IdTipoArchivo,
                        Descripcion = medico.Logo.Descripcion,
                        Codigo = medico.Logo.Codigo,
                        Archivo = Convert.FromBase64String(medico.Logo.Archivo),
                        ExtensionArchivo = medico.Logo.ExtensionArchivo
                    });
                }
                else
                {
                    archivoMedicoRepository.AddArchivoMedico(new ArchivoMedico()
                    {
                        IdArchivoMedico = medico.Logo.IdArchivoMedico,
                        IdMedico = medico.IdMedico,
                        IdTipoArchivo = medico.Logo.TipoArchivo.IdTipoArchivo,
                        Descripcion = medico.Logo.Descripcion,
                        Codigo = Guid.NewGuid(),
                        Archivo = Convert.FromBase64String(medico.Logo.Archivo),
                        ExtensionArchivo = medico.Logo.ExtensionArchivo,
                        Activo = 1
                    });
                }
            }

            return medicoRepository.UpdateMedico(medicoDb);
        }

        public List<MedicoModel> GetAllMedicos()
        {
            List<MedicoModel> listMedicos = new List<MedicoModel>();
            listMedicos = medicoRepository.GetAllMedicos();
            listMedicos.Where(d=> d.Especialidad.IdEspecialidad > 0).ToList().ForEach(x => x.Especialidad = especialidadRepository.GetEspecialidadById(new EspecialidadModel() { IdEspecialidad = (int)x.Especialidad.IdEspecialidad }));

            return listMedicos;
        }

        public MedicoModel GetMedicoById(MedicoModel medico)
        {
            MedicoModel medicoDb = new MedicoModel();
            medicoDb = medicoRepository.GetMedicoById(medico);

            if(medicoDb.Especialidad.IdEspecialidad > 0)
                medicoDb.Especialidad = especialidadRepository.GetEspecialidadById(new EspecialidadModel { IdEspecialidad = (int)medicoDb.Especialidad.IdEspecialidad });

            medicoDb.Logo = archivoMedicoRepository.GetArchivoMedicoByIdMedico(new ArchivoMedicoModel() { Medico = medicoDb });

            return medicoDb;
        }

        public List<MedicoModel> GetMedicoByIdSuscripcion(MedicoModel medico)
        {
            List<MedicoModel> listMedicos = new List<MedicoModel>();
            listMedicos = medicoRepository.GetMedicoByIdSuscripcion(medico);

            foreach (var medicoDb in listMedicos)
            {
                if (medicoDb.Especialidad.IdEspecialidad > 0 && medicoDb.Especialidad != null)
                    medicoDb.Especialidad = especialidadRepository.GetEspecialidadById(new EspecialidadModel { IdEspecialidad = (int)medicoDb.Especialidad.IdEspecialidad });
            }

            return listMedicos;
        }
    }
}