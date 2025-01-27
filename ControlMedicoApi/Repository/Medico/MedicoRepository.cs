using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddMedico(Medico medico)
        {
            db.Medicos.Add(medico);
            db.SaveChanges();

            return medico.IdMedico;
        }

        public bool UpdateMedico(Medico medico)
        {
            Medico medicoDb = db.Medicos.Where(x => x.IdMedico == medico.IdMedico).FirstOrDefault();
            medicoDb.Nombre = medico.Nombre;
            medicoDb.Telefono = medico.Telefono;
            medicoDb.IdEspecialidad = medico.IdEspecialidad;
            medicoDb.Activo = medico.Activo;
            medicoDb.Correo = medico.Correo;
            medicoDb.CedulaProfesional = medico.CedulaProfesional;

            db.SaveChanges();

            return true;
        }

        public List<MedicoModel> GetAllMedicos()
        {
            return (from c in db.Medicos
                    select new MedicoModel
                    {
                        IdMedico = c.IdMedico,
                        Especialidad = new EspecialidadModel() { IdEspecialidad = c.IdEspecialidad == null ? 0 : (int)c.IdEspecialidad },
                        Nombre = c.Nombre,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        Correo = c.Correo,
                        CedulaProfesional = c.CedulaProfesional,
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = c.IdSuscripcion }
                    }
                    ).ToList();
        }

        public MedicoModel GetMedicoById(MedicoModel medico)
        {
            return (from c in db.Medicos
                    select new MedicoModel
                    {
                        IdMedico = c.IdMedico,
                        Especialidad = new EspecialidadModel() { IdEspecialidad = c.IdEspecialidad == null ? 0 : (int)c.IdEspecialidad },
                        Nombre = c.Nombre,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        Correo = c.Correo,
                        CedulaProfesional = c.CedulaProfesional,
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = c.IdSuscripcion }
                    }
                    ).Where(d => d.IdMedico == medico.IdMedico).FirstOrDefault();
        }

        public List<MedicoModel> GetMedicoByIdSuscripcion(MedicoModel medico)
        {
            return (from c in db.Medicos
                    select new MedicoModel
                    {
                        IdMedico = c.IdMedico,
                        Especialidad = new EspecialidadModel() { IdEspecialidad = c.IdEspecialidad == null ? 0 : (int)c.IdEspecialidad },
                        Nombre = c.Nombre,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        Correo = c.Correo,
                        CedulaProfesional = c.CedulaProfesional,
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = c.IdSuscripcion }
                    }
                    ).Where(d => d.Suscripcion.IdSuscriptor == medico.Suscripcion.IdSuscriptor).ToList();
        }
    }
}