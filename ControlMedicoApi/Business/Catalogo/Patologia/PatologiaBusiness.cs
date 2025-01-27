using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class PatologiaBusiness : IPatologiaBusiness
    {
        public readonly IPatologiaRepository patologiaRepository;

        public PatologiaBusiness(IPatologiaRepository patologiaRepository)
        {
            this.patologiaRepository = patologiaRepository;
        }

        public int AddPatologia(PatologiaModel patologia)
        {
            Patologia patologiaDb = new Patologia();
            patologiaDb.Descripcion = patologia.Descripcion;
            patologiaDb.Clave = patologia.Clave;
            patologiaDb.Activo = 1;
            patologiaDb.IdMedico = patologia.Medico.IdMedico;

            return patologiaRepository.AddPatologia(patologiaDb);
        }

        public bool UpdatePatologia(PatologiaModel patologia)
        {
            Patologia patologiaDb = new Patologia();
            patologiaDb.IdPatologia = patologia.IdPatologia;
            patologiaDb.Clave = patologia.Clave;
            patologiaDb.Descripcion = patologia.Descripcion;
            patologiaDb.Activo = patologia.Activo;
            patologiaDb.IdMedico = patologia.Medico.IdMedico;

            return patologiaRepository.UpdatePatologia(patologiaDb);
        }

        public List<PatologiaModel> GetAllPatologias()
        {
            return patologiaRepository.GetAllPatologias();
        }

        public PatologiaModel GetPatologiaById(PatologiaModel patologia)
        {
            return patologiaRepository.GetPatologiaById(patologia);
        }

        public List<PatologiaModel> GetPatologiaByIdMedico(PatologiaModel patologia)
        {
            return patologiaRepository.GetPatologiaByIdMedico(patologia);
        }

        public List<PatologiaModel> GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia)
        {
            return patologiaRepository.GetPatologiaByIdMedicoAndActivo(patologia);
        }
    }
}