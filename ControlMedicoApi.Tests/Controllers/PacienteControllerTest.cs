using System;
using System.Web.Http;
using ControlMedicoApi.Business;
using ControlMedicoApi.Controllers;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class PacienteControllerTest : ApiController
    {
        private IPacienteBusiness pacienteBusiness;
        private IPacienteRepository pacienteRepository;
        private IEscolaridadRepository escolaridadRepository;
        private IPatologiaRepository patologiaRepository;
        private IPacienteMedicoRepository pacienteMedicoRepository;
        private IMedicoRepository medicoRepository;
        private IMedicamentoRepository medicamentoRepository;
        private IOcupacionRepository ocupacionRepository;
        private IArchivoPacienteRepository archivoPacienteRepository;
        private ILugarNacimientoRepository lugarNacimientoRepository;

        [TestInitialize]
        public void Initalize()
        {
            this.pacienteRepository = new PacienteRepository();
            this.escolaridadRepository = new EscolaridadRepository();
            this.patologiaRepository = new PatologiaRepository();
            this.pacienteMedicoRepository = new PacienteMedicoRepository();
            this.medicoRepository = new MedicoRepository();
            this.medicamentoRepository = new MedicamentoRepository();
            this.ocupacionRepository = new OcupacionRepository();
            this.archivoPacienteRepository = new ArchivoPacienteRepository();
            this.lugarNacimientoRepository = new LugarNacimientoRepository();

            this.pacienteBusiness = new PacienteBusiness(pacienteRepository, escolaridadRepository, patologiaRepository, pacienteMedicoRepository,
            medicoRepository, medicamentoRepository, ocupacionRepository, archivoPacienteRepository, lugarNacimientoRepository) ;
        }

        [TestMethod]
        public void GetPacienteMedicoByIdMedico()
        {
            PacienteModel paciente = new PacienteModel()
            {
                Medico = new MedicoModel() { IdMedico = 5 }
            };

            var response = pacienteBusiness.GetPacienteByIdMedico(paciente);

            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void GetPacienteById()
        {
            PacienteModel paciente = new PacienteModel()
            {
                IdPaciente = 23
            };

            var response = pacienteBusiness.GetPacienteById(paciente);

            Assert.IsTrue(response != null);
        }
    }
}
