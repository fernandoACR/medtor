using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using HtmlAgilityPack;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfSharp.Pdf.IO;
using Pechkin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using TuesPechkin;
using static ControlMedicoApi.Models.UtlilityModel;
using static iTextSharp.text.Font;

namespace ControlMedicoApi.Business
{
    public class ExpedienteBusiness : IExpedienteBusiness
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
        public List<string> variablesReemplazadas = new List<string>();

        public ExpedienteBusiness(IConfiguracionReporteRepository configuracionReporteRepository, ITipoReporteRepository tipoReporteRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IDiagnosticoRepository diagnosticoRepository, IOrdenRepository ordenRepository, IEscolaridadRepository escolaridadRepository,
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

        public MemoryStream GetExpedienteByIdPaciente(PacienteModel paciente)
        {
            string html = "";
            string htmlFiles = "</br></br>";

            paciente = pacienteRepository.GetPacienteById(paciente);
            paciente.NombreCompleto = paciente.PrimerNombre + " " + paciente.SegundoNombre + " " + paciente.PrimerApellido + " " + paciente.SegundoApellido;
            paciente.Escolaridad = escolaridadRepository.GetEscolaridadById(paciente.Escolaridad);
            paciente.Patologia = patologiaRepository.GetPatologiaById(paciente.Patologia);
            paciente.Foto = archivoPacienteRepository.GetArchivoPacienteByIdPaciente(new ArchivoPacienteModel() { Paciente = new PacienteModel() { IdPaciente = paciente.IdPaciente } });
            paciente.LugarNacimiento = lugarNacimientoRepository.GetLugarNacimientoById(paciente.LugarNacimiento);
            List<DiagnosticoModel> listDiagnostico = diagnosticoRepository.GetDiagnosticoByIdPaciente(new DiagnosticoModel() { Paciente = paciente });
            List<RecetaModel> listReceta = new List<RecetaModel>();
            List<OrdenModel> listOrden = new List<OrdenModel>();
            List<CitaModel> listCita = new List<CitaModel>();

            foreach (DiagnosticoModel diagnostico in listDiagnostico)
            {
                diagnostico.ArchivosAdjuntos = archivoDiagnosticoRepository.GetArchivoDiagnosticoByIdDiagnostico(new ArchivoDiagnosticoModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } });
                listReceta.AddRange(recetaRepository.GetRecetaByIdDiagnostico(new RecetaModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } }));
                listOrden.AddRange(ordenRepository.GetOrdenByIdDiagnostico(new OrdenModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } }));
                listCita.Add(citaRepository.GetCitaById(new CitaModel() { IdCita = diagnostico.Cita.IdCita }));
            }

            List<ConfiguracionReporteModel> listConfiguracionReporte = configuracionReporteRepository.GetConfiguracionReporteByIdMedico(new ConfiguracionReporteModel() { TipoReporte = new TipoReporteModel() { IdTipoReporte = (int)TipoReporteEnum.ExpedienteP1 }, Medico = paciente.Medico });

            ConfiguracionReporteModel configuracionReporte = listConfiguracionReporte.Where(con => con.TipoReporte.IdTipoReporte == (int)TipoReporteEnum.ExpedienteP1).FirstOrDefault();
            configuracionReporte.TipoReporte.Variables = tipoReporteVariableRepository.GetTipoReporteVariableByIdTipoReporte(new TipoReporteVariableModel() { TipoReporte = new TipoReporteModel() { IdTipoReporte = configuracionReporte.TipoReporte.IdTipoReporte } });

            paciente.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = paciente.Medico.IdMedico });
            paciente.Medico.Logo = archivoMedicoRepository.GetArchivoMedicoByIdMedico(new ArchivoMedicoModel() { Medico = new MedicoModel() { IdMedico = paciente.Medico.IdMedico } });

            ReplaceReportVariables(paciente, configuracionReporte);

            ReplaceReportVariables(paciente.Foto != null ? paciente.Foto : new ArchivoPacienteModel(), configuracionReporte);

            ReplaceReportVariables(paciente.Medico.Logo != null ? paciente.Medico.Logo : new ArchivoMedicoModel(), configuracionReporte);           

            MemoryStream memoryStream = new MemoryStream();

            html += configuracionReporte.Html;    

            #region Expediente Clinico

            if (listDiagnostico.Count > 0)
            {
                string alergias = "";
                List<DiagnosticoModel> listaAlergias = listDiagnostico.Where(x => x.Alergias != "").ToList();
                if (listaAlergias.Count > 0)
                {
                    for (int k = 0; k <= listaAlergias.Count - 1; k++)
                    {
                        alergias += listaAlergias[k].Alergias;

                        if (k < listaAlergias.Count - 1)
                        {
                            alergias += " ,";
                        }                        
                    }

                    listaAlergias[0].Alergias = alergias;
                }
            }

            configuracionReporte = listConfiguracionReporte.Where(con => con.TipoReporte.IdTipoReporte == (int)TipoReporteEnum.ExpedienteP2).FirstOrDefault();

            configuracionReporte.TipoReporte.Variables = tipoReporteVariableRepository.GetTipoReporteVariableByIdTipoReporte(new TipoReporteVariableModel() { TipoReporte = new TipoReporteModel() { IdTipoReporte = configuracionReporte.TipoReporte.IdTipoReporte } });

            foreach (DiagnosticoModel diagnostico in listDiagnostico)
            {
                ConfiguracionReporteModel configuracionReporteModel = new ConfiguracionReporteModel()
                {
                    Html = configuracionReporte.Html,
                    TipoReporte = configuracionReporte.TipoReporte
                };

                CitaModel cita = listCita.Where(x => x.IdCita == diagnostico.Cita.IdCita).FirstOrDefault();

                ReplaceReportVariables(cita, configuracionReporteModel);

                ReplaceReportVariables(diagnostico, configuracionReporteModel);

                List<RecetaModel> recetas = listReceta.Where(x => x != null).Where(v => v.Diagnostico.IdDiagnostico == diagnostico.IdDiagnostico).ToList();

                if (recetas.Count() > 0)
                {
                    foreach (RecetaModel receta in recetas)
                    {
                        ReplaceReportVariables(receta, configuracionReporteModel);

                        List<RecetaMedicamentoModel> medicamentos = recetaMedicamentoRepository.GetRecetaMedicamentoByIdReceta(receta);
                        List<int> listaIndices = new List<int>();
                        var doc = new HtmlDocument();
                        doc.LoadHtml(configuracionReporteModel.Html);

                        var recetaHtmlTable = doc.DocumentNode.SelectNodes("//table[@id='recetaTable']").FirstOrDefault();
                        HtmlNode newRecetaHtmlTable = recetaHtmlTable;
                        newRecetaHtmlTable.Name = recetaHtmlTable.Name;
                        var recetaHtmlTableFirstRow = doc.DocumentNode.SelectNodes("//table[@id='recetaTable']//tr")[1];

                        DataTable table = new DataTable("recetaTable");

                        for(int ig = 0; ig<=medicamentos.Count - 1; ig++)
                        {
                            if (ig > 0)
                            {
                                doc = new HtmlDocument();
                                doc.LoadHtml(configuracionReporteModel.Html);
                                recetaHtmlTable = doc.DocumentNode.SelectNodes("//table[@id='recetaTable']").FirstOrDefault();
                                var tr = "<tr>" + recetaHtmlTableFirstRow.InnerHtml.Replace("\r\n", "").Replace(" ", "").Trim() + "</tr>";
                                var node = HtmlNode.CreateNode(tr);
                                recetaHtmlTable.AppendChild(node);
                                configuracionReporteModel.Html = doc.DocumentNode.InnerHtml;                                
                            }
                            
                            medicamentos[ig].Medicamento = medicamentoRepository.GetMedicamentoById(medicamentos[ig].Medicamento);
                            ReplaceReportVariables(medicamentos[ig], configuracionReporteModel);
                            ReplaceReportVariables(medicamentos[ig].Medicamento, configuracionReporteModel);

                            variablesReemplazadas = new List<string>();
                        };
                    };
                }
                else
                {
                    ReplaceReportVariables(new RecetaModel(), configuracionReporteModel);
                };

                List<OrdenModel> ordenes = listOrden.Where(x => x != null).Where(v => v.Diagnostico.IdDiagnostico == diagnostico.IdDiagnostico).ToList();

                if (ordenes.Count() > 0)
                {
                    foreach (OrdenModel orden in ordenes)
                    {
                        orden.Estatus = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = orden.Estatus.IdEstatusOrden });

                        var nombreRecepcion = "";

                        if (orden.MedicoRecepcion != null)
                        {
                            orden.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = orden.MedicoRecepcion.IdMedico });
                            nombreRecepcion = orden.MedicoRecepcion.Nombre;
                        }
                        else
                        {
                            nombreRecepcion = orden.PersonaRecepcion;
                        }

                        ReplaceReportVariables(orden, configuracionReporteModel);
                    }
                }
                else
                {
                    ReplaceReportVariables(new OrdenModel(), configuracionReporteModel);
                }

                if (diagnostico.ArchivosAdjuntos != null)
                {                   

                    if (diagnostico.ArchivosAdjuntos.Count > 0)
                    {
                        foreach (ArchivoDiagnosticoModel archivo in diagnostico.ArchivosAdjuntos)
                        {                           
                            htmlFiles += "<IMG style = 'width:100%;height=100%;margin-left: auto; margin-right: auto;display:block' src='data:image/jpeg;base64," + archivo.Archivo + "' />";
                            htmlFiles += "<p align='right'>" + archivo.Descripcion + archivo.ExtensionArchivo + "</p>";
                            htmlFiles += "</br></br>";
                        }
                    }
                }

                html += configuracionReporteModel.Html;
                variablesReemplazadas = new List<string>();
            }

            html += htmlFiles;

            #endregion

            var document = new HtmlToPdfDocument
            {
                GlobalSettings = { ProduceOutline = true, DocumentTitle = "Expediente_" + paciente.PrimerNombre + paciente.PrimerApellido, PaperSize = PaperKind.Letter, Margins = { All = 1.375, Unit = Unit.Centimeters } },
                Objects = { new ObjectSettings { HtmlText = html } }
            };                       
            
            byte[] pdfContent = converter.Convert(document);

            memoryStream = new MemoryStream(pdfContent);
            memoryStream.Position = 0;
            memoryStream.Close();

            return memoryStream;

        }

        [Obsolete]
        public MemoryStream GetExpedienteByIdPacienteOld(PacienteModel paciente)
        {
            paciente = pacienteRepository.GetPacienteById(paciente);
            paciente.Escolaridad = escolaridadRepository.GetEscolaridadById(paciente.Escolaridad);
            paciente.Patologia = patologiaRepository.GetPatologiaById(paciente.Patologia);
            paciente.Foto = archivoPacienteRepository.GetArchivoPacienteByIdPaciente(new ArchivoPacienteModel() { Paciente = new PacienteModel() { IdPaciente = paciente.IdPaciente } });
            paciente.LugarNacimiento = lugarNacimientoRepository.GetLugarNacimientoById(paciente.LugarNacimiento);
            List<DiagnosticoModel> listDiagnostico = diagnosticoRepository.GetDiagnosticoByIdPaciente(new DiagnosticoModel() { Paciente = paciente });
            List<RecetaModel> listReceta = new List<RecetaModel>();
            List<OrdenModel> listOrden = new List<OrdenModel>();
            List<CitaModel> listCita = new List<CitaModel>();

            foreach (DiagnosticoModel diagnostico in listDiagnostico)
            {
                diagnostico.ArchivosAdjuntos = archivoDiagnosticoRepository.GetArchivoDiagnosticoByIdDiagnostico(new ArchivoDiagnosticoModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } });
                listReceta.AddRange(recetaRepository.GetRecetaByIdDiagnostico(new RecetaModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } }));
                listOrden.AddRange(ordenRepository.GetOrdenByIdDiagnostico(new OrdenModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = diagnostico.IdDiagnostico } }));
                listCita.Add(citaRepository.GetCitaById(new CitaModel() { IdCita = diagnostico.Cita.IdCita }));
            }

            var pageSize = new Rectangle(PageSize.LETTER);           

            Document doc = new Document(pageSize);
            string imagepath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Resources/Images");
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();

            var titleFont = FontFactory.GetFont("Arial", 18, BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, NORMAL);

            paciente.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = paciente.Medico.IdMedico });
            paciente.Medico.Logo = archivoMedicoRepository.GetArchivoMedicoByIdMedico(new ArchivoMedicoModel() { Medico = new MedicoModel() { IdMedico = paciente.Medico.IdMedico } });

            if (paciente.Medico.Logo != null)
            {
                MemoryStream mStream = new MemoryStream(paciente.Medico.Logo.ArchivoByte);
                Image logo = Image.GetInstance(mStream);
                logo.Alignment = Element.ALIGN_RIGHT;
                logo.ScaleAbsolute(150f, 100f);
                logo.SetAbsolutePosition(450, 680);
                doc.Add(logo);
            }

            #region Expediente Clinico

            PdfPCell cell;
            Paragraph paragraph = new Paragraph("Expediente Clinico", titleFont);
            paragraph.SpacingAfter = 15;
            doc.Add(paragraph);

            doc.Add(new Paragraph("Información del Paciente", subTitleFont));
            PdfPTable  tableContent = new PdfPTable(2);

            tableContent.HorizontalAlignment = 0;
            tableContent.SpacingBefore = 20;
            tableContent.SpacingAfter = 10;
            tableContent.DefaultCell.Border = 0;
            tableContent.SetWidthPercentage(new float[2] { 250f, 350f }, PageSize.LETTER);

            tableContent.AddCell(new Phrase("Nombre:", boldTableFont));
            tableContent.AddCell(paciente.PrimerNombre + " " + paciente.SegundoNombre + " " + paciente.PrimerApellido + " " + paciente.SegundoApellido);
            if (paciente.Foto != null)
            {
                MemoryStream mStream = new MemoryStream(paciente.Foto.ArchivoByte);
                Image img = Image.GetInstance(mStream);
                img.Alignment = Element.ALIGN_RIGHT;
                img.ScaleAbsolute(100f, 100f);
                img.SetAbsolutePosition(430, 565);
                doc.Add(img);
            }

            tableContent.AddCell(new Phrase("Teléfono:", boldTableFont));
            tableContent.AddCell(paciente.Telefono == "" ? " N/D" : paciente.Telefono);

            tableContent.AddCell(new Phrase("Estado Civil:", boldTableFont));
            tableContent.AddCell(paciente.EstadoCivil == null || paciente.EstadoCivil == "" ? " N/D" : paciente.EstadoCivil);

            tableContent.AddCell(new Phrase("Escolaridad:", boldTableFont));
            tableContent.AddCell(paciente.Escolaridad != null ? (paciente.Escolaridad.Descripcion == null ? " N/D" : paciente.Escolaridad.Descripcion) : "Sin datos de escolaridad");

            tableContent.AddCell(new Phrase("Fecha de nacimiento:", boldTableFont));
            tableContent.AddCell(paciente.FechaNacimiento == null ? " N/D" : ((DateTime)paciente.FechaNacimiento).Date.ToString("dd/MM/yyyy"));

            tableContent.AddCell(new Phrase("Lugar de nacimiento:", boldTableFont));
            tableContent.AddCell(paciente.LugarNacimiento == null ? " N/D" : paciente.LugarNacimiento.Descripcion);

            tableContent.AddCell(new Phrase("Número de Identificación:", boldTableFont));
            tableContent.AddCell(paciente.Identificacion == null || paciente.Identificacion == "" ? " N/D" : paciente.Identificacion);

            doc.Add(tableContent);

            doc.Add(new Paragraph("Información Patologica", subTitleFont));
            tableContent = new PdfPTable(2);
            tableContent.HorizontalAlignment = 0;
            tableContent.SpacingBefore = 20;
            tableContent.SpacingAfter = 10;
            tableContent.DefaultCell.Border = 0;
            tableContent.SetWidthPercentage(new float[2] { 250f, 350f }, PageSize.LETTER);

            tableContent.AddCell(new Phrase("Patologia:", boldTableFont));
            tableContent.AddCell(paciente.Patologia == null ? " N/D" : paciente.Patologia.Descripcion);

            tableContent.AddCell(new Phrase("Familiar de Contacto:", boldTableFont));
            tableContent.AddCell(paciente.NombreFamiliar == "" ? " N/D" : paciente.NombreFamiliar);

            tableContent.AddCell(new Phrase("Teléfono Familiar:", boldTableFont));
            tableContent.AddCell(paciente.TelefonoFamiliar == "" ? " N/D" : paciente.TelefonoFamiliar);

            if(listDiagnostico.Count > 0)
            {
                string alergias = "";
                List<DiagnosticoModel> listaAlergias = listDiagnostico.Where(x => x.Alergias != "").ToList();
                if(listaAlergias.Count > 0)
                {
                    for(int k = 0; k <= listaAlergias.Count-1; k++)
                    {
                        alergias += listaAlergias[k].Alergias;
                        if(k < listaAlergias.Count - 1)
                        {
                            alergias += " ,";
                        }
                    }
                }

                tableContent.AddCell(new Phrase("Alergias:", boldTableFont));
                tableContent.AddCell(alergias);
            }

            doc.Add(tableContent);

            doc.Add(new Paragraph("Historial de Consultas", subTitleFont));            
            
            foreach (DiagnosticoModel diagnostico in listDiagnostico)
            {
                CitaModel cita = listCita.Where(x => x.IdCita == diagnostico.Cita.IdCita).FirstOrDefault();

                doc.NewPage();
                tableContent = new PdfPTable(8);
                tableContent.HorizontalAlignment = 0;
                tableContent.SpacingBefore = 20;
                tableContent.SpacingAfter = 10;
                tableContent.DefaultCell.Border = 0;
                tableContent.SetWidthPercentage(new float[8] { 50f, 75f, 50f, 50f, 50f, 50f, 95f, 145f }, PageSize.LETTER);

                Phrase phrase = new Phrase("Cita:");
                PdfPCell subTitleCell = new PdfPCell(phrase);
                subTitleCell.Colspan = 8;
                subTitleCell.Border = 0;
                tableContent.AddCell(subTitleCell);

                tableContent.AddCell(new Phrase("Fecha:", boldTableFont));
                tableContent.AddCell(cita.FechaCitaDesde.Date.ToString("dd/MM/yyyy"));

                tableContent.AddCell(new Phrase("Desde:", boldTableFont));
                tableContent.AddCell(cita.FechaCitaDesde.ToString("HH:mm"));

                tableContent.AddCell(new Phrase("Hasta:", boldTableFont));
                tableContent.AddCell(cita.FechaCitaHasta.ToString("HH:mm"));

                tableContent.AddCell(new Phrase("Comentarios:", boldTableFont));
                tableContent.AddCell(cita.Comentarios);

                doc.Add(tableContent);

                tableContent = new PdfPTable(8);
                tableContent.HorizontalAlignment = 0;
                tableContent.SpacingBefore = 20;
                tableContent.SpacingAfter = 10;
                tableContent.DefaultCell.Border = 0;
                tableContent.SetWidthPercentage(new float[8] { 55f, 100f, 55f, 150f, 50f, 50f, 55f, 50f }, PageSize.LETTER);

                phrase = new Phrase("Diagnostico:");
                subTitleCell = new PdfPCell(phrase);
                subTitleCell.Colspan = 8;
                subTitleCell.Border = 0;
                tableContent.AddCell(subTitleCell);

                tableContent.AddCell(new Phrase("Fecha:", boldTableFont));
                tableContent.AddCell(diagnostico.FechaCreacion.Date.ToString("dd/MM/yyyy"));

                tableContent.AddCell(new Phrase("Motivo:", boldTableFont));
                tableContent.AddCell(diagnostico.Descripcion);

                tableContent.AddCell(new Phrase("Peso:", boldTableFont));
                tableContent.AddCell(diagnostico.Peso.ToString());

                tableContent.AddCell(new Phrase("Altura:", boldTableFont));
                tableContent.AddCell(diagnostico.Altura.ToString());

                doc.Add(tableContent);

                List<RecetaModel> recetas = listReceta.Where(x => x != null).Where(v => v.Diagnostico.IdDiagnostico == diagnostico.IdDiagnostico).ToList();

                if (recetas.Count() > 0)
                {
                    foreach(RecetaModel receta in recetas)
                    {
                        List<RecetaMedicamentoModel> medicamentos = recetaMedicamentoRepository.GetRecetaMedicamentoByIdReceta(receta);

                        tableContent = new PdfPTable(6);
                        tableContent.HorizontalAlignment = 0;
                        tableContent.SpacingBefore = 20;
                        tableContent.SpacingAfter = 10;
                        tableContent.DefaultCell.Border = 0;
                        tableContent.SetWidthPercentage(new float[6] { 100f,100f,100f,30f, 100f, 170f}, PageSize.LETTER);

                        phrase = new Phrase("Receta:");
                        subTitleCell = new PdfPCell(phrase);
                        subTitleCell.Colspan = 6;
                        subTitleCell.Border = 0;
                        tableContent.AddCell(subTitleCell);

                        foreach (RecetaMedicamentoModel medicamento in medicamentos)
                        {  
                            medicamento.Medicamento = medicamentoRepository.GetMedicamentoById(medicamento.Medicamento);

                            tableContent.AddCell(new Phrase("Medicamento:", boldTableFont));
                            tableContent.AddCell(medicamento.Medicamento.Descripcion);

                            tableContent.AddCell(new Phrase("Cantidad:", boldTableFont));
                            tableContent.AddCell(medicamento.Cantidad.ToString());

                            tableContent.AddCell(new Phrase("Frecuencia:", boldTableFont));
                            tableContent.AddCell(medicamento.Frecuencia);
                        }

                        doc.Add(tableContent);
                    }
                }

                List<OrdenModel> ordenes = listOrden.Where(x => x != null).Where(v => v.Diagnostico.IdDiagnostico == diagnostico.IdDiagnostico).ToList();

                if (ordenes.Count() > 0)
                {
                    foreach (OrdenModel orden in ordenes)
                    {
                        orden.Estatus = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = orden.Estatus.IdEstatusOrden });

                        tableContent = new PdfPTable(8);
                        tableContent.HorizontalAlignment = 0;
                        tableContent.SpacingBefore = 20;
                        tableContent.SpacingAfter = 10;
                        tableContent.DefaultCell.Border = 0;
                        tableContent.SetWidthPercentage(new float[8] { 49f, 73f, 68f, 130f, 70f, 80f, 60f, 80f }, PageSize.LETTER);

                        phrase = new Phrase("Orden:");
                        subTitleCell = new PdfPCell(phrase);
                        subTitleCell.Colspan = 8;
                        subTitleCell.Border = 0;
                        tableContent.AddCell(subTitleCell);

                        tableContent.AddCell(new Phrase("Fecha:", boldTableFont));
                        tableContent.AddCell(orden.FechaCreacion.Date.ToString("dd/MM/yyyy"));

                        tableContent.AddCell(new Phrase("Motivo:", boldTableFont));
                        tableContent.AddCell(orden.Observaciones);

                        var nombreRecepcion = "";

                        if(orden.MedicoRecepcion != null)
                        {
                            orden.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = orden.MedicoRecepcion.IdMedico });
                            nombreRecepcion = orden.MedicoRecepcion.Nombre;
                        }
                        else
                        {
                            nombreRecepcion = orden.PersonaRecepcion;
                        }

                        tableContent.AddCell(new Phrase("Recibido Por:", boldTableFont));
                        tableContent.AddCell(nombreRecepcion);

                        tableContent.AddCell(new Phrase("Estatus:", boldTableFont));
                        tableContent.AddCell(orden.Estatus.Descripcion);

                        doc.Add(tableContent);
                    }
                }

                if (diagnostico.ArchivosAdjuntos != null)
                {
                    if (diagnostico.ArchivosAdjuntos.Count > 0)
                    {
                        tableContent = new PdfPTable(2);
                        tableContent.HorizontalAlignment = 0;
                        tableContent.SpacingBefore = 20;
                        tableContent.SpacingAfter = 10;
                        tableContent.DefaultCell.Border = 0;
                        //tableContent.SetWidths(new int[] { 4, 4, 4 });
                        tableContent.SetWidthPercentage(new float[2] { 100f, 500f }, PageSize.LETTER);

                        phrase = new Phrase("Archivos Adjuntos:");
                        subTitleCell = new PdfPCell(phrase);
                        subTitleCell.Colspan = 2;
                        subTitleCell.Border = 0;
                        tableContent.AddCell(subTitleCell);
                        foreach (ArchivoDiagnosticoModel archivo in diagnostico.ArchivosAdjuntos)
                        {
                            if (archivo.ExtensionArchivo == ".jpg" || archivo.ExtensionArchivo == ".png" || archivo.ExtensionArchivo == ".jfif")
                            {
                                tableContent.AddCell(new Phrase(archivo.Descripcion + archivo.ExtensionArchivo, boldTableFont));
                                
                                MemoryStream mStream = new MemoryStream(archivo.ArchivoByte);
                                Image img = Image.GetInstance(mStream);

                                if (img.Height > img.Width)
                                {
                                    //Maximum height is 800 pixels.
                                    float percentage = 0.0f;
                                    percentage = 60 / img.Height;
                                    img.ScalePercent(percentage * 100);
                                }
                                else
                                {
                                    //Maximum width is 600 pixels.
                                    float percentage = 0.0f;
                                    percentage = 270 / img.Width;
                                    img.ScalePercent(percentage * 100);
                                }

                                cell = new PdfPCell(img);
                                cell.BorderWidth = 0;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                tableContent.AddCell(cell);
                                mStream.Dispose();
                            }
                        }

                        doc.Add(tableContent);
                    }
                }
            }               
            
            #endregion
            
            writer.CloseStream = false;
            doc.Close();
            
            memoryStream.Position = 0;

            return memoryStream;
        }

        private void ReplaceReportVariables(dynamic entity, ConfiguracionReporteModel configuracionReporte)
        {
            string entityName = entity.GetType().Name;

            foreach (PropertyInfo propertyInfo in entity.GetType().GetProperties())
            {
                foreach (var config in configuracionReporte.TipoReporte.Variables.Where(con=> !variablesReemplazadas.Exists(cus => cus == con.Descripcion)))
                {
                    if (propertyInfo.Name == config.Propiedad)
                    {
                        dynamic value = propertyInfo.GetValue(entity);

                        if (value != null)
                        {
                            try
                            {
                                value = value.Descripcion;
                            }
                            catch (Exception ex)
                            {

                            }

                            if(value == null)
                            {
                                value = "N/D";
                            }

                            DateTime temp;

                            if (DateTime.TryParse(value.ToString(), out temp))
                            {
                                value = value.ToString("dd/MM/yyyy");
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            value = "N/D";
                        }

                        variablesReemplazadas.Add(config.Descripcion);
                        configuracionReporte.Html = configuracionReporte.Html.Replace(config.Descripcion, value.ToString() == "" ? "N/D" : value.ToString());
                        break;
                    }
                }
            }
        }
    }
}