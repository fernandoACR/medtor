using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class EstatusSuscripcionBusiness : IEstatusSuscripcionBusiness
    {
        public readonly IEstatusSuscripcionRepository estatusSuscripcionRepository;

        public EstatusSuscripcionBusiness(IEstatusSuscripcionRepository estatusSuscripcionRepository)
        {
            this.estatusSuscripcionRepository = estatusSuscripcionRepository;
        }

        public int AddEstatusSuscripcion(EstatusSuscripcionModel estatusSuscripcion)
        {
            EstatusSuscripcion estatusSuscripcionDb = new EstatusSuscripcion();
            estatusSuscripcionDb.Descripcion = estatusSuscripcion.Descripcion;
            estatusSuscripcionDb.Activo = 1;

            return estatusSuscripcionRepository.AddEstatusSuscripcion(estatusSuscripcionDb);
        }

        public bool UpdateEstatusSuscripcion(EstatusSuscripcionModel estatusSuscripcion)
        {
            EstatusSuscripcion estatusSuscripcionDb = new EstatusSuscripcion();
            estatusSuscripcionDb.IdEstatusSuscriptor = estatusSuscripcion.IdEstatusSuscriptor;
            estatusSuscripcionDb.Descripcion = estatusSuscripcion.Descripcion;
            estatusSuscripcionDb.Activo = estatusSuscripcion.Activo;

            return estatusSuscripcionRepository.UpdateEstatusSuscripcion(estatusSuscripcionDb);
        }

        public List<EstatusSuscripcionModel> GetAllEstatusSuscripciones()
        {
            return estatusSuscripcionRepository.GetAllEstatusSuscripciones();
        }

        public EstatusSuscripcionModel GetEstatusSuscripcionById(EstatusSuscripcionModel estatusSuscripcion)
        {
            return estatusSuscripcionRepository.GetEstatusSuscripcionById(estatusSuscripcion);
        }
    }
}