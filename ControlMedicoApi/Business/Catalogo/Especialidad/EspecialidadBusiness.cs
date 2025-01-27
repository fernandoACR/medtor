using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class EspecialidadBusiness : IEspecialidadBusiness
    {
        public readonly IEspecialidadRepository especialidadRepository;

        public EspecialidadBusiness(IEspecialidadRepository especialidadRepository)
        {
            this.especialidadRepository = especialidadRepository;
        }

        public int AddEspecialidad(EspecialidadModel especialidad)
        {
            Especialidad especialidadDb = new Especialidad();
            especialidadDb.Descripcion = especialidad.Descripcion;
            especialidadDb.Activo = 1;

            return especialidadRepository.AddEspecialidad(especialidadDb);
        }

        public bool UpdateEspecialidad(EspecialidadModel especialidad)
        {
            Especialidad especialidadDb = new Especialidad();
            especialidadDb.IdEspecialidad = especialidad.IdEspecialidad;
            especialidadDb.Descripcion = especialidad.Descripcion;
            especialidadDb.Activo = especialidad.Activo;

            return especialidadRepository.UpdateEspecialidad(especialidadDb);
        }

        public List<EspecialidadModel> GetAllEspecialidades()
        {
            return especialidadRepository.GetAllEspecialidades();
        }

        public EspecialidadModel GetEspecialidadById(EspecialidadModel especialidad)
        {
            return especialidadRepository.GetEspecialidadById(especialidad);
        }

        public List<EspecialidadModel> GetEspecialidadesByActivo(EspecialidadModel especialidad)
        {
            return especialidadRepository.GetEspecialidadesByActivo(especialidad);
        }
    }
}