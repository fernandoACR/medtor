using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class CitaRepository : ICitaRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddCita(Cita cita)
        {
            try
            {
                db.Citas.Add(cita);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
            

            return cita.IdCita;
        }

        public bool UpdateCita(Cita cita)
        {
            Cita citaDb = db.Citas.Where(x => x.IdCita == cita.IdCita).FirstOrDefault();
            citaDb.IdMedico = cita.IdMedico;
            citaDb.IdPaciente = cita.IdPaciente;
            citaDb.FechaCitaDesde = cita.FechaCitaDesde;
            citaDb.FechaModificacion = cita.FechaModificacion;
            citaDb.Comentarios = cita.Comentarios;
            citaDb.Titulo = cita.Titulo;
            citaDb.Estatus = cita.Estatus;
            citaDb.FechaCitaHasta = cita.FechaCitaHasta;
            citaDb.IdTipoCita = cita.IdTipoCita;
            db.SaveChanges();

            return true;
        }

        public List<CitaModel> GetAllCitas()
        {
            return (from c in db.Citas
                    select new CitaModel
                    {
                        IdCita = c.IdCita,
                        Medico = new MedicoModel { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel { IdPaciente = c.IdPaciente == null ? 0 : (int)c.IdPaciente },
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        Comentarios = c.Comentarios,
                        Titulo = c.Titulo,
                        EstatusCita = new EstatusCitaModel {IdEstatusCita = c.Estatus },
                        TipoCita = new TipoCitaModel() { IdTipoCita = c.IdTipoCita },
                        FechaCitaDesde = c.FechaCitaDesde,
                        FechaCitaHasta = c.FechaCitaHasta
        }
                    ).ToList();
        }

        public CitaModel GetCitaById(CitaModel cita)
        {
            return (from c in db.Citas
                    select new CitaModel
                    {
                        IdCita = c.IdCita,
                        Medico = new MedicoModel { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel { IdPaciente = c.IdPaciente == null ? 0 : (int)c.IdPaciente },
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        Comentarios = c.Comentarios,
                        Titulo = c.Titulo,
                        EstatusCita = new EstatusCitaModel { IdEstatusCita = c.Estatus },
                        TipoCita = new TipoCitaModel() { IdTipoCita = c.IdTipoCita },
                        FechaCitaDesde = c.FechaCitaDesde,
                        FechaCitaHasta = c.FechaCitaHasta
                    }
                    ).Where(d => d.IdCita == cita.IdCita).FirstOrDefault();
        }

        public List<CitaModel> GetCitasByIdMedico(CitaModel cita)
        {
            return (from c in db.Citas
                    select new CitaModel
                    {
                        IdCita = c.IdCita,
                        Medico = new MedicoModel { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel { IdPaciente = c.IdPaciente == null ? 0 : (int)c.IdPaciente },
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        Comentarios = c.Comentarios,
                        Titulo = c.Titulo,
                        EstatusCita = new EstatusCitaModel { IdEstatusCita = c.Estatus },
                        TipoCita = new TipoCitaModel() { IdTipoCita = c.IdTipoCita },
                        FechaCitaDesde = c.FechaCitaDesde,
                        FechaCitaHasta = c.FechaCitaHasta
                    }
                    ).Where(d=>d.Medico.IdMedico == cita.Medico.IdMedico).ToList();
        }

        public void DeleteCita(Cita cita)
        {
            try
            {
                db.Citas.Attach(cita);
                db.Citas.Remove(cita);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                e.Message.ToString();
                throw;
            }
        }

        public List<CitaModel> GetCitasByFechaAndIdMedico(CitaModel cita)
        {
            List<CitaModel> citas =  (from c in db.Citas
                                        select new CitaModel
                                        {
                                            IdCita = c.IdCita,
                                            Medico = new MedicoModel { IdMedico = c.IdMedico },
                                            Paciente = new PacienteModel { IdPaciente = c.IdPaciente == null ? 0 : (int)c.IdPaciente },
                                            FechaCreacion = c.FechaCreacion,
                                            FechaModificacion = c.FechaModificacion,
                                            Comentarios = c.Comentarios,
                                            Titulo = c.Titulo,
                                            EstatusCita = new EstatusCitaModel { IdEstatusCita = c.Estatus },
                                            TipoCita = new TipoCitaModel() { IdTipoCita = c.IdTipoCita },
                                            FechaCitaDesde = c.FechaCitaDesde,
                                            FechaCitaHasta = c.FechaCitaHasta
                                        }
                                        ).Where(d =>d.Medico.IdMedico == cita.Medico.IdMedico).ToList();

            citas = citas.Where(f => f.FechaCitaDesde.Date == cita.FechaCitaDesde.Date).ToList();

            return citas;
        }

        public List<CitaModel> GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita)
        {
            return (from c in db.Citas
                    select new CitaModel
                    {
                        IdCita = c.IdCita,
                        Medico = new MedicoModel { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel { IdPaciente = c.IdPaciente == null ? 0 : (int)c.IdPaciente },
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        Comentarios = c.Comentarios,
                        Titulo = c.Titulo,
                        EstatusCita = new EstatusCitaModel { IdEstatusCita = c.Estatus },
                        TipoCita = new TipoCitaModel() { IdTipoCita = c.IdTipoCita },
                        FechaCitaDesde = c.FechaCitaDesde,
                        FechaCitaHasta = c.FechaCitaHasta
                    }
                    ).Where(d => d.Medico.IdMedico == cita.Medico.IdMedico && d.EstatusCita.IdEstatusCita == cita.EstatusCita.IdEstatusCita).ToList();
        }
    }
}