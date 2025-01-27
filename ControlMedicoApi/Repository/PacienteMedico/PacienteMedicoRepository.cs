using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class PacienteMedicoRepository : IPacienteMedicoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddPacienteMedico(PacienteMedico pacienteMedico)
        {
            db.PacienteMedicoes.Add(pacienteMedico);
            db.SaveChanges();

            return pacienteMedico.IdPacienteMedico;
        }

        public bool UpdatePacienteMedico(PacienteMedico pacienteMedico)
        {
            PacienteMedico pacienteMedicoDb = db.PacienteMedicoes.Where(x => x.IdPacienteMedico == pacienteMedico.IdPacienteMedico).FirstOrDefault();
            pacienteMedicoDb.IdPaciente = pacienteMedico.IdPaciente;
            pacienteMedicoDb.IdMedico = pacienteMedico.IdMedico;
            db.SaveChanges();

            return true;
        }

        public List<PacienteMedicoModel> GetAllPacienteMedicos()
        {
            return (from c in db.PacienteMedicoes
                    select new PacienteMedicoModel
                    {
                        IdPacienteMedico = c.IdPacienteMedico,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = (int)c.IdSuscripcion }
                    }
                    ).ToList();
        }

        public PacienteMedicoModel GetPacienteMedicoById(PacienteMedicoModel pacienteMedico)
        {
            return (from c in db.PacienteMedicoes
                    select new PacienteMedicoModel
                    {
                        IdPacienteMedico = c.IdPacienteMedico,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Suscripcion = new SuscripcionModel() { IdSuscriptor = (int)c.IdSuscripcion }
                    }
                    ).Where(d => d.IdPacienteMedico == pacienteMedico.IdPacienteMedico).FirstOrDefault();
        }

        public List<PacienteModel> GetPacienteByIdMedico(MedicoModel medico)
        {
            return (from c in db.PacienteMedicoes.Where(x=> x.IdMedico == medico.IdMedico)
                    select new PacienteModel
                    {
                        IdPaciente = c.IdPaciente
                    }
                    ).ToList();
        }
    }
}