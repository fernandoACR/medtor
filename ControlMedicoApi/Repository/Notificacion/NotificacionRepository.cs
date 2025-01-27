using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository 
{
    public class NotificacionRepository : INotificacionRepository 
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddNotificacion(Notificacion notificacion)
        {
            db.Notificacions.Add(notificacion);
            db.SaveChanges();

            return notificacion.IdNotificacion;
        }

        public bool UpdateNotificacion(Notificacion notificacion)
        {
            Notificacion notificacionDb = db.Notificacions.Where(x => x.IdNotificacion == notificacion.IdNotificacion).FirstOrDefault();
            notificacionDb.IdPaciente = notificacion.IdPaciente;
            notificacionDb.IdMedico = notificacion.IdMedico;
            notificacionDb.IdTipoNotificacion = notificacion.IdTipoNotificacion;
            notificacionDb.FechaNotificacion = (DateTime)notificacion.FechaNotificacion;
            notificacionDb.HoraNotificacion = (DateTime)notificacion.HoraNotificacion;
            notificacionDb.Recursivo = notificacion.Recursivo;
            notificacionDb.Activo = notificacion.Activo;
            notificacionDb.IdCita = notificacion.IdCita;

            db.SaveChanges();

            return true;
        }

        public List<NotificacionModel> GetAllNotificacions()
        {
            return (from c in db.Notificacions
                    select new NotificacionModel
                    {
                        IdNotificacion = c.IdNotificacion,
                        TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)c.IdTipoNotificacion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        Activo = c.Activo,
                        FechaNotificacion = c.FechaNotificacion,
                        HoraNotificacion = c.HoraNotificacion,
                        Recursivo = c.Recursivo,
                        Cita = new CitaModel() { IdCita = c.IdCita == null ? 0 : (int)c.IdCita }
                    }
                    ).ToList();
        }

        public NotificacionModel GetNotificacionById(NotificacionModel notificacion)
        {
            return (from c in db.Notificacions
                    select new NotificacionModel
                    {
                        IdNotificacion = c.IdNotificacion,
                        TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)c.IdTipoNotificacion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        Activo = c.Activo,
                        FechaNotificacion = c.FechaNotificacion,
                        HoraNotificacion = c.HoraNotificacion,
                        Recursivo = c.Recursivo,
                        Cita = new CitaModel() { IdCita = c.IdCita == null ? 0 : (int)c.IdCita },
                        MedioNotificacion = new MedioNotificacionModel() { IdMedioNotificacion = c.IdMedioNotificacion == null ? 0 : (int)c.IdMedioNotificacion }
                    }
                    ).Where(d => d.IdNotificacion == notificacion.IdNotificacion).FirstOrDefault();
        }

        public List<NotificacionModel> GetNotificacionByIdPaciente(NotificacionModel notificacion)
        {
            return (from c in db.Notificacions
                    select new NotificacionModel
                    {
                        IdNotificacion = c.IdNotificacion,
                        TipoNotificacion = new TipoNotificacionModel() { IdTipoNotificacion = (int)c.IdTipoNotificacion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        Activo = c.Activo,
                        FechaNotificacion = c.FechaNotificacion,
                        HoraNotificacion = c.HoraNotificacion,
                        Recursivo = c.Recursivo,
                        Cita = new CitaModel() { IdCita = c.IdCita == null ? 0 : (int)c.IdCita }
                    }
                    ).Where(d => d.Paciente.IdPaciente == notificacion.Paciente.IdPaciente).ToList();
        }
    }
}