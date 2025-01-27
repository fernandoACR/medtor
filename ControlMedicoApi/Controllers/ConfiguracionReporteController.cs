using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ControlMedicoApi.Controllers
{
    [Authorize]
    public class ConfiguracionReporteController : ApiController
    {
        private IConfiguracionReporteBusiness configuracionReporteBusiness;

        public ConfiguracionReporteController(IConfiguracionReporteBusiness configuracionReporteBusiness)
        {
            var claims = (ClaimsIdentity)User.Identity;
            this.configuracionReporteBusiness = configuracionReporteBusiness;
        }

        [HttpPost]
        [Route("api/ConfiguracionReporte/AddConfiguracionReporte")]
        public ResponseModel AddConfiguracionReporte(ConfiguracionReporteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                int idConfiguracionReporte = configuracionReporteBusiness.AddConfiguracionReporte(model);
                response.Entity = new ConfiguracionReporteModel() { IdConfiguracionReporte = idConfiguracionReporte };
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
        [Route("api/ConfiguracionReporte/UpdateConfiguracionReporte")]
        public ResponseModel UpdateConfiguracionReporte(ConfiguracionReporteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                configuracionReporteBusiness.UpdateConfiguracionReporte(model);
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
        [Route("api/ConfiguracionReporte/GetAllConfiguracionReportes")]
        public ResponseModel GetAllConfiguracionReportes()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = configuracionReporteBusiness.GetAllConfiguracionReportes();
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
        [Route("api/ConfiguracionReporte/GetConfiguracionReporteById")]
        public ResponseModel GetConfiguracionReporteById(ConfiguracionReporteModel configuracionReporte)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = configuracionReporteBusiness.GetConfiguracionReporteById(configuracionReporte);
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
        [Route("api/ConfiguracionReporte/GetConfiguracionReporteByIdMedico")]
        public HttpResponseMessage GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionReporte)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = configuracionReporteBusiness.GetConfiguracionReporteByIdMedico(configuracionReporte);
                response.Response = true;

                httpResponse.Content = new StringContent(new JavaScriptSerializer().Serialize(response));
                httpResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);

                httpResponse.StatusCode = HttpStatusCode.BadRequest;
                httpResponse.ReasonPhrase = ex.Message;
                httpResponse.Content = new StringContent(new JavaScriptSerializer().Serialize(response));
            }

            return httpResponse;
        }
    }
}
