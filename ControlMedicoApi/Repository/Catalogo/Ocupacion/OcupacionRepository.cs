using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class OcupacionRepository : IOcupacionRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddOcupacion(Ocupacion ocupacion)
        {
            db.Ocupacions.Add(ocupacion);
            db.SaveChanges();

            return ocupacion.IdOcupacion;
        }

        public bool UpdateOcupacion(Ocupacion ocupacion)
        {
            Ocupacion ocupacionDb = db.Ocupacions.Where(x => x.IdOcupacion == ocupacion.IdOcupacion).FirstOrDefault();
            ocupacionDb.Descripcion = ocupacion.Descripcion;
            ocupacionDb.Clave = ocupacion.Clave;
            ocupacionDb.Activo = ocupacion.Activo;

            db.SaveChanges();

            return true;
        }

        public List<OcupacionModel> GetAllOcupacions()
        {
            return (from c in db.Ocupacions
                    select new OcupacionModel
                    {
                        IdOcupacion = c.IdOcupacion,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public OcupacionModel GetOcupacionById(OcupacionModel ocupacion)
        {
            return (from c in db.Ocupacions
                    select new OcupacionModel
                    {
                        IdOcupacion = c.IdOcupacion,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdOcupacion == ocupacion.IdOcupacion).FirstOrDefault();
        }
    }
}