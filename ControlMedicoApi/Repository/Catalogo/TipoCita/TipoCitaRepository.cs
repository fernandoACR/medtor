using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class TipoCitaRepository : ITipoCitaRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddTipoCita(TipoCita tipoCita)
        {
            db.TipoCitas.Add(tipoCita);
            db.SaveChanges();

            return tipoCita.IdTipoCita;
        }

        public bool UpdateTipoCita(TipoCita tipoCita)
        {
            TipoCita tipoCitaDb = db.TipoCitas.Where(x => x.IdTipoCita == tipoCita.IdTipoCita).FirstOrDefault();
            tipoCitaDb.Descripcion = tipoCita.Descripcion;
            tipoCitaDb.Clave = tipoCita.Clave;
            tipoCitaDb.Activo = tipoCita.Activo;

            db.SaveChanges();

            return true;
        }

        public List<TipoCitaModel> GetAllTipoCitas()
        {
            return (from c in db.TipoCitas
                    select new TipoCitaModel
                    {
                        IdTipoCita = c.IdTipoCita,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public TipoCitaModel GetTipoCitaById(TipoCitaModel tipoCita)
        {
            return (from c in db.TipoCitas
                    select new TipoCitaModel
                    {
                        IdTipoCita = c.IdTipoCita,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdTipoCita == tipoCita.IdTipoCita).FirstOrDefault();
        }
    }
}