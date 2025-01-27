using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using static ControlMedicoApi.Models.UtlilityModel;
using System.Web.WebPages.Razor;
using System.Web.Razor.Parser;
using System.Web.Mvc;
using ControlMedicoApi.Controllers;
using RazorEngine.Templating;
using RazorEngine;
using ControlMedicoApi.Models;
using System.Web.Configuration;
using ControlMedicoApi.Repository;

namespace ControlMedicoApi.Business
{
    public class NotificacionBusiness : INotificacionBusiness
    {
        public readonly INotificacionRepository notificacionRepository;
        public readonly ICitaRepository citaRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly ISuscripcionRepository suscripcionRepository;
        public readonly IClienteRepository clienteRepository;
        public readonly IUsuarioRepository usuarioRepository;

        public NotificacionBusiness(INotificacionRepository notificacionRepository, ICitaRepository citaRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository,
                                    ISuscripcionRepository suscripcionRepository, IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository)
        {
            this.notificacionRepository = notificacionRepository;
            this.pacienteRepository = pacienteRepository;
            this.medicoRepository = medicoRepository;
            this.suscripcionRepository = suscripcionRepository;
            this.clienteRepository = clienteRepository;
            this.usuarioRepository = usuarioRepository;
            this.citaRepository = citaRepository;
        }
        public int AddNotificacion(NotificacionModel notificacion)
        {
            Notificacion notificacionDb = new Notificacion();
            notificacionDb.IdPaciente = notificacion.Paciente.IdPaciente;
            notificacionDb.IdMedico = notificacion.Medico.IdMedico;
            notificacionDb.IdTipoNotificacion = notificacion.TipoNotificacion.IdTipoNotificacion;
            notificacionDb.Recursivo = notificacion.Recursivo;
            notificacionDb.FechaNotificacion = notificacion.FechaNotificacion;
            notificacionDb.HoraNotificacion = notificacion.HoraNotificacion;
            notificacionDb.IdCita = notificacion.Cita.IdCita;
            notificacionDb.Activo = 1;
            notificacionDb.IdMedioNotificacion = notificacion.MedioNotificacion.IdMedioNotificacion;

            int idNotificacion = notificacionRepository.AddNotificacion(notificacionDb);

            return idNotificacion;
        }

        public bool UpdateNotificacion(NotificacionModel notificacion)
        {
            Notificacion notificacionDb = new Notificacion();
            //notificacionDb.IdPaciente = notificacion.Paciente.IdPaciente;
            notificacionDb.IdMedico = notificacion.Medico.IdMedico;
            notificacionDb.IdTipoNotificacion = notificacion.TipoNotificacion.IdTipoNotificacion;
            notificacionDb.Recursivo = notificacion.Recursivo;
            notificacionDb.FechaNotificacion = notificacion.FechaNotificacion;
            notificacionDb.HoraNotificacion = notificacion.HoraNotificacion;
            notificacionDb.IdCita = notificacion.Cita.IdCita;
            notificacionDb.Activo = notificacion.Activo;
            notificacionDb.IdMedioNotificacion = notificacion.MedioNotificacion.IdMedioNotificacion;

            return notificacionRepository.UpdateNotificacion(notificacionDb);
        }

        public void EnviarNotificacionPorIdNotificacion(NotificacionModel notificacion)
        {
            notificacion = notificacionRepository.GetNotificacionById(notificacion);
            EmailModel emailModel = new EmailModel();

            if (notificacion.MedioNotificacion.IdMedioNotificacion == (int)MedioNotificacionEnum.EMAIL)
            {
                if(notificacion.TipoNotificacion.IdTipoNotificacion == (int)TipoNotificacionEnum.RecordarCita)
                {
                    CitaModel cita = citaRepository.GetCitaById(notificacion.Cita);
                    cita.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = cita.Paciente.IdPaciente });
                    cita.Paciente.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = cita.Paciente.Medico.IdMedico });
                    cita.Paciente.NombreCompleto = cita.Paciente.PrimerNombre + " " + cita.Paciente.SegundoNombre + " " + cita.Paciente.PrimerApellido + " " + cita.Paciente.SegundoApellido;
                    cita.Paciente.Medico.Suscripcion = suscripcionRepository.GetSuscripcionById(new SuscripcionModel() { IdSuscriptor = cita.Paciente.Medico.Suscripcion.IdSuscriptor });
                    cita.Paciente.Medico.Suscripcion.Cliente = clienteRepository.GetClienteById(new ClienteModel() { IdCliente = cita.Paciente.Medico.Suscripcion.Cliente.IdCliente });
                    
                    emailModel = new EmailModel()
                    {
                        From = "",
                        To = cita.Paciente.CorreoElectronico,
                        Subject = "Medtor: Notificación de Cita Agendada",
                        Entity = cita
                    };
                }

                if (notificacion.TipoNotificacion.IdTipoNotificacion == (int)TipoNotificacionEnum.NuevoMedico)
                {
                    MedicoModel medico = medicoRepository.GetMedicoById(notificacion.Medico);
                    UsuarioModel usuario = usuarioRepository.GetUsuarioByIdMedico(medico);
                    usuario.UserName = medico.Nombre;
                    usuario.PasswordHash = "000AAbb.";

                    emailModel = new EmailModel()
                    {
                        From = "",
                        To = medico.Correo,
                        Subject = "Bienvenido a MedTor",
                        Entity = usuario
                    };
                }

                NotificarPorEmail(emailModel, null, notificacion.TipoNotificacion.IdTipoNotificacion);
            }
            
        }

        public void NotificarPorEmail(EmailModel model, HttpContext context, int tipoNotificacion)
        {
            string correoEnvio = WebConfigurationManager.AppSettings["CorreoEnvioNotificaciones"];
            string claveEnvio = WebConfigurationManager.AppSettings["ClaveEnvioNotificaciones"];
            string puertoEnvio = WebConfigurationManager.AppSettings["PuertoEnvioNotificaciones"];
            string servidorEnvio = WebConfigurationManager.AppSettings["ServidorEnvioNotificaciones"];

            try
            {
                //Para ejecutar test descomentar linea 119 y comentar linea 122

                //string viewPath = Directory.GetCurrentDirectory();
                //var s = viewPath + @"\NuevoMedicoEmail.cshtml";

                string viewPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Views/EmailBody");
                if(model.Body == null)
                {
                    switch ((TipoNotificacionEnum)tipoNotificacion)
                    {
                        case TipoNotificacionEnum.NuevoCliente:
                            viewPath += "/NuevoCliente.cshtml";
                            break;
                        case TipoNotificacionEnum.NuevoUsuario:
                            viewPath += "/NuevoUsuario.cshtml";
                            break;
                        case TipoNotificacionEnum.NuevoMedico:
                            viewPath += "/NuevoMedico.cshtml";
                            break;
                        case TipoNotificacionEnum.ReciboPago:
                            viewPath += "/ReciboPago.cshtml";
                            break;
                        case TipoNotificacionEnum.RecordarCita:
                            viewPath += "/RecordarCita.cshtml";
                            break;
                    }

                    model.Body = File.ReadAllText(viewPath);
                }
                
                var htmlParsed = Engine.Razor.RunCompile(model.Body, tipoNotificacion.ToString(), null, model.Entity);
                
                MailMessage mailMsg = new MailMessage();
                // To
                mailMsg.To.Add(new MailAddress(model.To));

                // From
                mailMsg.From = new MailAddress(model.From == "" ? correoEnvio : model.From);
                mailMsg.IsBodyHtml = true;
                // Subject and multipart/alternative Body
                mailMsg.Subject = model.Subject;
                //string html = htmlParsed;
                mailMsg.Body = htmlParsed;
                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient(servidorEnvio, Convert.ToInt32(puertoEnvio));
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential credentials = new NetworkCredential(model.From == "" ? correoEnvio : model.From, (model.Password == "" || model.Password == null) ? claveEnvio : model.Password);
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }        
    }
}