using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlMedicoApi.Controllers
{
    [Authorize]
    public class PacienteMedicoController : ApiController
    {
        private IPacienteMedicoBusiness pacienteMedicoBusiness;

        public PacienteMedicoController(IPacienteMedicoBusiness pacienteMedicoBusiness)
        {
            this.pacienteMedicoBusiness = pacienteMedicoBusiness;
        }

        [HttpPost]
        [Route("api/PacienteMedico/AddPacienteMedico")]
        public ResponseModel AddPacienteMedico(PacienteMedicoModel model)
        {

            ResponseModel response = new ResponseModel();

            try
            {
                pacienteMedicoBusiness.AddPacienteMedico(model);
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
        [Route("api/PacienteMedico/UpdatePacienteMedico")]
        public ResponseModel UpdatePacienteMedico(PacienteMedicoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                pacienteMedicoBusiness.UpdatePacienteMedico(model);
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
        [Route("api/PacienteMedico/GetAllPacienteMedicos")]
        public ResponseModel GetAllPacienteMedicos()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = pacienteMedicoBusiness.GetAllPacienteMedicos();
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
        [Route("api/PacienteMedico/GetPacienteMedicoById")]
        public ResponseModel GetPacienteMedicoById(PacienteMedicoModel pacienteMedico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = pacienteMedicoBusiness.GetPacienteMedicoById(pacienteMedico);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        //[HttpPost]
        //[Route("api/PacienteMedico/GetPacienteByIdMedico")]
        //public ResponseModel GetPacienteMedicoByIdMedico(MedicoModel medico)
        //{
        //    ResponseModel response = new ResponseModel();

        //    try
        //    {
        //        response.List = pacienteMedicoBusiness.GetPacienteByIdMedico(medico);
        //        response.Response = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Response = false;
        //        response.ErrorList.Add(ex.Message);
        //    }

        //    return response;
        //}
    }
}
