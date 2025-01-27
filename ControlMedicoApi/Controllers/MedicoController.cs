using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ControlMedicoApi.Controllers
{
    [Authorize]
    public class MedicoController : ApiController
    {
        private IMedicoBusiness medicoBusiness;
        
        public MedicoController(IMedicoBusiness medicoBusiness)
        {
            var claims = (ClaimsIdentity)User.Identity;
            this.medicoBusiness = medicoBusiness;
        }

        [HttpPost]
        [Route("api/Medico/AddMedico")]
        public ResponseModel AddMedico(MedicoModel model)
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //model.IdSuscripcion = Convert.ToInt32(identity.Claims.Where(x=>x.Type == "IdSuscripcion").FirstOrDefault().Value);
            ResponseModel response = new ResponseModel();
            try
            {
                int idMedico = medicoBusiness.AddMedico(model);
                response.Entity = new MedicoModel() { IdMedico = idMedico };
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Medico/UpdateMedico")]
        public ResponseModel UpdateMedico(MedicoModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                medicoBusiness.UpdateMedico(model);
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Medico/GetAllMedicos")]
        public ResponseModel GetAllMedicos()
        {
            ResponseModel response = new ResponseModel();
            try
            {                
                response.List = medicoBusiness.GetAllMedicos();
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }
            
            return response;
        }

        [HttpPost]
        [Route("api/Medico/GetMedicoById")]
        public ResponseModel GetMedicoById(MedicoModel medico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = medicoBusiness.GetMedicoById(medico);
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Medico/GetMedicoByIdSuscripcion")]
        public ResponseModel GetMedicoByIdSuscripcion(MedicoModel medico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = medicoBusiness.GetMedicoByIdSuscripcion(medico);
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
