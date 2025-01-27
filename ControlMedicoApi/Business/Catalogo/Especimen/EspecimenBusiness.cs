using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class EspecimenBusiness : IEspecimenBusiness
    {
        public readonly IEspecimenRepository especimenRepository;

        public EspecimenBusiness(IEspecimenRepository especimenRepository)
        {
            this.especimenRepository = especimenRepository;
        }

        public int AddEspecimen(EspecimenModel especimen)
        {
            Especiman especimenDb = new Especiman();
            especimenDb.Descripcion = especimen.Descripcion;
            especimenDb.IdMedico = especimen.Medico.IdMedico;
            especimenDb.Activo = 1;

            return especimenRepository.AddEspecimen(especimenDb);
        }

        public bool UpdateEspecimen(EspecimenModel especimen)
        {
            Especiman especimenDb = new Especiman();
            especimenDb.IdEspecimen = especimen.IdEspecimen;
            especimenDb.Descripcion = especimen.Descripcion;
            especimenDb.IdMedico = especimen.Medico.IdMedico;
            especimenDb.Activo = especimen.Activo;

            return especimenRepository.UpdateEspecimen(especimenDb);
        }

        public List<EspecimenModel> GetAllEspecimenes()
        {
            return especimenRepository.GetAllEspecimenes();
        }

        public EspecimenModel GetEspecimenById(EspecimenModel especimen)
        {
            return especimenRepository.GetEspecimenById(especimen);
        }

        public List<EspecimenModel> GetEspecimenByIdMedico(EspecimenModel especimen)
        {
            return especimenRepository.GetEspecimenByIdMedico(especimen);
        }

        public List<EspecimenModel> GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen)
        {
            return especimenRepository.GetEspecimenesByIdMedicoAndActivo(especimen);
        }
    }
}