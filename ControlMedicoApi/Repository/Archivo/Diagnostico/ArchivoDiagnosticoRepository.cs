using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ArchivoDiagnosticoRepository : IArchivoDiagnosticoRepository
    {
        private ControlMedicoFileDBEntities db = new ControlMedicoFileDBEntities();

        public int AddArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico)
        {
            db.ArchivoDiagnostico.Add(archivoDiagnostico);
            db.SaveChanges();

            return archivoDiagnostico.IdArchivoDiagnostico;
        }

        public bool UpdateArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico)
        {
            ArchivoDiagnostico archivoDiagnosticoDb = db.ArchivoDiagnostico.Where(x => x.IdArchivoDiagnostico == archivoDiagnostico.IdArchivoDiagnostico).FirstOrDefault();
            archivoDiagnosticoDb.Descripcion = archivoDiagnostico.Descripcion;
            archivoDiagnosticoDb.IdDiagnostico = archivoDiagnostico.IdDiagnostico;
            archivoDiagnosticoDb.IdTipoArchivo = archivoDiagnostico.IdTipoArchivo;
            archivoDiagnosticoDb.Archivo = archivoDiagnostico.Archivo;
            archivoDiagnosticoDb.ExtensionArchivo = archivoDiagnostico.ExtensionArchivo;
            archivoDiagnosticoDb.Activo = archivoDiagnostico.Activo;

            db.SaveChanges();

            return true;
        }

        public List<ArchivoDiagnosticoModel> GetAllArchivoDiagnosticos()
        {
            return (from c in db.ArchivoDiagnostico
                    select new ArchivoDiagnosticoModel
                    {
                        IdArchivoDiagnostico = c.IdArchivoDiagnostico,
                        Descripcion = c.Descripcion,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = c.IdDiagnostico },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public ArchivoDiagnosticoModel GetArchivoDiagnosticoById(ArchivoDiagnosticoModel archivoDiagnostico)
        {
            var archivoDiagnosticoModel = (from c in db.ArchivoDiagnostico
                    select new ArchivoDiagnosticoModel
                    {
                        IdArchivoDiagnostico = c.IdArchivoDiagnostico,
                        Descripcion = c.Descripcion,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = c.IdDiagnostico },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdArchivoDiagnostico == archivoDiagnostico.IdArchivoDiagnostico).FirstOrDefault();

            if (archivoDiagnosticoModel != null)
            {
                archivoDiagnosticoModel.Archivo = Convert.ToBase64String(archivoDiagnosticoModel.ArchivoByte);
            }

            return archivoDiagnosticoModel;
        }

        public List<ArchivoDiagnosticoModel> GetArchivoDiagnosticoByIdDiagnostico(ArchivoDiagnosticoModel archivoDiagnostico)
        {
            var archivoDiagnosticoModel = (from c in db.ArchivoDiagnostico
                                                        select new ArchivoDiagnosticoModel
                                                        {
                                                            IdArchivoDiagnostico = c.IdArchivoDiagnostico,
                                                            Descripcion = c.Descripcion,
                                                            Diagnostico = new DiagnosticoModel() { IdDiagnostico = c.IdDiagnostico },
                                                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                                                            ArchivoByte = c.Archivo,
                                                            ExtensionArchivo = c.ExtensionArchivo,
                                                            Activo = c.Activo,
                                                            Codigo = c.Codigo
                                                        }
                    ).Where(d => d.Diagnostico.IdDiagnostico == archivoDiagnostico.Diagnostico.IdDiagnostico).ToList();

            if (archivoDiagnosticoModel != null)
            {
                foreach (ArchivoDiagnosticoModel archivo in archivoDiagnosticoModel)
                {
                    archivo.Archivo = Convert.ToBase64String(archivo.ArchivoByte);
                }
            }

            return archivoDiagnosticoModel;
        }

        public int DeleteArchivoDiagnostico(ArchivoDiagnostico archivoDiagnostico)
        {
            var archivoDiagnosticoDb = db.ArchivoDiagnostico.Where(x => x.Codigo == archivoDiagnostico.Codigo).FirstOrDefault();
            db.ArchivoDiagnostico.Remove(archivoDiagnosticoDb);
            db.SaveChanges();

            return archivoDiagnostico.IdArchivoDiagnostico;
        }
    }
}