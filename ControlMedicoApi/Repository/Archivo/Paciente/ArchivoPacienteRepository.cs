using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ArchivoPacienteRepository : IArchivoPacienteRepository
    {
        private ControlMedicoFileDBEntities db = new ControlMedicoFileDBEntities();

        public int AddArchivoPaciente(ArchivoPaciente archivoPaciente)
        {
            db.ArchivoPaciente.Add(archivoPaciente);
            db.SaveChanges();

            return archivoPaciente.IdArchivoPaciente;
        }

        public bool UpdateArchivoPaciente(ArchivoPaciente archivoPaciente)
        {
            ArchivoPaciente archivoPacienteDb = db.ArchivoPaciente.Where(x => x.IdArchivoPaciente == archivoPaciente.IdArchivoPaciente).FirstOrDefault();
            archivoPacienteDb.Descripcion = archivoPaciente.Descripcion;
            archivoPacienteDb.IdPaciente = archivoPaciente.IdPaciente;
            archivoPacienteDb.IdTipoArchivo = archivoPaciente.IdTipoArchivo;
            archivoPacienteDb.Archivo = archivoPaciente.Archivo;
            archivoPacienteDb.ExtensionArchivo = archivoPaciente.ExtensionArchivo;
            archivoPacienteDb.Activo = archivoPaciente.Activo;

            db.SaveChanges();

            return true;
        }

        public List<ArchivoPacienteModel> GetAllArchivoPacientes()
        {
            return (from c in db.ArchivoPaciente
                    select new ArchivoPacienteModel
                    {
                        IdArchivoPaciente = c.IdArchivoPaciente,
                        Descripcion = c.Descripcion,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public ArchivoPacienteModel GetArchivoPacienteById(ArchivoPacienteModel archivoPaciente)
        {
            var archivoPacienteModel = (from c in db.ArchivoPaciente
                    select new ArchivoPacienteModel
                    {
                        IdArchivoPaciente = c.IdArchivoPaciente,
                        Descripcion = c.Descripcion,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                        Archivo = Convert.ToBase64String(c.Archivo),
                        ExtensionArchivo = c.ExtensionArchivo,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdArchivoPaciente == archivoPaciente.IdArchivoPaciente).FirstOrDefault();

            if (archivoPacienteModel != null)
            {
                archivoPacienteModel.Archivo = Convert.ToBase64String(archivoPacienteModel.ArchivoByte);
            }

            return archivoPacienteModel;
        }

        public ArchivoPacienteModel GetArchivoPacienteByIdPaciente(ArchivoPacienteModel archivoPaciente)
        {
            var archivoPacienteModel = (from c in db.ArchivoPaciente
                                                        select new ArchivoPacienteModel
                                                        {
                                                            IdArchivoPaciente = c.IdArchivoPaciente,
                                                            Descripcion = c.Descripcion,
                                                            Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                                                            TipoArchivo = new TipoArchivoModel() { IdTipoArchivo = c.IdTipoArchivo },
                                                            ArchivoByte = c.Archivo,
                                                            ExtensionArchivo = c.ExtensionArchivo,
                                                            Activo = c.Activo
                                                        }
                    ).Where(d => d.Paciente.IdPaciente == archivoPaciente.Paciente.IdPaciente).FirstOrDefault();

            if (archivoPacienteModel != null)
            {
                archivoPacienteModel.Archivo = Convert.ToBase64String(archivoPacienteModel.ArchivoByte);
            }

            return archivoPacienteModel;
        }
    }
}