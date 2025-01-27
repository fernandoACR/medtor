using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class SuscripcionBusiness : ISuscripcionBusiness
    {
        public readonly ISuscripcionRepository suscripcionRepository;
        public readonly ITransaccionRepository transaccionRepository;
        public readonly IEstatusSuscripcionRepository estatusSuscripcionRepository;

        public SuscripcionBusiness(ISuscripcionRepository suscripcionRepository, ITransaccionRepository transaccionRepository, IEstatusSuscripcionRepository estatusSuscripcionRepository)
        {
            this.suscripcionRepository = suscripcionRepository;
            this.transaccionRepository = transaccionRepository;
            this.estatusSuscripcionRepository = estatusSuscripcionRepository;
        }

        public int AddSuscripcion(SuscripcionModel suscripcion)
        {
            Suscripcion suscripcionDb = new Suscripcion();
            suscripcionDb.FechaFin = suscripcion.FechaFin;
            suscripcionDb.IdCliente = suscripcion.Cliente.IdCliente;
            suscripcionDb.FechaInicio = suscripcion.FechaInicio;
            suscripcionDb.Estatus = suscripcion.Estatus.IdEstatusSuscriptor;
            suscripcionDb.MaxUsuarios = suscripcion.MaxUsuarios;
            suscripcionDb.Activo = 1;

            return suscripcionRepository.AddSuscripcion(suscripcionDb);
        }

        public bool UpdateSuscripcion(SuscripcionModel suscripcion)
        {
            Suscripcion suscripcionDb = new Suscripcion();
            suscripcionDb.IdSuscriptor = suscripcion.IdSuscriptor;
            suscripcionDb.FechaFin = suscripcion.FechaFin;
            suscripcionDb.IdCliente = suscripcion.Cliente.IdCliente;
            suscripcionDb.FechaInicio = suscripcion.FechaInicio;
            suscripcionDb.Estatus = suscripcion.Estatus.IdEstatusSuscriptor;
            suscripcionDb.MaxUsuarios = suscripcion.MaxUsuarios;
            suscripcionDb.Activo = suscripcion.Activo;

            return suscripcionRepository.UpdateSuscripcion(suscripcionDb);
        }

        public List<SuscripcionModel> GetAllSuscripcions()
        {
            return suscripcionRepository.GetAllSuscripcions();
        }

        public SuscripcionModel GetSuscripcionById(SuscripcionModel suscripcion)
        {
            suscripcion = suscripcionRepository.GetSuscripcionById(suscripcion);
            suscripcion.Estatus = estatusSuscripcionRepository.GetEstatusSuscripcionById(new EstatusSuscripcionModel() { IdEstatusSuscriptor = suscripcion.Estatus.IdEstatusSuscriptor });
            suscripcion.Transaccion = transaccionRepository.GetAllTransaccions().Where(x => x.IdGenerado == suscripcion.IdSuscriptor).Last();

            return suscripcion;
        }
    }
}