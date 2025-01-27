using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class EstatusCitaBusiness : IEstatusCitaBusiness
    {
        public readonly IEstatusCitaRepository estatusCitaRepository;

        public EstatusCitaBusiness(IEstatusCitaRepository estatusCitaRepository)
        {
            this.estatusCitaRepository = estatusCitaRepository;
        }

        public int AddEstatusCita(EstatusCitaModel estatusCita)
        {
            EstatusCita estatusCitaDb = new EstatusCita();
            estatusCitaDb.Descripcion = estatusCita.Descripcion;
            estatusCitaDb.Clave = estatusCita.Clave;
            estatusCitaDb.Activo = 1;

            return estatusCitaRepository.AddEstatusCita(estatusCitaDb);
        }

        public bool UpdateEstatusCita(EstatusCitaModel estatusCita)
        {
            EstatusCita estatusCitaDb = new EstatusCita();
            estatusCitaDb.IdEstatusCita = estatusCita.IdEstatusCita;
            estatusCitaDb.Descripcion = estatusCita.Descripcion;
            estatusCitaDb.Clave = estatusCita.Clave;
            estatusCitaDb.Activo = estatusCita.Activo;

            return estatusCitaRepository.UpdateEstatusCita(estatusCitaDb);
        }

        public List<EstatusCitaModel> GetAllEstatusCitas()
        {
            return estatusCitaRepository.GetAllEstatusCitas();
        }

        public EstatusCitaModel GetEstatusCitaById(EstatusCitaModel estatusCita)
        {
            return estatusCitaRepository.GetEstatusCitaById(estatusCita);
        }
    }
}