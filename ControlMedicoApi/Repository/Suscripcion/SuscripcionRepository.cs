using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class SuscripcionRepository : ISuscripcionRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddSuscripcion(Suscripcion suscripcion)
        {
            db.Suscripcions.Add(suscripcion);
            db.SaveChanges();

            return suscripcion.IdSuscriptor;
        }

        public bool UpdateSuscripcion(Suscripcion suscripcion)
        {
            Suscripcion suscripcionDb = db.Suscripcions.Where(x => x.IdSuscriptor == suscripcion.IdSuscriptor).FirstOrDefault();
            suscripcionDb.IdCliente = suscripcion.IdCliente;
            suscripcionDb.MaxUsuarios = suscripcion.MaxUsuarios;
            suscripcionDb.FechaFin = suscripcion.FechaFin;
            suscripcionDb.FechaInicio = suscripcion.FechaInicio;
            suscripcionDb.Activo = suscripcion.Activo;
            suscripcionDb.Estatus = suscripcion.Estatus;

            db.SaveChanges();

            return true;
        }

        public List<SuscripcionModel> GetAllSuscripcions()
        {
            return (from c in db.Suscripcions
                    select new SuscripcionModel
                    {
                        IdSuscriptor = c.IdSuscriptor,
                        MaxUsuarios = c.MaxUsuarios,
                        FechaInicio = c.FechaInicio,
                        FechaFin = c.FechaFin,
                        Cliente =  new ClienteModel() {IdCliente = c.IdCliente } ,
                        Activo = c.Activo,
                        Estatus = new EstatusSuscripcionModel() { IdEstatusSuscriptor = c.Estatus}
                    }
                    ).ToList();
        }

        public SuscripcionModel GetSuscripcionById(SuscripcionModel suscripcion)
        {
            return (from c in db.Suscripcions
                    select new SuscripcionModel
                    {
                        IdSuscriptor = c.IdSuscriptor,
                        MaxUsuarios = c.MaxUsuarios,
                        FechaInicio = c.FechaInicio,
                        FechaFin = c.FechaFin,
                        Cliente = new ClienteModel() { IdCliente = c.IdCliente },
                        Activo = c.Activo,
                        Estatus = new EstatusSuscripcionModel() { IdEstatusSuscriptor = c.Estatus }
                    }
                    ).Where(d => d.IdSuscriptor == suscripcion.IdSuscriptor).FirstOrDefault();
        }

        public SuscripcionModel GetSuscripcionByIdCliente(SuscripcionModel suscripcion)
        {
            return (from c in db.Suscripcions
                    select new SuscripcionModel
                    {
                        IdSuscriptor = c.IdSuscriptor,
                        MaxUsuarios = c.MaxUsuarios,
                        FechaInicio = c.FechaInicio,
                        FechaFin = c.FechaFin,
                        Cliente = new ClienteModel() { IdCliente = c.IdCliente },
                        Activo = c.Activo,
                        Estatus = new EstatusSuscripcionModel() { IdEstatusSuscriptor = c.Estatus }
                    }
                    ).Where(d => d.Cliente.IdCliente == suscripcion.Cliente.IdCliente).FirstOrDefault();
        }
    }
}