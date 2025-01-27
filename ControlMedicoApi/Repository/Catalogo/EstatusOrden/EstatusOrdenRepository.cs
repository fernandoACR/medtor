using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class EstatusOrdenRepository : IEstatusOrdenRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEstatusOrden(EstatusOrden estatusOrden)
        {
            db.EstatusOrdens.Add(estatusOrden);
            db.SaveChanges();

            return estatusOrden.IdEstatusOrden;
        }

        public bool UpdateEstatusOrden(EstatusOrden estatusOrden)
        {
            EstatusOrden estatusOrdenDb = db.EstatusOrdens.Where(x => x.IdEstatusOrden == estatusOrden.IdEstatusOrden).FirstOrDefault();
            estatusOrdenDb.Descripcion = estatusOrden.Descripcion;
            estatusOrdenDb.Clave = estatusOrden.Clave;
            estatusOrdenDb.Activo = estatusOrden.Activo;
            db.SaveChanges();

            return true;
        }

        public List<EstatusOrdenModel> GetAllEstatusOrdens()
        {
            return (from c in db.EstatusOrdens
                    select new EstatusOrdenModel
                    {
                        IdEstatusOrden = c.IdEstatusOrden,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EstatusOrdenModel GetEstatusOrdenById(EstatusOrdenModel estatusOrden)
        {
            return (from c in db.EstatusOrdens
                    select new EstatusOrdenModel
                    {
                        IdEstatusOrden = c.IdEstatusOrden,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEstatusOrden == estatusOrden.IdEstatusOrden).FirstOrDefault();
        }
    }
}