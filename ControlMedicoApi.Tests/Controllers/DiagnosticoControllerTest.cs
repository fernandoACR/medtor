using System;
using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class DiagnosticoControllerTest
    {
        private IDiagnosticoBusiness diagnosticoBusiness;
        private IDiagnosticoRepository diagnosticoRepository;
        private IPacienteRepository pacienteRepository;
        private IMedicoRepository medicoRepository;
        private IArchivoDiagnosticoRepository archivoDiagnosticoRepository;
        private ICitaRepository citaRepository;

        [TestInitialize]
        public void Initalize()
        {
            this.diagnosticoRepository = new DiagnosticoRepository();
            this.pacienteRepository = new PacienteRepository();
            this.medicoRepository = new MedicoRepository();
            this.archivoDiagnosticoRepository = new ArchivoDiagnosticoRepository();
            this.citaRepository = new CitaRepository();

            this.diagnosticoBusiness = new DiagnosticoBusiness(diagnosticoRepository, pacienteRepository, medicoRepository, archivoDiagnosticoRepository, citaRepository);
        }

        [TestMethod]
        public void GetDiagnosticoByIdPaciente()
        {
            DiagnosticoModel diagnostico = new DiagnosticoModel()
            {
                Paciente = new PacienteModel() { IdPaciente = 27 }
            };

            var response = diagnosticoBusiness.GetDiagnosticoByIdPaciente(diagnostico);

            Assert.IsTrue(response.Count > 0);
        }
    }
}
