using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class MedicamentoBusiness : IMedicamentoBusiness
    {
        public readonly IMedicamentoRepository medicamentoRepository;

        public MedicamentoBusiness(IMedicamentoRepository medicamentoRepository)
        {
            this.medicamentoRepository = medicamentoRepository;
        }

        public int AddMedicamento(MedicamentoModel medicamento)
        {
            Medicamento medicamentoDb = new Medicamento();
            medicamentoDb.Descripcion = medicamento.Descripcion;
            medicamentoDb.IdMedico = medicamento.Medico.IdMedico;
            medicamentoDb.Activo = 1;

            return medicamentoRepository.AddMedicamento(medicamentoDb);
        }

        public bool UpdateMedicamento(MedicamentoModel medicamento)
        {
            Medicamento medicamentoDb = new Medicamento();
            medicamentoDb.IdMedicamento = medicamento.IdMedicamento;
            medicamentoDb.IdMedico = medicamento.Medico.IdMedico;
            medicamentoDb.Descripcion = medicamento.Descripcion;
            medicamentoDb.Activo = medicamento.Activo;

            return medicamentoRepository.UpdateMedicamento(medicamentoDb);
        }

        public List<MedicamentoModel> GetAllMedicamentos()
        {
            return medicamentoRepository.GetAllMedicamentos();
        }

        public MedicamentoModel GetMedicamentoById(MedicamentoModel medicamento)
        {
            return medicamentoRepository.GetMedicamentoById(medicamento);
        }

        public List<MedicamentoModel> GetMedicamentoByIdMedico(MedicamentoModel medicamento)
        {
            return medicamentoRepository.GetMedicamentoByIdMedico(medicamento);
        }

        public List<MedicamentoModel> GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento)
        {
            return medicamentoRepository.GetMedicamentosByIdMedicoAndActivo(medicamento);
        }
    }
}