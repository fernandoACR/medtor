using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControlMedicoApi.Models;
using ControlMedicoApi.Business;
using ControlMedicoApi.Repository;
using System.Web;
using System.Web.Routing;

namespace ControlMedicoApi.Controllers
{
    [Authorize]
    public class PacienteController : ApiController
    {
        private IPacienteBusiness pacienteBusiness;

        public PacienteController(IPacienteBusiness pacienteBusiness)
        {
            this.pacienteBusiness = pacienteBusiness;
        }
        
        [HttpPost]
        [Route("api/Paciente/AddPaciente")]
        public ResponseModel AddPaciente(PacienteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                pacienteBusiness.AddPaciente(model);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }
        
        [HttpPost]
        [Route("api/Paciente/UpdatePaciente")]
        public ResponseModel UpdatePaciente(PacienteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                pacienteBusiness.UpdatePaciente(model);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }
       
        [HttpGet]
        [Route("api/Paciente/GetAllPacientes")]
        public ResponseModel GetAllPacientes()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = pacienteBusiness.GetAllPacientes();
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Paciente/GetPacienteById")]
        public ResponseModel GetPacienteById(PacienteModel paciente)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = pacienteBusiness.GetPacienteById(paciente);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Paciente/GetPacienteByIdMedico")]
        public ResponseModel GetPacienteMedicoByIdMedico(PacienteModel paciente)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = pacienteBusiness.GetPacienteByIdMedico(paciente);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Paciente/DeletePaciente")]
        public ResponseModel DeletePaciente(PacienteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                pacienteBusiness.DeletePaciente(model);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }
    }
}
