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
    public class SuscripcionController : ApiController
    {
        private ISuscripcionBusiness suscripcionBusiness;

        public SuscripcionController(ISuscripcionBusiness suscripcionBusiness)
        {
            this.suscripcionBusiness = suscripcionBusiness;
        }

        [HttpPost]
        [Route("api/Suscripcion/AddSuscripcion")]
        public ResponseModel AddSuscripcion(SuscripcionModel model)
        {

            ResponseModel response = new ResponseModel();

            try
            {
                suscripcionBusiness.AddSuscripcion(model);
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
        [Route("api/Suscripcion/UpdateSuscripcion")]
        public ResponseModel UpdateSuscripcion(SuscripcionModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                suscripcionBusiness.UpdateSuscripcion(model);
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
        [Route("api/Suscripcion/GetAllSuscripcions")]
        public ResponseModel GetAllSuscripcions()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = suscripcionBusiness.GetAllSuscripcions();
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
        [Route("api/Suscripcion/GetSuscripcionById")]
        public ResponseModel GetSuscripcionById(SuscripcionModel suscripcion)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = suscripcionBusiness.GetSuscripcionById(suscripcion);
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
