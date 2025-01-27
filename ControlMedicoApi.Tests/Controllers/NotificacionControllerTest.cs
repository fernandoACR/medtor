using System;
using System.Web;
using ControlMedicoApi.Controllers;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using ControlMedicoApi.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class NotificacionControllerTest
    {
        private INotificacionBusiness notificacionBusiness;
        private IPacienteRepository pacienteRepository;
        private IMedicoRepository medicoRepository;
        private ISuscripcionRepository suscripcionRepository;
        private IClienteRepository clienteRepository;
        private ICitaRepository citaRepository;
        private INotificacionRepository notificacionRepository;
        private IUsuarioRepository usuarioRepository;

        [TestInitialize]
        public void Initalize()
        {
            this.notificacionRepository = new NotificacionRepository();
            this.citaRepository = new CitaRepository();
            this.pacienteRepository = new PacienteRepository();
            this.medicoRepository = new MedicoRepository();
            this.suscripcionRepository = new SuscripcionRepository();
            this.clienteRepository = new ClienteRepository();
            this.usuarioRepository = new UsuarioRepository();

            this.notificacionBusiness = new NotificacionBusiness(this.notificacionRepository, citaRepository, pacienteRepository, medicoRepository, suscripcionRepository, clienteRepository, usuarioRepository);   
        }

        [TestMethod]
        public void NotificarPorEmailTest()
        {
            CitaModel cita = citaRepository.GetCitaById(new CitaModel() { IdCita = 64 });

            cita.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = 1 });
            cita.Paciente.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = cita.Paciente.Medico.IdMedico });
            cita.Paciente.NombreCompleto = cita.Paciente.PrimerNombre + " " + cita.Paciente.SegundoNombre + " " + cita.Paciente.PrimerApellido + " " + cita.Paciente.SegundoApellido;
            cita.Paciente.Medico.Suscripcion = suscripcionRepository.GetSuscripcionById(new SuscripcionModel() { IdSuscriptor = cita.Paciente.Medico.Suscripcion.IdSuscriptor });
            cita.Paciente.Medico.Suscripcion.Cliente = clienteRepository.GetClienteById(new ClienteModel() { IdCliente = cita.Paciente.Medico.Suscripcion.Cliente.IdCliente });
            EmailModel emailModel = new EmailModel();
             
            emailModel.Body = null;
            emailModel.From = "dev.artortech@outlook.com";
            emailModel.Password = "C0rr30@rT0r";
            emailModel.To = "fcespedes2624@gmail.com";

            emailModel.Entity = cita;
            emailModel.TipoNotificacion = 1;

            NotificacionController notificacionController = new NotificacionController(this.notificacionBusiness);
            notificacionController.NotificarPorEmail(emailModel);
        }
    }
}
