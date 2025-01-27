using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class RecetaMedicamentoRepository : IRecetaMedicamentoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddRecetaMedicamento(RecetaMedicamento recetaMedicamento)
        {
            db.RecetaMedicamentoes.Add(recetaMedicamento);
            db.SaveChanges();

            return recetaMedicamento.IdRecetaMedicamento;
        }

        public bool UpdateRecetaMedicamento(RecetaMedicamento recetaMedicamento)
        {
            RecetaMedicamento recetaMedicamentoDb = db.RecetaMedicamentoes.Where(x => x.IdRecetaMedicamento == recetaMedicamento.IdRecetaMedicamento).FirstOrDefault();
            recetaMedicamentoDb.IdReceta = recetaMedicamento.IdReceta;
            recetaMedicamentoDb.IdMedicamento = recetaMedicamento.IdMedicamento;
            recetaMedicamentoDb.Cantidad = recetaMedicamento.Cantidad;
            recetaMedicamentoDb.Frecuencia = recetaMedicamento.Frecuencia;

            db.SaveChanges();

            return true;
        }

        public List<RecetaMedicamentoModel> GetAllRecetaMedicamentos()
        {
            return (from c in db.RecetaMedicamentoes
                    select new RecetaMedicamentoModel
                    {
                        IdRecetaMedicamento = c.IdRecetaMedicamento,
                        Receta = new RecetaModel() { IdReceta = c.IdReceta },
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        Cantidad = c.Cantidad,
                        Frecuencia = c.Frecuencia
                    }
                    ).ToList();
        }

        public RecetaMedicamentoModel GetRecetaMedicamentoById(RecetaMedicamentoModel recetaMedicamento)
        {
            return (from c in db.RecetaMedicamentoes
                    select new RecetaMedicamentoModel
                    {
                        IdRecetaMedicamento = c.IdRecetaMedicamento,
                        Receta = new RecetaModel() { IdReceta = c.IdReceta },
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        Cantidad = c.Cantidad,
                        Frecuencia = c.Frecuencia
                    }
                    ).Where(d => d.IdRecetaMedicamento == recetaMedicamento.IdRecetaMedicamento).FirstOrDefault();
        }

        public List<RecetaMedicamentoModel> GetRecetaMedicamentoByIdReceta(RecetaModel receta)
        {
            return (from c in db.RecetaMedicamentoes
                    select new RecetaMedicamentoModel
                    {
                        IdRecetaMedicamento = c.IdRecetaMedicamento,
                        Receta = new RecetaModel() { IdReceta = c.IdReceta },
                        Medicamento = new MedicamentoModel() { IdMedicamento = (int)c.IdMedicamento },
                        Cantidad = c.Cantidad,
                        Frecuencia = c.Frecuencia
                    }
                    ).Where(d => d.Receta.IdReceta == receta.IdReceta).ToList();
        }
    }
}