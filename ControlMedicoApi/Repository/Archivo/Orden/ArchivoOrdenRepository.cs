using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ArchivoOrdenRepository : IArchivoOrdenRepository
    {
        private ControlMedicoFileDBEntities db = new ControlMedicoFileDBEntities();

        public int AddArchivoOrden(ArchivoOrden archivoOrden)
        {
            db.ArchivoOrden.Add(archivoOrden);
            db.SaveChanges();

            return archivoOrden.IdArchivoOrden;
        }

        public bool UpdateArchivoOrden(ArchivoOrden archivoOrden)
        {
            ArchivoOrden archivoOrdenDb = db.ArchivoOrden.Where(x => x.IdArchivoOrden == archivoOrden.IdArchivoOrden).FirstOrDefault();
            archivoOrdenDb.Descripcion = archivoOrden.Descripcion;
            archivoOrdenDb.IdOrden = archivoOrden.IdOrden;
            archivoOrdenDb.IdTipoArchivo = archivoOrden.IdTipoArchivo;
            archivoOrdenDb.Archivo = archivoOrden.Archivo;
            archivoOrdenDb.ExtensionArchivo = archivoOrden.ExtensionArchivo;
            archivoOrdenDb.Activo = archivoOrden.Activo;

            db.SaveChanges();

            return true;
        }

        public List<ArchivoOrdenModel> GetAllArchivoOrdens()
        {
            return (from c in db.ArchivoOrden
                    select new ArchivoOrdenModel
                    {
                        IdArchivoOrden = c.IdArchivoOrden,
                        Descripcion = c.Descripcion,
                        Orden = new OrdenModel() { IdOrden = c.IdOrden },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public ArchivoOrdenModel GetArchivoOrdenById(ArchivoOrdenModel archivoOrden)
        {
            var archivoOrdenModel = (from c in db.ArchivoOrden
                    select new ArchivoOrdenModel
                    {
                        IdArchivoOrden = c.IdArchivoOrden,
                        Descripcion = c.Descripcion,
                        Orden = new OrdenModel() { IdOrden = c.IdOrden },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdArchivoOrden == archivoOrden.IdArchivoOrden).FirstOrDefault();

            if (archivoOrdenModel != null)
            {
                archivoOrdenModel.Archivo = Convert.ToBase64String(archivoOrdenModel.ArchivoByte);
            }

            return archivoOrdenModel;
        }

        public List<ArchivoOrdenModel> GetArchivoOrdenByIdOrden(ArchivoOrdenModel archivoOrden)
        {
            var archivoOrdenModel = (from c in db.ArchivoOrden
                                                        select new ArchivoOrdenModel
                                                        {
                                                            IdArchivoOrden = c.IdArchivoOrden,
                                                            Descripcion = c.Descripcion,
                                                            Orden = new OrdenModel() { IdOrden = c.IdOrden },
                                                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                                                            ArchivoByte = c.Archivo,
                                                            ExtensionArchivo = c.ExtensionArchivo,
                                                            Activo = c.Activo,
                                                            Codigo = c.Codigo
                                                        }
                    ).Where(d => d.Orden.IdOrden == archivoOrden.Orden.IdOrden).ToList();

            if (archivoOrdenModel != null)
            {
                foreach (ArchivoOrdenModel archivo in archivoOrdenModel)
                {
                    archivo.Archivo = Convert.ToBase64String(archivo.ArchivoByte);
                }
            }

            return archivoOrdenModel;
        }

        public int DeleteArchivoOrden(ArchivoOrden archivoOrden)
        {
            var archivoOrdenDb = db.ArchivoOrden.Where(x => x.Codigo == archivoOrden.Codigo).FirstOrDefault();
            db.ArchivoOrden.Remove(archivoOrdenDb);
            db.SaveChanges();

            return archivoOrden.IdArchivoOrden;
        }
    }
}