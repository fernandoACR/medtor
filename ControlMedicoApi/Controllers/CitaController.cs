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
    public class CitaController : ApiController
    {
        private ICitaBusiness citaBusiness;

        public CitaController(ICitaBusiness citaBusiness)
        {
            this.citaBusiness = citaBusiness;
        }

        [HttpPost]
        [Route("api/Cita/AddCita")]
        public ResponseModel AddCita(CitaModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                int idCita = citaBusiness.AddCita(model);
                response.Entity = new CitaModel() { IdCita = idCita };
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
        [Route("api/Cita/UpdateCita")]
        public ResponseModel UpdateCita(CitaModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                citaBusiness.UpdateCita(model);
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
        [Route("api/Cita/GetAllCitas")]
        public ResponseModel GetAllCitas()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = citaBusiness.GetAllCitas();
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
        [Route("api/Cita/GetCitaById")]
        public ResponseModel GetCitaById(CitaModel cita)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = citaBusiness.GetCitaById(cita);
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
        [Route("api/Cita/GetCitasByIdMedico")]
        public ResponseModel GetCitasByIdMedico(CitaModel cita)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = citaBusiness.GetCitasByIdMedico(cita);
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
        [Route("api/Cita/DeleteCita")]
        public ResponseModel DeleteCita(CitaModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                citaBusiness.DeleteCita(model);
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
        [Route("api/Cita/GetCitasByFechaAndIdMedico")]
        public ResponseModel GetCitasByFechaAndIdMedico(CitaModel cita)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = citaBusiness.GetCitasByFechaAndIdMedico(cita);
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
        [Route("api/Cita/GetCitasByIdMedicoAndIdEstatusCita")]
        public ResponseModel GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = citaBusiness.GetCitasByIdMedicoAndIdEstatusCita(cita);
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
