using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class RecetaMedicamentoBusiness :  IRecetaMedicamentoBusiness
    {
        public readonly IRecetaMedicamentoRepository recetaMedicamentoRepository;
        public readonly IRecetaRepository recetaRepository;
        public readonly IMedicamentoRepository medicamentoRepository;

        public RecetaMedicamentoBusiness(IRecetaMedicamentoRepository recetaMedicamentoRepository, IRecetaRepository recetaRepository, IMedicamentoRepository medicamentoRepository)
        {
            this.recetaMedicamentoRepository = recetaMedicamentoRepository;
            this.recetaRepository = recetaRepository;
            this.medicamentoRepository = medicamentoRepository;
        }

        public int AddRecetaMedicamento(RecetaMedicamentoModel recetaMedicamento)
        {
            RecetaMedicamento recetaMedicamentoDb = new RecetaMedicamento();
            recetaMedicamentoDb.IdMedicamento = recetaMedicamento.Medicamento.IdMedicamento;
            recetaMedicamentoDb.IdReceta = recetaMedicamento.Receta.IdReceta;
            recetaMedicamentoDb.Cantidad = recetaMedicamento.Cantidad;
            recetaMedicamentoDb.Frecuencia = recetaMedicamento.Frecuencia;

            return recetaMedicamentoRepository.AddRecetaMedicamento(recetaMedicamentoDb);
        }

        public bool UpdateRecetaMedicamento(RecetaMedicamentoModel recetaMedicamento)
        {
            RecetaMedicamento recetaMedicamentoDb = new RecetaMedicamento();
            recetaMedicamentoDb.IdRecetaMedicamento = recetaMedicamento.IdRecetaMedicamento;
            recetaMedicamentoDb.IdMedicamento = recetaMedicamento.Medicamento.IdMedicamento;
            recetaMedicamentoDb.IdReceta = recetaMedicamento.Receta.IdReceta;
            recetaMedicamentoDb.Cantidad = recetaMedicamento.Cantidad;
            recetaMedicamentoDb.Frecuencia = recetaMedicamento.Frecuencia;

            return recetaMedicamentoRepository.UpdateRecetaMedicamento(recetaMedicamentoDb);
        }

        public List<RecetaMedicamentoModel> GetAllRecetaMedicamentos()
        {
            List<RecetaMedicamentoModel> listRecetaMedicamentos = new List<RecetaMedicamentoModel>();
            listRecetaMedicamentos = recetaMedicamentoRepository.GetAllRecetaMedicamentos();
            listRecetaMedicamentos.ForEach(x => x.Receta = recetaRepository.GetRecetaById(new RecetaModel() { IdReceta = x.Receta.IdReceta }));
            listRecetaMedicamentos.ForEach(x => x.Medicamento = medicamentoRepository.GetMedicamentoById(new MedicamentoModel() { IdMedicamento = x.Medicamento.IdMedicamento }));

            return listRecetaMedicamentos;
        }

        public RecetaMedicamentoModel GetRecetaMedicamentoById(RecetaMedicamentoModel recetaMedicamento)
        {
            return recetaMedicamentoRepository.GetRecetaMedicamentoById(recetaMedicamento);
        }
    }
}