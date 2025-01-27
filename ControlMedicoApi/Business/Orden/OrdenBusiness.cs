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
    public class OrdenBusiness : IOrdenBusiness
    {
        public readonly IOrdenRepository ordenRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IEspecimenRepository especimenRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IDiagnosticoRepository diagnosticoRepository;
        public readonly IHistoricoOrdenRepository historicoOrdenRepository;
        public readonly IEstatusOrdenRepository estatusOrdenRepository;
        public readonly IArchivoOrdenRepository archivoOrdenRepository;
        public readonly IArchivoMedicoRepository archivoMedicoRepository;

        public OrdenBusiness(IOrdenRepository ordenRepository, IPacienteRepository pacienteRepository, IEspecimenRepository especimenRepository, IMedicoRepository medicoRepository,
            IDiagnosticoRepository diagnosticoRepository, IHistoricoOrdenRepository historicoOrdenRepository, IEstatusOrdenRepository estatusOrdenRepository, IArchivoOrdenRepository archivoOrdenRepository,
            IArchivoMedicoRepository archivoMedicoRepository)
        {
            this.ordenRepository = ordenRepository;
            this.pacienteRepository = pacienteRepository;
            this.especimenRepository = especimenRepository;
            this.medicoRepository = medicoRepository;
            this.diagnosticoRepository = diagnosticoRepository;
            this.historicoOrdenRepository = historicoOrdenRepository;
            this.estatusOrdenRepository = estatusOrdenRepository;
            this.archivoOrdenRepository = archivoOrdenRepository;
            this.archivoMedicoRepository = archivoMedicoRepository;
        }

        public int AddOrden(OrdenModel orden)
        {
            Orden ordenDb = new Orden();
            ordenDb.IdDiagnostico = orden.Diagnostico.IdDiagnostico;
            ordenDb.IdMedicoEntrega = orden.MedicoEntrega.IdMedico;
            ordenDb.IdEspecimen = orden.Especimen.IdEspecimen;
            ordenDb.IdMedicoRecepcion = orden.MedicoRecepcion.IdMedico;
            ordenDb.IdPaciente = orden.Paciente.IdPaciente;
            ordenDb.Observaciones = orden.Observaciones;
            ordenDb.Pagado = orden.Pagado;
            ordenDb.Monto = orden.Monto;
            ordenDb.Estatus = (int)EstatusOrdenEnum.ENTR;
            ordenDb.Activo = 1;
            ordenDb.PersonaEntrega = orden.PersonaEntrega;
            ordenDb.PersonaRecepcion = orden.PersonaRecepcion;
            ordenDb.FechaCreacion = DateTime.Now;
            ordenDb.FechaEntregaReceptor = DateTime.Now;
            ordenDb.CorreoPersonaRecepcion = orden.CorreoPersonaRecepcion;
            ordenDb.MovilPersonaRecepcion = orden.MovilPersonaRecepcion;
            ordenDb.IdSuscripcion = orden.IdSuscripcion;

            int idOrden = ordenRepository.AddOrden(ordenDb);

            if (idOrden > 0 && orden.ArchivosAdjuntos != null)
            {
                if (orden.ArchivosAdjuntos.Count > 0)
                {
                    foreach (ArchivoOrdenModel archivo in orden.ArchivosAdjuntos)
                    {
                        archivoOrdenRepository.AddArchivoOrden(new ArchivoOrden()
                        {
                            IdArchivoOrden = 0,
                            IdOrden = idOrden,
                            IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                            Descripcion = archivo.Descripcion,
                            Codigo = Guid.NewGuid(),
                            Archivo = Convert.FromBase64String(archivo.Archivo),
                            ExtensionArchivo = archivo.ExtensionArchivo
                        });
                    }
                }
            }

            if (idOrden > 0)
            {
                historicoOrdenRepository.AddHistoricoOrden(new HistoricoOrden()
                {
                    IdOrden = idOrden,
                    IdEstatusOrden = (int)EstatusOrdenEnum.ENTR,
                    ClaveOrden = "",
                    FechaEstatus = DateTime.Now,
                    IdUsuarioModificacion = null
                });
            }

            return idOrden;
        }

        public bool UpdateOrden(OrdenModel orden)
        {
            Orden ordenDb = new Orden();
            ordenDb.IdOrden = orden.IdOrden;
            ordenDb.IdDiagnostico = orden.Diagnostico.IdDiagnostico;
            ordenDb.IdMedicoEntrega = orden.MedicoEntrega.IdMedico;
            ordenDb.IdEspecimen = orden.Especimen.IdEspecimen;
            ordenDb.IdMedicoRecepcion = orden.MedicoRecepcion.IdMedico;
            ordenDb.IdPaciente = orden.Paciente.IdPaciente;
            ordenDb.Observaciones = orden.Observaciones;
            ordenDb.Pagado = orden.Pagado;
            ordenDb.Monto = orden.Monto;
            ordenDb.Estatus = orden.Estatus.IdEstatusOrden;
            ordenDb.FechaRecepcion = orden.FechaRecepcion;
            ordenDb.Activo = orden.Activo;
            ordenDb.PersonaEntrega = orden.PersonaEntrega;
            ordenDb.PersonaRecepcion = orden.PersonaRecepcion;
            ordenDb.CorreoPersonaRecepcion = orden.CorreoPersonaRecepcion;
            ordenDb.MovilPersonaRecepcion = orden.MovilPersonaRecepcion;
            ordenDb.IdSuscripcion = orden.IdSuscripcion;
            ordenDb.FechaEntregaOrigen = orden.FechaEntregaOrigen;

            bool accion = ordenRepository.UpdateOrden(ordenDb);

            if (accion)
            {
                historicoOrdenRepository.AddHistoricoOrden(new HistoricoOrden()
                {
                    IdOrden = orden.IdOrden,
                    IdEstatusOrden = orden.Estatus.IdEstatusOrden,
                    ClaveOrden = "",
                    FechaEstatus = DateTime.Now,
                    IdUsuarioModificacion = null
                });

                List<ArchivoOrdenModel> listaArchivosTotales = archivoOrdenRepository.GetArchivoOrdenByIdOrden(new ArchivoOrdenModel() { Orden = orden });
                if (orden.ArchivosAdjuntos != null)
                {
                    //Verificar si se eliminaron archivos adjuntos                    
                    List<ArchivoOrdenModel> listaArchivosDepurados = new List<ArchivoOrdenModel>();

                    foreach (ArchivoOrdenModel archivo in listaArchivosTotales)
                    {
                        if (!orden.ArchivosAdjuntos.Exists(d => d.Codigo == archivo.Codigo && d.Codigo != Guid.Empty))
                        {
                            listaArchivosDepurados.Add(archivo);
                        }
                    }

                    //Elminar de BD los archivos eliminados
                    if (listaArchivosDepurados.Count > 0)
                    {
                        foreach (ArchivoOrdenModel archivo in listaArchivosDepurados)
                        {
                            archivoOrdenRepository.DeleteArchivoOrden(new ArchivoOrden()
                            {

                                IdArchivoOrden = archivo.IdArchivoOrden,
                                IdOrden = archivo.Orden.IdOrden,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = archivo.Codigo,
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                Activo = archivo.Activo,
                                ExtensionArchivo = archivo.ExtensionArchivo

                            });
                        }
                    }

                    //Si el valor de orden.ArchivosAdjuntos = NULL, quiere decir que se eliminaron todos los archivos adjuntos

                    //Agregamos solo los nuevos archivos, aquellos donde el Codigo sea igual a Guid.Empty, el resto no se modifican
                    if (orden.ArchivosAdjuntos.Count > 0)
                    {
                        foreach (ArchivoOrdenModel archivo in orden.ArchivosAdjuntos.Where(x => x.Codigo == Guid.Empty))
                        {
                            archivoOrdenRepository.AddArchivoOrden(new ArchivoOrden()
                            {
                                IdArchivoOrden = 0,
                                IdOrden = orden.IdOrden,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = Guid.NewGuid(),
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                ExtensionArchivo = archivo.ExtensionArchivo
                            });
                        }
                    }
                }
                else
                {
                    if (listaArchivosTotales.Count > 0)
                    {
                        foreach (ArchivoOrdenModel archivo in listaArchivosTotales)
                        {
                            archivoOrdenRepository.DeleteArchivoOrden(new ArchivoOrden()
                            {

                                IdArchivoOrden = archivo.IdArchivoOrden,
                                IdOrden = archivo.Orden.IdOrden,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = archivo.Codigo,
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                Activo = archivo.Activo,
                                ExtensionArchivo = archivo.ExtensionArchivo

                            });
                        }
                    }
                }
            }

            return accion;
        }

        public List<OrdenModel> GetAllOrdenes()
        {
            List<OrdenModel> listOrdenes = new List<OrdenModel>();
            listOrdenes = ordenRepository.GetAllOrdenes();

            listOrdenes.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listOrdenes.ForEach(x => x.MedicoEntrega = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoEntrega.IdMedico }));
            listOrdenes.ForEach(x => x.Especimen = especimenRepository.GetEspecimenById(new EspecimenModel() { IdEspecimen = x.Especimen.IdEspecimen }));
            listOrdenes.ForEach(x => x.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoRecepcion.IdMedico }));
            listOrdenes.ForEach(x => x.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = x.Diagnostico.IdDiagnostico }));
            listOrdenes.ForEach(x => x.HistoricoOrden = historicoOrdenRepository.GetHistoricoOrdensByIdOrden(new HistoricoOrdenModel() { Orden = x }));

            return listOrdenes;
        }

        public OrdenModel GetOrdenById(OrdenModel orden)
        {
            orden = ordenRepository.GetOrdenById(orden);

            orden.HistoricoOrden = historicoOrdenRepository.GetHistoricoOrdensByIdOrden(new HistoricoOrdenModel() { Orden = new OrdenModel() { IdOrden = orden.IdOrden } });
            orden.HistoricoOrden.ForEach(c => c.EstatusOrden = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = c.EstatusOrden.IdEstatusOrden }));
            orden.ArchivosAdjuntos = archivoOrdenRepository.GetArchivoOrdenByIdOrden(new ArchivoOrdenModel() { Orden = orden });

            return orden;
        }

        public List<OrdenModel> GetOrdenByIdMedicoEntrega(OrdenModel orden)
        {
            List<OrdenModel> listOrdenes = new List<OrdenModel>();
            listOrdenes = ordenRepository.GetOrdenByIdMedicoEntrega(orden);

            listOrdenes.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listOrdenes.ForEach(x => x.MedicoEntrega = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoEntrega.IdMedico }));
            listOrdenes.ForEach(x => x.Especimen = especimenRepository.GetEspecimenById(new EspecimenModel() { IdEspecimen = x.Especimen.IdEspecimen }));
            listOrdenes.ForEach(x => x.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoRecepcion.IdMedico }));
            listOrdenes.ForEach(x => x.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = x.Diagnostico.IdDiagnostico }));
            listOrdenes.ForEach(x => x.HistoricoOrden = historicoOrdenRepository.GetHistoricoOrdensByIdOrden(new HistoricoOrdenModel() { Orden = x }));
            listOrdenes.ForEach(x => x.HistoricoOrden.ForEach(c => c.EstatusOrden = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = c.EstatusOrden.IdEstatusOrden })));
            listOrdenes.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listOrdenes;
        }

        public List<OrdenModel> GetOrdenByIdMedicoRecepcion(OrdenModel orden)
        {
            List<OrdenModel> listOrdenes = new List<OrdenModel>();
            listOrdenes = ordenRepository.GetOrdenByIdMedicoRecepcion(orden);

            listOrdenes.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listOrdenes.ForEach(x => x.MedicoEntrega = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoEntrega.IdMedico }));
            listOrdenes.ForEach(x => x.Especimen = especimenRepository.GetEspecimenById(new EspecimenModel() { IdEspecimen = x.Especimen.IdEspecimen }));
            listOrdenes.ForEach(x => x.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoRecepcion.IdMedico }));
            listOrdenes.ForEach(x => x.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = x.Diagnostico.IdDiagnostico }));
            listOrdenes.ForEach(x => x.HistoricoOrden = historicoOrdenRepository.GetHistoricoOrdensByIdOrden(new HistoricoOrdenModel() { Orden = x }));
            listOrdenes.ForEach(x => x.HistoricoOrden.ForEach(c => c.EstatusOrden = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = c.EstatusOrden.IdEstatusOrden })));
            listOrdenes.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listOrdenes;
        }

        public List<OrdenModel> GetOrdenByIdDiagnostico(OrdenModel orden)
        {
            List<OrdenModel> listOrdenes = new List<OrdenModel>();
            listOrdenes = ordenRepository.GetOrdenByIdDiagnostico(orden);

            listOrdenes.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listOrdenes.ForEach(x => x.MedicoEntrega = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoEntrega.IdMedico }));
            listOrdenes.ForEach(x => x.Especimen = especimenRepository.GetEspecimenById(new EspecimenModel() { IdEspecimen = x.Especimen.IdEspecimen }));
            listOrdenes.ForEach(x => x.MedicoRecepcion = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.MedicoRecepcion.IdMedico }));
            listOrdenes.ForEach(x => x.Diagnostico = diagnosticoRepository.GetDiagnosticoById(new DiagnosticoModel() { IdDiagnostico = x.Diagnostico.IdDiagnostico }));
            listOrdenes.ForEach(x => x.HistoricoOrden = historicoOrdenRepository.GetHistoricoOrdensByIdOrden(new HistoricoOrdenModel() { Orden = x }));
            listOrdenes.ForEach(x => x.Estatus = estatusOrdenRepository.GetEstatusOrdenById(new EstatusOrdenModel() { IdEstatusOrden = x.Estatus.IdEstatusOrden }));
            listOrdenes.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listOrdenes;
        }

        public MemoryStream PrintOrdenByIdOrden(OrdenModel orden)
        {
            orden = ordenRepository.GetOrdenById(orden);

            orden.Paciente = pacienteRepository.GetPacienteById(orden.Paciente);
            orden.MedicoEntrega = medicoRepository.GetMedicoById(orden.MedicoEntrega);
            orden.MedicoRecepcion = medicoRepository.GetMedicoById(orden.MedicoRecepcion);
            orden.Especimen = especimenRepository.GetEspecimenById(orden.Especimen);

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

            orden.MedicoEntrega.Logo = archivoMedicoRepository.GetArchivoMedicoByIdMedico(new ArchivoMedicoModel() { Medico = new MedicoModel() { IdMedico = orden.MedicoEntrega.IdMedico } });

            if (orden.MedicoEntrega.Logo != null)
            {
                MemoryStream mStream = new MemoryStream(orden.MedicoEntrega.Logo.ArchivoByte);
                Image logo = Image.GetInstance(mStream);
                logo.Alignment = Element.ALIGN_RIGHT;
                logo.ScaleAbsolute(100f, 100f);
                logo.SetAbsolutePosition(483, 680);
                doc.Add(logo);
            }

            Paragraph paragraph = new Paragraph("Dr(a). " + orden.MedicoEntrega.Nombre, titleFont);
            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(new Phrase(orden.MedicoEntrega.CedulaProfesional, bodyFont));
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
            tableContent.AddCell(orden.FechaCreacion.ToString("dd/MM/yyy"));

            tableContent.AddCell(new Phrase("Paciente:", boldTableFont));
            tableContent.AddCell(orden.Paciente.PrimerNombre + " " + orden.Paciente.SegundoNombre + " " + orden.Paciente.PrimerApellido + " " + orden.Paciente.SegundoApellido);
            
            doc.Add(tableContent);

            doc.Add(new Paragraph("EXAMENES:", subTitleFont));
            paragraph = new Paragraph(orden.Observaciones);
            paragraph.SpacingBefore = 15;
            doc.Add(paragraph);

            paragraph = new Paragraph("____________________________");
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 0;
            doc.Add(paragraph);

            paragraph = new Paragraph("Firma del Médico");
            paragraph.Alignment = Element.ALIGN_CENTER;
            paragraph.SpacingAfter = 15;
            doc.Add(paragraph);

            writer.CloseStream = false;

            doc.Close();
            //Get the pointer to the beginning of the stream. 
            memoryStream.Position = 0;
            //You may use this PDF in memorystream to send as an attachment in an email
            //OR download as a PDF
            //SendEmail(memoryStream);
            return memoryStream;
        }
    }
}