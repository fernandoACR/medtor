using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class HistoricoOrdenRepository : IHistoricoOrdenRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddHistoricoOrden(HistoricoOrden historicoOrden)
        {
            try
            {
                db.HistoricoOrdens.Add(historicoOrden);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }


            return historicoOrden.IdHistoricoOrden;
        }

        public bool UpdateHistoricoOrden(HistoricoOrden historicoOrden)
        {
            HistoricoOrden historicoOrdenDb = db.HistoricoOrdens.Where(x => x.IdHistoricoOrden == historicoOrden.IdHistoricoOrden).FirstOrDefault();
            historicoOrdenDb.IdOrden = historicoOrden.IdOrden;
            historicoOrdenDb.IdEstatusOrden = historicoOrden.IdEstatusOrden;
            historicoOrdenDb.ClaveOrden = historicoOrden.ClaveOrden;
            historicoOrdenDb.FechaEstatus = historicoOrden.FechaEstatus;
            historicoOrdenDb.IdUsuarioModificacion = historicoOrden.IdUsuarioModificacion;
            db.SaveChanges();

            return true;
        }

        public List<HistoricoOrdenModel> GetAllHistoricoOrdens()
        {
            return (from c in db.HistoricoOrdens
                    select new HistoricoOrdenModel
                    {
                        IdHistoricoOrden = c.IdHistoricoOrden,
                        Orden = new OrdenModel() { IdOrden = c.IdOrden, Clave = c.ClaveOrden },
                        EstatusOrden = new EstatusOrdenModel() { IdEstatusOrden = c.IdEstatusOrden },
                        FechaEstatus = c.FechaEstatus,
                        IdUsuarioModificacion = c.IdUsuarioModificacion
                    }
                    ).ToList();
        }

        public HistoricoOrdenModel GetHistoricoOrdenById(HistoricoOrdenModel historicoOrden)
        {
            return (from c in db.HistoricoOrdens
                    select new HistoricoOrdenModel
                    {
                        IdHistoricoOrden = c.IdHistoricoOrden,
                        Orden = new OrdenModel() { IdOrden = c.IdOrden, Clave = c.ClaveOrden },
                        EstatusOrden = new EstatusOrdenModel() { IdEstatusOrden = c.IdEstatusOrden },
                        FechaEstatus = c.FechaEstatus,
                        IdUsuarioModificacion = c.IdUsuarioModificacion
                    }
                    ).Where(d => d.IdHistoricoOrden == historicoOrden.IdHistoricoOrden).FirstOrDefault();
        }

        public List<HistoricoOrdenModel> GetHistoricoOrdensByIdOrden(HistoricoOrdenModel historicoOrden)
        {
            return (from c in db.HistoricoOrdens
                    select new HistoricoOrdenModel
                    {
                        IdHistoricoOrden = c.IdHistoricoOrden,
                        Orden = new OrdenModel() { IdOrden = c.IdOrden, Clave = c.ClaveOrden },
                        EstatusOrden = new EstatusOrdenModel() { IdEstatusOrden = c.IdEstatusOrden },
                        FechaEstatus = c.FechaEstatus,
                        IdUsuarioModificacion = c.IdUsuarioModificacion
                    }
                    ).Where(d => d.Orden.IdOrden == historicoOrden.Orden.IdOrden).ToList();
        }
    }
}