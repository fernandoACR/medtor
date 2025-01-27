using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository 
{
    public class RecetaRepository : IRecetaRepository 
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddReceta(Receta receta)
        {
            db.Recetas.Add(receta);
            db.SaveChanges();

            return receta.IdReceta;
        }

        public bool UpdateReceta(Receta receta)
        {
            Receta recetaDb = db.Recetas.Where(x => x.IdReceta == receta.IdReceta).FirstOrDefault();
            recetaDb.IdPaciente = receta.IdPaciente;
            recetaDb.IdMedico = receta.IdMedico;
            recetaDb.IdDiagnostico = receta.IdDiagnostico;
            recetaDb.FechaCreacion = (DateTime)receta.FechaModificacion;
            receta.Activo = receta.Activo;

            db.SaveChanges();

            return true;
        }

        public List<RecetaModel> GetAllRecetas()
        {
            return (from c in db.Recetas
                    select new RecetaModel
                    {
                        IdReceta = c.IdReceta,
                        Diagnostico = c.IdDiagnostico != null ? new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico } : null,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).ToList();
        }

        public RecetaModel GetRecetaById(RecetaModel receta)
        {
            return (from c in db.Recetas
                    select new RecetaModel
                    {
                        IdReceta = c.IdReceta,
                        Diagnostico = c.IdDiagnostico != null ? new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico } : null,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).Where(d => d.IdReceta == receta.IdReceta).FirstOrDefault();
        }

        public List<RecetaModel> GetRecetaByIdDiagnostico(RecetaModel receta)
        {
            return (from c in db.Recetas
                    select new RecetaModel
                    {
                        IdReceta = c.IdReceta,
                        Diagnostico = c.IdDiagnostico != null ? new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico } : null,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).Where(d => d.Diagnostico.IdDiagnostico == receta.Diagnostico.IdDiagnostico).ToList();
        }

        public List<RecetaModel> GetRecetaByIdMedico(RecetaModel receta)
        {
            return (from c in db.Recetas
                    select new RecetaModel
                    {
                        IdReceta = c.IdReceta,
                        Diagnostico = c.IdDiagnostico != null ? new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico } : null,
                        Paciente = new PacienteModel() { IdPaciente = c.IdPaciente },
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).Where(d => d.Medico.IdMedico == receta.Medico.IdMedico).ToList();
        }
    }
}