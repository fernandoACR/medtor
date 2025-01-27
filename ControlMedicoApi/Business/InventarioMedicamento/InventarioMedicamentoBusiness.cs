using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class InventarioMedicamentoBusiness :  IInventarioMedicamentoBusiness
    {
        public readonly IInventarioMedicamentoRepository recetaMedicamentoRepository;
        public readonly IMedicamentoRepository medicamentoRepository;

        public InventarioMedicamentoBusiness(IInventarioMedicamentoRepository recetaMedicamentoRepository, IMedicamentoRepository medicamentoRepository)
        {
            this.recetaMedicamentoRepository = recetaMedicamentoRepository;
            this.medicamentoRepository = medicamentoRepository;
        }

        public int AddInventarioMedicamento(InventarioMedicamentoModel recetaMedicamento)
        {
            InventarioMedicamento recetaMedicamentoDb = new InventarioMedicamento();
            recetaMedicamentoDb.IdMedicamento = recetaMedicamento.Medicamento.IdMedicamento;
            recetaMedicamentoDb.Codigo = recetaMedicamento.Codigo;
            recetaMedicamentoDb.FechaCreacion = DateTime.Now;
            recetaMedicamentoDb.FechaVencimiento = recetaMedicamento.FechaVencimiento;

            return recetaMedicamentoRepository.AddInventarioMedicamento(recetaMedicamentoDb);
        }

        public bool UpdateInventarioMedicamento(InventarioMedicamentoModel recetaMedicamento)
        {
            InventarioMedicamento recetaMedicamentoDb = new InventarioMedicamento();
            recetaMedicamentoDb.IdInventarioMedicamento = recetaMedicamento.IdInventarioMedicamento;
            recetaMedicamentoDb.IdMedicamento = recetaMedicamento.Medicamento.IdMedicamento;
            recetaMedicamentoDb.Codigo = recetaMedicamento.Codigo;
            recetaMedicamentoDb.FechaCreacion = DateTime.Now;
            recetaMedicamentoDb.FechaVencimiento = recetaMedicamento.FechaVencimiento;

            return recetaMedicamentoRepository.UpdateInventarioMedicamento(recetaMedicamentoDb);
        }

        public List<InventarioMedicamentoModel> GetAllInventarioMedicamentos()
        {
            List<InventarioMedicamentoModel> listInventarioMedicamentos = new List<InventarioMedicamentoModel>();
            listInventarioMedicamentos = recetaMedicamentoRepository.GetAllInventarioMedicamentos();
            listInventarioMedicamentos.ForEach(x => x.Medicamento = medicamentoRepository.GetMedicamentoById(new MedicamentoModel() { IdMedicamento = x.Medicamento.IdMedicamento }));

            return listInventarioMedicamentos;
        }

        public InventarioMedicamentoModel GetInventarioMedicamentoById(InventarioMedicamentoModel recetaMedicamento)
        {
            return recetaMedicamentoRepository.GetInventarioMedicamentoById(recetaMedicamento);
        }

        public List<InventarioMedicamentoModel> GetInventarioMedicamentoByIdMedicamento(MedicamentoModel medicamento)
        {
            return recetaMedicamentoRepository.GetInventarioMedicamentoByIdMedicamento(medicamento);
        }
    }
}