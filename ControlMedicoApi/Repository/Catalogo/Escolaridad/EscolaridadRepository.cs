using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class EscolaridadRepository : IEscolaridadRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddEscolaridad(Escolaridad escolaridad)
        {
            db.Escolaridads.Add(escolaridad);
            db.SaveChanges();

            return escolaridad.IdEscolaridad;
        }

        public bool UpdateEscolaridad(Escolaridad escolaridad)
        {
            Escolaridad escolaridadDb = db.Escolaridads.Where(x => x.IdEscolaridad == escolaridad.IdEscolaridad).FirstOrDefault();
            escolaridadDb.Descripcion = escolaridad.Descripcion;
            escolaridadDb.Clave = escolaridad.Clave;
            escolaridadDb.Activo = escolaridad.Activo;

            db.SaveChanges();

            return true;
        }

        public List<EscolaridadModel> GetAllEscolaridades()
        {
            return (from c in db.Escolaridads
                    select new EscolaridadModel
                    {
                        IdEscolaridad = c.IdEscolaridad,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public EscolaridadModel GetEscolaridadById(EscolaridadModel escolaridad)
        {
            return (from c in db.Escolaridads
                    select new EscolaridadModel
                    {
                        IdEscolaridad = c.IdEscolaridad,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdEscolaridad == escolaridad.IdEscolaridad).FirstOrDefault();
        }
    }
}