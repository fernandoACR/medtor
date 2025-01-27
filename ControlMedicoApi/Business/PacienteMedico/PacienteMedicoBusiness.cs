using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class PacienteMedicoBusiness : IPacienteMedicoBusiness
    {
        public readonly IPacienteMedicoRepository pacienteMedicoRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IPacienteRepository pacienteRepository;

        public PacienteMedicoBusiness(IPacienteMedicoRepository pacienteMedicoRepository, IMedicoRepository medicoRepository,
            IPacienteRepository pacienteRepository)
        {
            this.pacienteMedicoRepository = pacienteMedicoRepository;
            this.medicoRepository = medicoRepository;
            this.pacienteRepository = pacienteRepository;
        }

        public int AddPacienteMedico(PacienteMedicoModel pacienteMedico)
        {
            PacienteMedico pacienteMedicoDb = new PacienteMedico();
            pacienteMedicoDb.IdMedico = pacienteMedico.Medico.IdMedico;
            pacienteMedicoDb.IdPaciente = pacienteMedico.Paciente.IdPaciente;
            pacienteMedicoDb.IdSuscripcion = pacienteMedico.Suscripcion.IdSuscriptor;

            return pacienteMedicoRepository.AddPacienteMedico(pacienteMedicoDb);
        }

        public bool UpdatePacienteMedico(PacienteMedicoModel pacienteMedico)
        {
            PacienteMedico pacienteMedicoDb = new PacienteMedico();
            pacienteMedicoDb.IdPacienteMedico = pacienteMedico.IdPacienteMedico;
            pacienteMedicoDb.IdMedico = pacienteMedico.Medico.IdMedico;
            pacienteMedicoDb.IdPaciente = pacienteMedico.Paciente.IdPaciente;
            pacienteMedicoDb.IdSuscripcion = pacienteMedico.Suscripcion.IdSuscriptor;

            return pacienteMedicoRepository.UpdatePacienteMedico(pacienteMedicoDb);
        }

        public List<PacienteMedicoModel> GetAllPacienteMedicos()
        {
            List<PacienteMedicoModel> listPacienteMedicos = new List<PacienteMedicoModel>();
            listPacienteMedicos = pacienteMedicoRepository.GetAllPacienteMedicos();
            listPacienteMedicos.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listPacienteMedicos.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));

            return listPacienteMedicos;
        }

        public PacienteMedicoModel GetPacienteMedicoById(PacienteMedicoModel pacienteMedico)
        {
            return pacienteMedicoRepository.GetPacienteMedicoById(pacienteMedico);
        }

        public List<PacienteModel> GetPacienteByIdMedico(MedicoModel medico)
        {
            List<PacienteModel> listPaciente = new List<PacienteModel>();
            listPaciente = pacienteMedicoRepository.GetPacienteByIdMedico(medico);            

            return listPaciente;
        }
    }
}