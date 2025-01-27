using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ArchivoMedicoRepository : IArchivoMedicoRepository
    {
        private ControlMedicoFileDBEntities db = new ControlMedicoFileDBEntities();

        public int AddArchivoMedico(ArchivoMedico archivoMedico)
        {
            db.ArchivoMedico.Add(archivoMedico);
            db.SaveChanges();

            return archivoMedico.IdArchivoMedico;
        }

        public bool UpdateArchivoMedico(ArchivoMedico archivoMedico)
        {
            ArchivoMedico archivoMedicoDb = db.ArchivoMedico.Where(x => x.IdArchivoMedico == archivoMedico.IdArchivoMedico).FirstOrDefault();
            archivoMedicoDb.Descripcion = archivoMedico.Descripcion;
            archivoMedicoDb.IdMedico = archivoMedico.IdMedico;
            archivoMedicoDb.IdTipoArchivo = archivoMedico.IdTipoArchivo;
            archivoMedicoDb.Archivo = archivoMedico.Archivo;
            archivoMedicoDb.ExtensionArchivo = archivoMedico.ExtensionArchivo;
            archivoMedicoDb.Activo = archivoMedico.Activo;

            db.SaveChanges();

            return true;
        }

        public List<ArchivoMedicoModel> GetAllArchivoMedicos()
        {
            return (from c in db.ArchivoMedico
                    select new ArchivoMedicoModel
                    {
                        IdArchivoMedico = c.IdArchivoMedico,
                        Descripcion = c.Descripcion,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public ArchivoMedicoModel GetArchivoMedicoById(ArchivoMedicoModel archivoMedico)
        {
            var archivoMedicoModel = (from c in db.ArchivoMedico
                                        select new ArchivoMedicoModel
                                        {
                                            IdArchivoMedico = c.IdArchivoMedico,
                                            Descripcion = c.Descripcion,
                                            Medico = new MedicoModel() { IdMedico = c.IdMedico },
                                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                                            Archivo = Convert.ToBase64String(c.Archivo),
                                            ExtensionArchivo = c.ExtensionArchivo,
                                            Activo = c.Activo
                                        }
                    ).Where(d => d.IdArchivoMedico == archivoMedico.IdArchivoMedico).FirstOrDefault();

            if (archivoMedicoModel != null)
            {
                archivoMedicoModel.Archivo = Convert.ToBase64String(archivoMedicoModel.ArchivoByte);
            }

            return archivoMedicoModel;
        }

        public ArchivoMedicoModel GetArchivoMedicoByIdMedico(ArchivoMedicoModel archivoMedico)
        {
            var archivoMedicoModel = (from c in db.ArchivoMedico
                                        select new ArchivoMedicoModel
                                        {
                                            IdArchivoMedico = c.IdArchivoMedico,
                                            Descripcion = c.Descripcion,
                                            Medico = new MedicoModel() { IdMedico = c.IdMedico },
                                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                                            ArchivoByte = c.Archivo,
                                            ExtensionArchivo = c.ExtensionArchivo,
                                            Activo = c.Activo
                                        }
                    ).Where(d => d.Medico.IdMedico == archivoMedico.Medico.IdMedico).FirstOrDefault();

            if (archivoMedicoModel != null)
            {
                archivoMedicoModel.Archivo = Convert.ToBase64String(archivoMedicoModel.ArchivoByte);
            }

            return archivoMedicoModel;
        }
    }
}