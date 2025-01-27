using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddMedicamento(Medicamento medicamento)
        {
            db.Medicamentoes.Add(medicamento);
            db.SaveChanges();

            return medicamento.IdMedicamento;
        }

        public bool UpdateMedicamento(Medicamento medicamento)
        {
            Medicamento medicamentoDb = db.Medicamentoes.Where(x => x.IdMedicamento == medicamento.IdMedicamento).FirstOrDefault();
            medicamentoDb.Descripcion = medicamento.Descripcion;
            medicamentoDb.Activo = medicamento.Activo;
            medicamentoDb.IdMedico = medicamento.IdMedico;

            db.SaveChanges();

            return true;
        }

        public List<MedicamentoModel> GetAllMedicamentos()
        {
            return (from c in db.Medicamentoes
                    select new MedicamentoModel
                    {
                        IdMedicamento = c.IdMedicamento,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public MedicamentoModel GetMedicamentoById(MedicamentoModel medicamento)
        {
            return (from c in db.Medicamentoes
                    select new MedicamentoModel
                    {
                        IdMedicamento = c.IdMedicamento,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdMedicamento == medicamento.IdMedicamento).FirstOrDefault();
        }

        public List<MedicamentoModel> GetMedicamentoByIdMedico(MedicamentoModel medicamento)
        {
            return (from c in db.Medicamentoes
                    select new MedicamentoModel
                    {
                        IdMedicamento = c.IdMedicamento,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(d => d.Medico.IdMedico == medicamento.Medico.IdMedico).ToList();
        }

        public List<MedicamentoModel> GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento)
        {
            return (from c in db.Medicamentoes
                    select new MedicamentoModel
                    {
                        IdMedicamento = c.IdMedicamento,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico },
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).Where(x=> x.Activo == medicamento.Activo && x.Medico.IdMedico == medicamento.Medico.IdMedico).ToList();
        }
    }
}