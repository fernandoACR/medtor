using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddDiagnostico(Diagnostico diagnostico)
        {
            db.Diagnosticoes.Add(diagnostico);
            db.SaveChanges();

            return diagnostico.IdDiagnostico;
        }

        public bool UpdateDiagnostico(Diagnostico diagnostico)
        {
            Diagnostico diagnosticoDb = db.Diagnosticoes.Where(x => x.IdDiagnostico == diagnostico.IdDiagnostico).FirstOrDefault();
            diagnosticoDb.IdPaciente = diagnostico.IdPaciente;
            diagnosticoDb.IdMedico = diagnostico.IdMedico;
            diagnosticoDb.Alergias = diagnostico.Alergias;
            diagnosticoDb.FechaModificacion = diagnostico.FechaModificacion;
            diagnosticoDb.Altura = diagnostico.Altura;
            diagnosticoDb.Peso = diagnostico.Peso;
            diagnosticoDb.Activo = diagnostico.Activo;
            diagnosticoDb.Descripcion = diagnostico.Descripcion;

            db.SaveChanges();

            return true;
        }

        public List<DiagnosticoModel> GetAllDiagnosticos()
        {
            return (from c in db.Diagnosticoes
                    select new DiagnosticoModel
                    {
                        IdDiagnostico = c.IdDiagnostico,
                        Altura = c.Altura,
                        Alergias = c.Alergias,
                        Peso = c.Peso,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        Descripcion= c.Descripcion
                    }
                    ).ToList();
        }

        public DiagnosticoModel GetDiagnosticoById(DiagnosticoModel diagnostico)
        {
            return (from c in db.Diagnosticoes
                    select new DiagnosticoModel
                    {
                        IdDiagnostico = c.IdDiagnostico,
                        Altura = c.Altura,
                        Alergias = c.Alergias,
                        Peso = c.Peso,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        Descripcion= c.Descripcion,
                        Cita = new CitaModel() { IdCita = c.IdCita != null ? (int)c.IdCita : 0 }
                    }
                    ).Where(d => d.IdDiagnostico == diagnostico.IdDiagnostico).FirstOrDefault();
        }

        public List<DiagnosticoModel> GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico)
        {
            return (from c in db.Diagnosticoes
                    select new DiagnosticoModel
                    {
                        IdDiagnostico = c.IdDiagnostico,
                        Altura = c.Altura,
                        Alergias = c.Alergias,
                        Peso = c.Peso,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        Descripcion = c.Descripcion,
                        Cita = new CitaModel() { IdCita = c.IdCita != null ? (int)c.IdCita : 0 }
                    }
                    ).Where(d => d.Medico.IdMedico == diagnostico.Medico.IdMedico).ToList();
        }

        public List<DiagnosticoModel> GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico)
        {
            return (from c in db.Diagnosticoes
                    select new DiagnosticoModel
                    {
                        IdDiagnostico = c.IdDiagnostico,
                        Altura = c.Altura,
                        Alergias = c.Alergias,
                        Peso = c.Peso,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        Descripcion = c.Descripcion,
                        Cita = new CitaModel() { IdCita = c.IdCita != null ? (int)c.IdCita : 0 }
                    }
                    ).Where(d => d.Paciente.IdPaciente == diagnostico.Paciente.IdPaciente).ToList();
        }
    }
}