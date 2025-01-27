using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Business
{
    public class CitaBusiness : ICitaBusiness
    {
        public readonly ICitaRepository citaRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IEstatusCitaRepository estatusCitaRepository;
        public readonly ITipoCitaRepository tipoCitaRepository;

        public CitaBusiness(ICitaRepository citaRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, 
            IEstatusCitaRepository estatusCitaRepository, ITipoCitaRepository tipoCitaRepository)
        {
            this.citaRepository = citaRepository;
            this.pacienteRepository = pacienteRepository;
            this.medicoRepository = medicoRepository;
            this.estatusCitaRepository = estatusCitaRepository;
            this.tipoCitaRepository = tipoCitaRepository;
        }

        public int AddCita(CitaModel cita)
        {
            //Obtener datos de estatus
            EstatusCitaModel estatusCitaModel = this.estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel { IdEstatusCita = (int)UtlilityModel.EstatusCitaEnum.POR });
            
            Cita citaDb = new Cita();
            citaDb.IdMedico = cita.Medico.IdMedico;

            if (cita.Paciente != null)
            {
                citaDb.IdPaciente = cita.Paciente.IdPaciente;
            }

            citaDb.FechaCitaDesde = cita.FechaCitaDesde;
            citaDb.FechaCreacion = DateTime.Now;
            citaDb.Comentarios = cita.Comentarios;
            citaDb.Titulo = cita.Titulo;
            citaDb.Estatus = cita.EstatusCita == null ? (int)EstatusCitaEnum.AGE : cita.EstatusCita.IdEstatusCita;
            citaDb.FechaCitaHasta = cita.FechaCitaHasta;
            //citaDb.EstatusCita = new EstatusCita {IdEstatusCita = estatusCitaModel.IdEstatusCita, Clave = estatusCitaModel.Clave, Descripcion = estatusCitaModel.Descripcion };
            citaDb.IdTipoCita = cita.TipoCita.IdTipoCita;

            return citaRepository.AddCita(citaDb);
        }

        public bool UpdateCita(CitaModel cita)
        {
            //Obtener datos de estatus
            EstatusCitaModel estatusCitaModel = this.estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel { IdEstatusCita = cita.EstatusCita.IdEstatusCita });

            Cita citaDb = new Cita();
            citaDb.IdCita = cita.IdCita;
            citaDb.IdMedico = cita.Medico.IdMedico;

            if (cita.Paciente.IdPaciente > 0)
            {
                citaDb.IdPaciente = cita.Paciente.IdPaciente;
            }
            
            citaDb.FechaCitaDesde = cita.FechaCitaDesde;
            citaDb.FechaModificacion = DateTime.Now;
            citaDb.Comentarios = cita.Comentarios;
            citaDb.Titulo = cita.Titulo;
            citaDb.Estatus = cita.EstatusCita.IdEstatusCita;
            citaDb.FechaCitaHasta = cita.FechaCitaHasta;
            citaDb.IdTipoCita = cita.TipoCita.IdTipoCita;
            //citaDb.EstatusCita = new EstatusCita { IdEstatusCita = estatusCitaModel.IdEstatusCita, Clave = estatusCitaModel.Clave, Descripcion = estatusCitaModel.Descripcion };
            return citaRepository.UpdateCita(citaDb);
        }

        public List<CitaModel> GetAllCitas()
        {
            List<CitaModel> listCitas = new List<CitaModel>();
            listCitas = citaRepository.GetAllCitas();

            listCitas.Where(x => x.Paciente.IdPaciente > 0).ToList().ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listCitas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listCitas.ForEach(x => x.TipoCita = tipoCitaRepository.GetTipoCitaById(new TipoCitaModel() { IdTipoCita = x.TipoCita.IdTipoCita }));
            listCitas.ForEach(x => x.EstatusCita = estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel() { IdEstatusCita = x.EstatusCita.IdEstatusCita }));
            listCitas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listCitas;
        }

        public CitaModel GetCitaById(CitaModel cita)
        {
            return citaRepository.GetCitaById(cita);
        }

        public List<CitaModel> GetCitasByIdMedico(CitaModel cita)
        {
            List<CitaModel> listCitas = new List<CitaModel>();
            listCitas = citaRepository.GetCitasByIdMedico(cita);

            listCitas.Where(x=> x.Paciente.IdPaciente > 0).ToList().ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listCitas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = cita.Medico.IdMedico }));
            listCitas.ForEach(x => x.TipoCita = tipoCitaRepository.GetTipoCitaById(new TipoCitaModel() { IdTipoCita = x.TipoCita.IdTipoCita }));
            listCitas.ForEach(x => x.EstatusCita = estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel() { IdEstatusCita = x.EstatusCita.IdEstatusCita }));
            listCitas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listCitas;
        }

        public void DeleteCita(CitaModel cita)
        {
            //Obtener datos de estatus
            EstatusCitaModel estatusCitaModel = this.estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel { IdEstatusCita = (int)UtlilityModel.EstatusCitaEnum.POR });

            Cita citaDb = new Cita();
            citaDb.IdCita = cita.IdCita;

            citaRepository.DeleteCita(citaDb);
        }

        public List<CitaModel> GetCitasByFechaAndIdMedico(CitaModel cita)
        {
            List<CitaModel> listCitas = new List<CitaModel>();
            listCitas = citaRepository.GetCitasByFechaAndIdMedico(cita).Where(x=>x.EstatusCita.IdEstatusCita == (int)EstatusCitaEnum.AGE).ToList();

            listCitas.Where(x => x.Paciente.IdPaciente > 0).ToList().ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listCitas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = cita.Medico.IdMedico }));
            listCitas.ForEach(x => x.TipoCita = tipoCitaRepository.GetTipoCitaById(new TipoCitaModel() { IdTipoCita = x.TipoCita.IdTipoCita }));
            listCitas.ForEach(x => x.EstatusCita = estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel() { IdEstatusCita = x.EstatusCita.IdEstatusCita }));
            
            List<PacienteModel> pacientesSinCita = new List<PacienteModel>();
            List<PacienteModel> pacientesConCita = new List<PacienteModel>();

            listCitas.ForEach(h => pacientesConCita.Add(h.Paciente));
            pacientesSinCita = pacienteRepository.GetPacienteByIdMedico(new PacienteModel() { Medico = cita.Medico });
            
            foreach(PacienteModel pacienteSinCita in pacientesSinCita)
            {
                if(!pacientesConCita.Exists(v=> v.IdPaciente == pacienteSinCita.IdPaciente))
                {
                    listCitas.Add(new CitaModel() { Paciente = pacienteSinCita });
                }
            }

            listCitas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listCitas;
        }

        public List<CitaModel> GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita)
        {
            List<CitaModel> listCitas = new List<CitaModel>();
            listCitas = citaRepository.GetCitasByIdMedicoAndIdEstatusCita(cita);

            listCitas.Where(x => x.Paciente.IdPaciente > 0).ToList().ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listCitas.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = cita.Medico.IdMedico }));
            listCitas.ForEach(x => x.TipoCita = tipoCitaRepository.GetTipoCitaById(new TipoCitaModel() { IdTipoCita = x.TipoCita.IdTipoCita }));
            listCitas.ForEach(x => x.EstatusCita = estatusCitaRepository.GetEstatusCitaById(new EstatusCitaModel() { IdEstatusCita = x.EstatusCita.IdEstatusCita }));
            listCitas.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listCitas;
        }

        #region Reportes
        public MemoryStream PrintCitasByFecha(DateTime fecha)
        {
            List<CitaModel> citas = citaRepository.GetAllCitas().Where(x=>x.FechaCitaDesde.Day == fecha.Day && x.EstatusCita.IdEstatusCita == (int)EstatusCitaEnum.AGE && x.Paciente.IdPaciente > 0).OrderBy(x=>x.FechaCitaDesde.Hour).ToList();

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

            Image pic = Image.GetInstance(imagepath + "/healt_icon.png");
            pic.SetAbsolutePosition(440, 800);
            doc.Add(pic);

            Paragraph paragraph = new Paragraph("Citas del dia " + fecha.ToString("dd/MM/yyyy"), subTitleFont);
            paragraph.SpacingAfter = 15;
            doc.Add(paragraph);

            PdfPTable tableContent = new PdfPTable(4);

            tableContent.HorizontalAlignment = 0;
            tableContent.SpacingBefore = 20;
            tableContent.SpacingAfter = 10;
            tableContent.DefaultCell.Border = 0;
            tableContent.SetWidthPercentage(new float[4] { 200f, 100f, 100f, 200f }, PageSize.LETTER);

            if (citas.Count > 0)
            {
                tableContent.AddCell(new Phrase("Paciente:", boldTableFont));
                tableContent.AddCell(new Phrase("Desde:", boldTableFont));
                tableContent.AddCell(new Phrase("Hasta:", boldTableFont));
                tableContent.AddCell(new Phrase("Comentarios:", boldTableFont));

                foreach (CitaModel cita in citas)
                {
                    cita.Paciente = pacienteRepository.GetPacienteById(cita.Paciente);
                    
                    tableContent.AddCell(cita.Paciente.PrimerNombre + " " + cita.Paciente.SegundoNombre + " " + cita.Paciente.PrimerApellido + " " + cita.Paciente.SegundoApellido);
                    
                    tableContent.AddCell(cita.FechaCitaDesde.ToShortTimeString());
                    
                    tableContent.AddCell(cita.FechaCitaHasta.ToShortTimeString());
                    
                    tableContent.AddCell(cita.Comentarios);
                }
            }

            doc.Add(tableContent);

            writer.CloseStream = false;

            doc.Close();
            memoryStream.Position = 0;
            return memoryStream;
        }

        #endregion
    }
}