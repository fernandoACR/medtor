using System;
using System.Security.Claims;
using ControlMedicoApi.Business;
using ControlMedicoApi.Controllers;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlMedicoApi.Tests.Controllers
{
    [TestClass]
    public class MedicoControllerTest
    {
        private IMedicoBusiness medicoBusiness;
        private IMedicoRepository medicoRepository;
        private IEspecialidadRepository especialidadRepository;
        private IArchivoMedicoRepository archivoMedicoRepository;
        private IConfiguracionMedicoRepository configuracionMedicoRepository;

        [TestInitialize]
        public void Initalize()
        {
            this.medicoRepository = new MedicoRepository();
            this.especialidadRepository = new EspecialidadRepository();
            this.archivoMedicoRepository = new ArchivoMedicoRepository();
            this.configuracionMedicoRepository = new ConfiguracionMedicoRepository();

            this.medicoBusiness = new MedicoBusiness(medicoRepository, especialidadRepository,archivoMedicoRepository, configuracionMedicoRepository);
        }

        [TestMethod]
        public void AddMedico()
        {
            var response = medicoBusiness.AddMedico(new MedicoModel() {
                IdMedico = 0,
                Nombre = "Teodoro Alvarez",
                Telefono = "5566998877",
                Especialidad = new EspecialidadModel() { IdEspecialidad = 1 },
                Activo = 1,
                Correo = "fernandocr26@hotmail.com",
                Suscripcion = new SuscripcionModel() { IdSuscriptor = 6 },
                CedulaProfesional = "77885566"
            });

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetAllMedicos()
        {
            var response = medicoBusiness.GetAllMedicos();

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetMedicoById()
        {
            var response = medicoBusiness.GetMedicoById(new MedicoModel() { IdMedico = 5 });

            Assert.IsNotNull(response);
        }
    }
}
