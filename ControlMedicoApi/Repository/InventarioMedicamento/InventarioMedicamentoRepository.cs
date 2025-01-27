using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class InventarioMedicamentoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddInventarioMedicamento(InventarioMedicamento inventarioMedicamento)
        {
            db.InventarioMedicamentoes.Add(inventarioMedicamento);
            db.SaveChanges();

            return inventarioMedicamento.IdInventarioMedicamento;
        }

        public bool UpdateInventarioMedicamento(InventarioMedicamento inventarioMedicamento)
        {
            InventarioMedicamento inventarioMedicamentoDb = db.InventarioMedicamentoes.Where(x => x.IdInventarioMedicamento == inventarioMedicamento.IdInventarioMedicamento).FirstOrDefault();
            inventarioMedicamentoDb.IdMedicamento = inventarioMedicamento.IdMedicamento;
            inventarioMedicamentoDb.Codigo = inventarioMedicamento.Codigo;
            inventarioMedicamentoDb.FechaVencimiento = inventarioMedicamento.FechaVencimiento;

            db.SaveChanges();

            return true;
        }

        public List<InventarioMedicamentoModel> GetAllInventarioMedicamentos()
        {
            return (from c in db.InventarioMedicamentoes
                    select new InventarioMedicamentoModel
                    {
                        IdInventarioMedicamento = c.IdInventarioMedicamento,
                        Codigo = c.Codigo,
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        FechaVencimiento = c.FechaVencimiento,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).ToList();
        }

        public InventarioMedicamentoModel GetInventarioMedicamentoById(InventarioMedicamentoModel inventarioMedicamento)
        {
            return (from c in db.InventarioMedicamentoes
                    select new InventarioMedicamentoModel
                    {
                        IdInventarioMedicamento = c.IdInventarioMedicamento,
                        Codigo = c.Codigo,
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        FechaVencimiento = c.FechaVencimiento,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).Where(d => d.IdInventarioMedicamento == inventarioMedicamento.IdInventarioMedicamento).FirstOrDefault();
        }

        public List<InventarioMedicamentoModel> GetInventarioMedicamentoByIdMedicamento(MedicamentoModel medicamento)
        {
            return (from c in db.InventarioMedicamentoes
                    select new InventarioMedicamentoModel
                    {
                        IdInventarioMedicamento = c.IdInventarioMedicamento,
                        Codigo = c.Codigo,
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        FechaVencimiento = c.FechaVencimiento,
                        FechaCreacion = c.FechaCreacion
                    }
                    ).Where(d => d.Medicamento.IdMedicamento == medicamento.IdMedicamento).ToList();
        }
    }
}