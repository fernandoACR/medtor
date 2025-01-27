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
    public class ConfiguracionMedicoController : ApiController
    {
        private IConfiguracionMedicoBusiness configuracionMedicoBusiness;

        public ConfiguracionMedicoController(IConfiguracionMedicoBusiness configuracionMedicoBusiness)
        {
            var claims = (ClaimsIdentity)User.Identity;
            this.configuracionMedicoBusiness = configuracionMedicoBusiness;
        }

        [HttpPost]
        [Route("api/ConfiguracionMedico/AddConfiguracionMedico")]
        public ResponseModel AddConfiguracionMedico(ConfiguracionMedicoModel model)
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //model.IdSuscripcion = Convert.ToInt32(identity.Claims.Where(x=>x.Type == "IdSuscripcion").FirstOrDefault().Value);
            ResponseModel response = new ResponseModel();
            try
            {
                int idConfiguracionMedico = configuracionMedicoBusiness.AddConfiguracionMedico(model);
                response.Entity = new ConfiguracionMedicoModel() { IdConfiguracionMedico = idConfiguracionMedico };
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
        [Route("api/ConfiguracionMedico/UpdateConfiguracionMedico")]
        public ResponseModel UpdateConfiguracionMedico(List<ConfiguracionMedicoModel> model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                configuracionMedicoBusiness.UpdateConfiguracionMedico(model);
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
        [Route("api/ConfiguracionMedico/GetAllConfiguracionMedicos")]
        public ResponseModel GetAllConfiguracionMedicos()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                response.List = configuracionMedicoBusiness.GetAllConfiguracionMedicos();
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
        [Route("api/ConfiguracionMedico/GetConfiguracionMedicoById")]
        public ResponseModel GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionMedico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = configuracionMedicoBusiness.GetConfiguracionMedicoById(configuracionMedico);
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
        [Route("api/ConfiguracionMedico/GetConfiguracionMedicoByIdMedico")]
        public ResponseModel GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionMedico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = configuracionMedicoBusiness.GetConfiguracionMedicoByIdMedico(configuracionMedico);
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
