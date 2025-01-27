using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class TipoArchivoRepository : ITipoArchivoRepository
    {
        private ControlMedicoFileDBEntities db = new ControlMedicoFileDBEntities();

        public int AddTipoArchivo(TipoArchivo tipoArchivo)
        {
            db.TipoArchivo.Add(tipoArchivo);
            db.SaveChanges();

            return tipoArchivo.IdTipoArchivo;
        }

        public bool UpdateTipoArchivo(TipoArchivo tipoArchivo)
        {
            TipoArchivo tipoArchivoDb = db.TipoArchivo.Where(x => x.IdTipoArchivo == tipoArchivo.IdTipoArchivo).FirstOrDefault();
            tipoArchivoDb.Descripcion = tipoArchivo.Descripcion;
            tipoArchivoDb.Activo = tipoArchivo.Activo;

            db.SaveChanges();

            return true;
        }

        public List<TipoArchivoModel> GetAllTipoArchivos()
        {
            return (from c in db.TipoArchivo
                    select new TipoArchivoModel
                    {
                        IdTipoArchivo = c.IdTipoArchivo,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public TipoArchivoModel GetTipoArchivoById(TipoArchivoModel tipoArchivo)
        {
            return (from c in db.TipoArchivo
                    select new TipoArchivoModel
                    {
                        IdTipoArchivo = c.IdTipoArchivo,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdTipoArchivo == tipoArchivo.IdTipoArchivo).FirstOrDefault();
        }
    }
}