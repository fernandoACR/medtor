using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static iTextSharp.text.Font;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.XPath;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using System.Reflection;

namespace ControlMedicoApi.Business
{
    public class ReporteBusiness : IReporteBusiness
    {
        public readonly IConfiguracionReporteRepository configuracionReporteRepository;
        public readonly ITipoReporteRepository tipoReporteRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IDiagnosticoRepository diagnosticoRepository;
        public readonly IOrdenRepository ordenRepository;
        public readonly IEscolaridadRepository escolaridadRepository;
        public readonly IPatologiaRepository patologiaRepository;
        public readonly IArchivoDiagnosticoRepository archivoDiagnosticoRepository;
        public readonly IArchivoPacienteRepository archivoPacienteRepository;
        public readonly IRecetaRepository recetaRepository;
        public readonly IRecetaMedicamentoRepository recetaMedicamentoRepository;
        public readonly IMedicamentoRepository medicamentoRepository;
        public readonly ILugarNacimientoRepository lugarNacimientoRepository;
        public readonly IEstatusOrdenRepository estatusOrdenRepository;
        public readonly ICitaRepository citaRepository;
        public readonly IArchivoMedicoRepository archivoMedicoRepository;
        public readonly ITipoReporteVariableRepository tipoReporteVariableRepository;

        public ReporteBusiness(IConfiguracionReporteRepository configuracionReporteRepository, ITipoReporteRepository tipoReporteRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IDiagnosticoRepository diagnosticoRepository, IOrdenRepository ordenRepository, IEscolaridadRepository escolaridadRepository,
            IPatologiaRepository patologiaRepository, IArchivoDiagnosticoRepository archivoDiagnosticoRepository, IArchivoPacienteRepository archivoPacienteRepository, IRecetaRepository recetaRepository, IRecetaMedicamentoRepository recetaMedicamentoRepository,
            IMedicamentoRepository medicamentoRepository, ILugarNacimientoRepository lugarNacimientoRepository, IEstatusOrdenRepository estatusOrdenRepository, ICitaRepository citaRepository, IArchivoMedicoRepository archivoMedicoRepository, ITipoReporteVariableRepository tipoReporteVariableRepository)
        {
            this.configuracionReporteRepository = configuracionReporteRepository;
            this.tipoReporteRepository = tipoReporteRepository;
            this.pacienteRepository = pacienteRepository;
            this.diagnosticoRepository = diagnosticoRepository;
            this.ordenRepository = ordenRepository;
            this.medicoRepository = medicoRepository;
            this.escolaridadRepository = escolaridadRepository;
            this.patologiaRepository = patologiaRepository;
            this.archivoDiagnosticoRepository = archivoDiagnosticoRepository;
            this.archivoPacienteRepository = archivoPacienteRepository;
            this.recetaRepository = recetaRepository;
            this.recetaMedicamentoRepository = recetaMedicamentoRepository;
            this.medicamentoRepository = medicamentoRepository;
            this.lugarNacimientoRepository = lugarNacimientoRepository;
            this.estatusOrdenRepository = estatusOrdenRepository;
            this.citaRepository = citaRepository;
            this.archivoMedicoRepository = archivoMedicoRepository;
            this.tipoReporteVariableRepository = tipoReporteVariableRepository;
        }

        public MemoryStream PrintReporteByIdTipoReporteAndIdMedico(ConfiguracionReporteModel reporte)
        {
            return new MemoryStream();
        }
    }
}