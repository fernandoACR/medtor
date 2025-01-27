using System;
using ControlMedicoApi.Business;
using ControlMedicoApi.Controllers;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class ReportControllerTest
    {
        private ReportController reportController;
        private ICitaBusiness citaBusiness;
        private ICitaRepository citaRepository;
        private IPacienteRepository pacienteRepository;
        private ITipoCitaRepository tipoCitaRepository;
        private IEstatusCitaRepository estatusCitaRepository;
        private IMedicoRepository medicoRepository;

        private RecetaBusiness recetaBusiness;
        private IRecetaRepository recetaRepository;
        private IRecetaMedicamentoRepository recetaMedicamentoRepository;
        private IMedicamentoRepository medicamentoRepository;
        private IDiagnosticoRepository diagnosticoRepository;

        private ExpedienteBusiness expedienteBusiness;
        private IOrdenRepository ordenRepository;
        private IEscolaridadRepository escolaridadRepository;
        private IPatologiaRepository patologiaRepository;
        private IArchivoDiagnosticoRepository archivoDiagnosticoRepository;
        private IArchivoPacienteRepository archivoPacienteRepository;
        private ILugarNacimientoRepository lugarNacimientoRepository;
        private IEstatusOrdenRepository estatusOrdenRepository;

        private OrdenBusiness ordenBusiness;

        private ReporteBusiness reporteBusiness;
        private IConfiguracionReporteRepository configuracionReporteRepository;
        private ITipoReporteRepository tipoReporteRepository;
        private IConfiguracionMedicoRepository configuracionMedicoRepository;
        private IArchivoMedicoRepository archivoMedicoRepository;

        [TestInitialize]
        public void Initalize()
        {
            this.pacienteRepository = new PacienteRepository();
            this.citaRepository = new CitaRepository();
            this.estatusCitaRepository = new EstatusCitaRepository();
            this.tipoCitaRepository = new TipoCitaRepository();
            this.medicoRepository = new MedicoRepository();

            this.recetaRepository = new RecetaRepository();
            this.recetaMedicamentoRepository = new RecetaMedicamentoRepository();
            this.medicamentoRepository = new MedicamentoRepository();
            this.diagnosticoRepository = new DiagnosticoRepository();
            this.estatusOrdenRepository = new EstatusOrdenRepository();
            this.configuracionMedicoRepository = new ConfiguracionMedicoRepository();
            this.archivoMedicoRepository = new ArchivoMedicoRepository();
            this.configuracionReporteRepository = new ConfiguracionReporteRepository();
            this.tipoReporteRepository = new TipoReporteRepository();

            this.recetaBusiness = new RecetaBusiness(recetaRepository, pacienteRepository, medicoRepository, recetaMedicamentoRepository,medicamentoRepository,diagnosticoRepository,configuracionMedicoRepository,archivoMedicoRepository);

            this.citaBusiness = new CitaBusiness(citaRepository, pacienteRepository, medicoRepository, estatusCitaRepository,tipoCitaRepository);

            this.expedienteBusiness = new ExpedienteBusiness(pacienteRepository, medicoRepository, diagnosticoRepository, ordenRepository, escolaridadRepository,
                patologiaRepository, archivoDiagnosticoRepository, archivoPacienteRepository, recetaRepository, recetaMedicamentoRepository, medicamentoRepository,
                lugarNacimientoRepository, estatusOrdenRepository, citaRepository,archivoMedicoRepository);

            this.reporteBusiness = new ReporteBusiness(configuracionReporteRepository, tipoReporteRepository);

            this.reportController = new ReportController(this.expedienteBusiness, this.recetaBusiness, this.citaBusiness, this.ordenBusiness, this.reporteBusiness);
        }

        [TestMethod]
        public void PrintCitasByFecha()
        {
            this.reportController.PrintCitasByFecha("04/22/2019 02:04:29 p. m.");            
        }

        [TestMethod]
        public void PrintReporteByIdTipoReporteAndIdMedico()
        {
            this.reporteBusiness.PrintReporteByIdTipoReporteAndIdMedico(new ConfiguracionReporteModel() {

                IdConfiguracionReporte = 1,
                Medico = new MedicoModel() { IdMedico = 5 },
                TipoReporte = new TipoReporteModel() { IdTipoReporte = 1 }
            });
        }
    }
}
