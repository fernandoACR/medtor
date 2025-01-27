using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class RecetaBusiness : IRecetaBusiness
    {
        public readonly IRecetaRepository recetaRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IRecetaMedicamentoRepository recetaMedicamentoRepository;
        public readonly IMedicamentoRepository medicamentoRepository;
        public readonly IDiagnosticoRepository diagnosticoRepository;
        public readonly IConfiguracionMedicoRepository configuracionMedicoRepository;
        public readonly IArchivoMedicoRepository archivoMedicoRepository;

        public RecetaBusiness(IRecetaRepository recetaRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IRecetaMedicamentoRepository recetaMedicamentoRepository, 
            IMedicamentoRepository medicamentoRepository, IDiagnosticoRepository diagnosticoRepository, IConfiguracionMedicoRepository configuracionMedicoRepository, IArchivoMedicoRepository archivoMedicoRepository)
        {
            this.recetaRepository = recetaRepository;
            this.pacienteRepository = pacienteRepository;
            this.medicoRepository = medicoRepository;
            this.recetaMedicamentoRepository = recetaMedicamentoRepository;
            this.medicamentoRepository = medicamentoRepository;
            this.diagnosticoRepository = diagnosticoRepository;
            this.configuracionMedicoRepository = configuracionMedicoRepository;
            this.archivoMedicoRepository = archivoMedicoRepository;
        }

        public int AddReceta(RecetaModel receta)
        {
            Receta recetaDb = new Receta();
            recetaDb.IdDiagnostico = receta.Diagnostico != null ? (int?)receta.Diagnostico.IdDiagnostico : null;
            recetaDb.IdPaciente = receta.Paciente.IdPaciente;
            recetaDb.IdMedico = receta.Medico.IdMedico;
            recetaDb.Activo = 1;
            recetaDb.FechaCreacion = DateTime.Now;

            int idReceta = recetaRepository.AddReceta(recetaDb);
            if(idReceta > 0)
            {
                foreach (RecetaMedicamentoModel recetaMedicamentoModel in receta.recetaMedicamentos)
                {
                    if(recetaMedicamentoModel.Medicamento.IdMedicamento <= 0 && recetaMedicamentoModel.Medicamento.Descripcion != null)
                    {
                        if (recetaMedicamentoModel.Medicamento.Descripcion != "")
                        {
                            List<MedicamentoModel> medicamentosExistentes = new List<MedicamentoModel>();
                            medicamentosExistentes = medicamentoRepository.GetMedicamentosByIdMedicoAndActivo(new MedicamentoModel() { Medico = receta.Medico, Activo = 1 });

                            MedicamentoModel medicamentoEncontrado = medicamentosExistentes.Find(m => m.Descripcion.ToLower() == recetaMedicamentoModel.Medicamento.Descripcion.ToLower());

                            if (medicamentoEncontrado == null)
                            {
                                recetaMedicamentoModel.Medicamento.IdMedicamento = medicamentoRepository.AddMedicamento(new Medicamento()
                                {
                                    IdMedicamento = 0,
                                    IdMedico = recetaMedicamentoModel.Medicamento.Medico.IdMedico,
                                    Descripcion = recetaMedicamentoModel.Medicamento.Descripcion,
                                    Activo = 1
                                });
                            }
                            else
                            {
                                recetaMedicamentoModel.Medicamento.IdMedicamento = medicamentoEncontrado.IdMedicamento;
                            }
                        }
                    }

                    if (recetaMedicamentoModel.Medicamento.IdMedicamento > 0)
                    {
                        recetaMedicamentoRepository.AddRecetaMedicamento(new RecetaMedicamento()
                        {
                            IdReceta = idReceta,
                            IdMedicamento = recetaMedicamentoModel.Medicamento.IdMedicamento,
                            Cantidad = recetaMedicamentoModel.Cantidad,
                            Frecuencia = recetaMedicamentoModel.Frecuencia
                        });
                    }
                }                
            }

            return idReceta;
        }

        public bool UpdateReceta(RecetaModel receta)
        {
            Receta recetaDb = new Receta();
            recetaDb.IdReceta = receta.IdReceta;
            recetaDb.IdPaciente = receta.Paciente.IdPaciente;
            recetaDb.IdMedico = receta.Medico.IdMedico;
            recetaDb.IdDiagnostico = receta.Diagnostico.IdDiagnostico;
            recetaDb.FechaModificacion = DateTime.Today;
            recetaDb.Activo = receta.Activo;

            return recetaRepository.UpdateReceta(recetaDb);
        }

        public List<RecetaModel> GetAllRecetas()
        {
            List<RecetaModel> listRecetas = new List<RecetaModel>();
            listRecetas = recetaRepository.GetAllRecetas();
            listRecetas.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listRecetas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listRecetas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);
            foreach (RecetaModel receta in listRecetas)
            {
                if(receta.Diagnostico != null)
                {
                    receta.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = receta.Diagnostico.IdDiagnostico });
                }
            }

            return listRecetas;
        }

        public RecetaModel GetRecetaById(RecetaModel receta)
        {
            RecetaModel recetaDb = recetaRepository.GetRecetaById(receta);
            recetaDb.recetaMedicamentos = recetaMedicamentoRepository.GetRecetaMedicamentoByIdReceta(receta);
            return recetaDb;
        }

        public MemoryStream PrintRecetaByIdReceta(RecetaModel receta)
        {
            receta = recetaRepository.GetRecetaById(receta);
            receta.recetaMedicamentos = recetaMedicamentoRepository.GetRecetaMedicamentoByIdReceta(receta);

            receta.Paciente = pacienteRepository.GetPacienteById(receta.Paciente);
            receta.Medico = medicoRepository.GetMedicoById(receta.Medico);

            List<ConfiguracionMedicoModel> configuracionMedico = configuracionMedicoRepository.GetConfiguracionMedicoByIdMedico(new ConfiguracionMedicoModel() { Medico = receta.Medico });

            bool imprimirDatosMedico = Convert.ToBoolean(configuracionMedico.Where(x => x.Nombre == "DatosMedicoImprimReceta").FirstOrDefault().Valor);

            if (receta.Diagnostico != null)
            {
                receta.Diagnostico = diagnosticoRepository.GetDiagnosticoById(receta.Diagnostico);
            }

            var pageSize = new Rectangle(PageSize.LETTER);

            Document doc = new Document(pageSize);
            string imagepath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Resources/Images");
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();

            var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
            var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
            var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
            var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
            var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

            receta.Medico.Logo = archivoMedicoRepository.GetArchivoMedicoByIdMedico(new ArchivoMedicoModel() { Medico = new MedicoModel() { IdMedico = receta.Medico.IdMedico } });

            if (receta.Medico.Logo != null)
            {
                MemoryStream mStream = new MemoryStream(receta.Medico.Logo.ArchivoByte);
                Image logo = Image.GetInstance(mStream);
                logo.Alignment = Element.ALIGN_RIGHT;
                logo.ScaleAbsolute(100f, 100f);
                logo.SetAbsolutePosition(483, 680);
                doc.Add(logo);
            }

            #region Expediente Clinico

            Paragraph paragraph = new Paragraph("Dr(a). " + (imprimirDatosMedico ? receta.Medico.Nombre : ""), titleFont);
            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(new Phrase("Cédula Profesional: ", boldTableFont));

            if (imprimirDatosMedico)
            {
                paragraph2.Add(new Phrase(receta.Medico.CedulaProfesional, bodyFont));
            }

            paragraph.SpacingAfter = 5;
            doc.Add(paragraph);
            paragraph2.SpacingAfter = 15;
            doc.Add(paragraph2);

            //doc.Add(new Paragraph("Información del General:", subTitleFont));

            PdfPTable tableContent = new PdfPTable(2);

            tableContent.HorizontalAlignment = 0;
            tableContent.SpacingBefore = 20;
            tableContent.SpacingAfter = 10;
            tableContent.DefaultCell.Border = 0;
            tableContent.SetWidths(new int[] { 6, 9 });

            tableContent.AddCell(new Phrase("Fecha:", boldTableFont));
            tableContent.AddCell(receta.FechaCreacion.ToString("dd/MM/yyy"));

            tableContent.AddCell(new Phrase("Paciente:", boldTableFont));
            tableContent.AddCell(receta.Paciente.PrimerNombre + " " + receta.Paciente.SegundoNombre + " " + receta.Paciente.PrimerApellido + " " + receta.Paciente.SegundoApellido);

            tableContent.AddCell(new Phrase("Fecha de nacimiento:", boldTableFont));
            tableContent.AddCell(receta.Paciente.FechaNacimiento == null ? " N/D" : ((DateTime)receta.Paciente.FechaNacimiento).Date.ToString("dd/MM/yyyy"));

            if (receta.Diagnostico != null)
            {
                tableContent.AddCell(new Phrase("Peso:", boldTableFont));
                tableContent.AddCell(receta.Diagnostico.Peso.ToString());

                tableContent.AddCell(new Phrase("Altura:", boldTableFont));
                tableContent.AddCell(receta.Diagnostico.Altura.ToString());
            }            

            doc.Add(tableContent);

            doc.Add(new Paragraph("RX:", subTitleFont));
            tableContent = new PdfPTable(6);
            tableContent.HorizontalAlignment = 0;
            tableContent.SpacingBefore = 20;
            tableContent.SpacingAfter = 30;
            tableContent.DefaultCell.Border = 0;
            tableContent.SetWidths(new int[] { 8, 8, 4, 4, 8, 8 });

            if (receta.recetaMedicamentos.Count > 0)
            {
                foreach (RecetaMedicamentoModel medicamento in receta.recetaMedicamentos)
                {
                    medicamento.Medicamento = medicamentoRepository.GetMedicamentoById(medicamento.Medicamento);
                    tableContent.AddCell(new Phrase("Medicamento:", boldTableFont));
                    tableContent.AddCell(medicamento.Medicamento.Descripcion);

                    tableContent.AddCell(new Phrase("Dosis:", boldTableFont));
                    tableContent.AddCell(medicamento.Cantidad.ToString());

                    tableContent.AddCell(new Phrase("Frecuencia:", boldTableFont));
                    tableContent.AddCell(medicamento.Frecuencia.ToString());
                }
            }

            doc.Add(tableContent);

            paragraph = new Paragraph("____________________________"); 
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 0;
            doc.Add(paragraph);

            paragraph = new Paragraph("Firma del Médico");
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 15;
            doc.Add(paragraph);

            #endregion

            writer.CloseStream = false;            

            doc.Close();
            //Get the pointer to the beginning of the stream. 
            memoryStream.Position = 0;
            //You may use this PDF in memorystream to send as an attachment in an email
            //OR download as a PDF
            //SendEmail(memoryStream);
            return memoryStream;
        }

        public List<RecetaModel> GetRecetaByIdMedico(RecetaModel receta)
        {
            List<RecetaModel> listRecetas = new List<RecetaModel>();

            listRecetas = recetaRepository.GetRecetaByIdMedico(receta);
            listRecetas.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listRecetas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listRecetas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            foreach (RecetaModel recetaModel in listRecetas)
            {
                if (recetaModel.Diagnostico != null)
                {
                    recetaModel.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = recetaModel.Diagnostico.IdDiagnostico });
                }
            }

            return listRecetas;
        }
    }
}