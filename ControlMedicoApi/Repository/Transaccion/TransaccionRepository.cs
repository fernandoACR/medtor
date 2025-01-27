using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddTransaccion(Transaccion transaccion)
        {
            db.Transaccions.Add(transaccion);
            db.SaveChanges();

            return transaccion.IdTransaccion;
        }

        public bool UpdateTransaccion(Transaccion transaccion)
        {
            Transaccion transaccionDb = db.Transaccions.Where(x => x.IdTransaccion == transaccion.IdTransaccion).FirstOrDefault();
            transaccionDb.IdTipoTransaccion = transaccion.IdTipoTransaccion;
            transaccionDb.IdOperacionContable = transaccion.IdOperacionContable;
            transaccionDb.Fecha = transaccion.Fecha;
            transaccionDb.IdGenerado = transaccion.IdGenerado;
            transaccionDb.Monto = transaccion.Monto;
            transaccionDb.NumReferencia = transaccion.NumReferencia;
            transaccionDb.Observaciones = transaccion.Observaciones;
            transaccionDb.Estatus = transaccion.Estatus;

            db.SaveChanges();

            return true;
        }

        public List<TransaccionModel> GetAllTransaccions()
        {
            return (from c in db.Transaccions
                    select new TransaccionModel
                    {
                        IdTransaccion = c.IdTransaccion,
                        IdTipoTransaccion = c.IdTipoTransaccion,
                        IdOperacionContable = c.IdOperacionContable,
                        Fecha = c.Fecha,
                        IdGenerado = c.IdGenerado,
                        Monto = c.Monto,
                        NumReferencia = c.NumReferencia,
                        Observaciones = c.Observaciones,
                        Estatus = c.Estatus
                    }
                    ).ToList();
        }

        public TransaccionModel GetTransaccionById(TransaccionModel transaccion)
        {
            return (from c in db.Transaccions
                    select new TransaccionModel
                    {
                        IdTransaccion = c.IdTransaccion,
                        IdTipoTransaccion = c.IdTipoTransaccion,
                        IdOperacionContable = c.IdOperacionContable,
                        Fecha = c.Fecha,
                        IdGenerado = c.IdGenerado,
                        Monto = c.Monto,
                        NumReferencia = c.NumReferencia,
                        Observaciones = c.Observaciones,
                        Estatus = c.Estatus
                    }
                    ).Where(d => d.IdTransaccion == transaccion.IdTransaccion).FirstOrDefault();
        }
    }
}