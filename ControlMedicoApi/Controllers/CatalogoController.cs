using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using static ControlMedicoApi.Models.UtlilityModel;
using System.Web.Script.Serialization;

namespace ControlEspecialidadApi.Controllers
{
    [Authorize]
    public class CatalogoController : ApiController
    {
        private IEspecialidadBusiness especialidadBusiness;
        private IEspecimenBusiness especimenBusiness;
        private IEstatusSuscripcionBusiness estatusSuscripcionBusiness;
        private IEstatusCitaBusiness estatusCitaBusiness;
        private IEscolaridadBusiness escolaridadBusiness;
        private IPatologiaBusiness patologiaBusiness;
        private IMedicamentoBusiness medicamentoBusiness;
        private ITipoCitaBusiness tipoCitaBusiness;
        private IOcupacionBusiness ocupacionBusiness;
        private ITipoArchivoBusiness tipoArchivoBusiness;
        private ILugarNacimientoBusiness lugarNacimientoBusiness;

        public CatalogoController(IEspecialidadBusiness especialidadBusiness, IEspecimenBusiness especimenBusiness, IEstatusSuscripcionBusiness estatusSuscripcionBusiness, 
            IEstatusCitaBusiness estatusCitaBusiness, IEscolaridadBusiness escolaridadBusiness, IPatologiaBusiness patologiaBusiness, IMedicamentoBusiness medicamentoBusiness,
            ITipoCitaBusiness tipoCitaBusiness, IOcupacionBusiness ocupacionBusiness, ITipoArchivoBusiness tipoArchivoBusiness, ILugarNacimientoBusiness lugarNacimientoBusiness)
        {
            this.especialidadBusiness = especialidadBusiness;
            this.especimenBusiness = especimenBusiness;
            this.estatusSuscripcionBusiness = estatusSuscripcionBusiness;
            this.estatusCitaBusiness = estatusCitaBusiness;
            this.escolaridadBusiness = escolaridadBusiness;
            this.patologiaBusiness = patologiaBusiness;
            this.medicamentoBusiness = medicamentoBusiness;
            this.tipoCitaBusiness = tipoCitaBusiness;
            this.ocupacionBusiness = ocupacionBusiness;
            this.tipoArchivoBusiness = tipoArchivoBusiness;
            this.lugarNacimientoBusiness = lugarNacimientoBusiness;
        }

        #region Especialidad

        [HttpPost]
        [Route("api/Especialidad/AddEspecialidad")]
        public HttpResponseMessage AddEspecialidad(EspecialidadModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                especialidadBusiness.AddEspecialidad(model);
                response.Response = true;
                
                httpResponse.Content = new StringContent(new JavaScriptSerializer().Serialize(response));
                httpResponse.StatusCode = HttpStatusCode.OK;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);

                httpResponse.StatusCode = HttpStatusCode.BadRequest;
                httpResponse.ReasonPhrase = ex.Message;
                httpResponse.Content = new StringContent(new JavaScriptSerializer().Serialize(response));
            }

            return httpResponse;
        }

        [HttpPost]
        [Route("api/Especialidad/UpdateEspecialidad")]
        public HttpResponseMessage UpdateEspecialidad(EspecialidadModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                especialidadBusiness.UpdateEspecialidad(model);
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

        [HttpPost]
        [Route("api/Especialidad/GetEspecialidadById")]
        public HttpResponseMessage GetEspecialidadById(EspecialidadModel especialidad)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = especialidadBusiness.GetEspecialidadById(especialidad);
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

        [HttpGet]
        [Route("api/Especialidad/GetAllEspecialidades")]
        public HttpResponseMessage GetAllEspecialidades()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = especialidadBusiness.GetAllEspecialidades();
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

        [HttpPost]
        [Route("api/Especialidad/GetEspecialidadesByActivo")]
        public HttpResponseMessage GetEspecialidadesByActivo(EspecialidadModel especialidad)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = especialidadBusiness.GetEspecialidadesByActivo(especialidad);
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
        #endregion

        #region Especimen

        [HttpPost]
        [Route("api/Especimen/AddEspecimen")]
        public HttpResponseMessage AddEspecimen(EspecimenModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                especimenBusiness.AddEspecimen(model);
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

        [HttpPost]
        [Route("api/Especimen/UpdateEspecimen")]
        public HttpResponseMessage UpdateEspecimen(EspecimenModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                especimenBusiness.UpdateEspecimen(model);
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

        [HttpPost]
        [Route("api/Especimen/GetEspecimenById")]
        public HttpResponseMessage GetEspecimenById(EspecimenModel especimen)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = especimenBusiness.GetEspecimenById(especimen);
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

        [HttpGet]
        [Route("api/Especimen/GetAllEspecimenes")]
        public HttpResponseMessage GetAllEspecimenes()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = especimenBusiness.GetAllEspecimenes();
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

        [HttpPost]
        [Route("api/Especimen/GetEspecimenByIdMedico")]
        public HttpResponseMessage GetEspecimenByIdMedico(EspecimenModel especimen)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = especimenBusiness.GetEspecimenByIdMedico(especimen);
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

        [HttpPost]
        [Route("api/Especimen/GetEspecimenesByIdMedicoAndActivo")]
        public HttpResponseMessage GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = especimenBusiness.GetEspecimenesByIdMedicoAndActivo(especimen);
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

        #endregion

        #region EstatusSuscripcion

        [HttpPost]
        [Route("api/EstatusSuscripcion/AddEstatusSuscripcion")]
        public HttpResponseMessage AddEstatusSuscripcion(EstatusSuscripcionModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                estatusSuscripcionBusiness.AddEstatusSuscripcion(model);
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

        [HttpPost]
        [Route("api/EstatusSuscripcion/UpdateEstatusSuscripcion")]
        public HttpResponseMessage UpdateEstatusSuscripcion(EstatusSuscripcionModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                estatusSuscripcionBusiness.UpdateEstatusSuscripcion(model);
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

        [HttpPost]
        [Route("api/EstatusSuscripcion/GetEstatusSuscripcionById")]
        public HttpResponseMessage GetEstatusSuscripcionById(EstatusSuscripcionModel estatusSuscripcion)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = estatusSuscripcionBusiness.GetEstatusSuscripcionById(estatusSuscripcion);
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

        [HttpGet]
        [Route("api/EstatusSuscripcion/GetAllEstatusSuscripciones")]
        public HttpResponseMessage GetAllEstatusSuscripciones()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = estatusSuscripcionBusiness.GetAllEstatusSuscripciones();
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

        #endregion

        #region EstatusCita

        [HttpPost]
        [Route("api/EstatusCita/AddEstatusCita")]
        public HttpResponseMessage AddEstatusCita(EstatusCitaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                estatusCitaBusiness.AddEstatusCita(model);
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

        [HttpPost]
        [Route("api/EstatusCita/UpdateEstatusCita")]
        public HttpResponseMessage UpdateEstatusCita(EstatusCitaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                estatusCitaBusiness.UpdateEstatusCita(model);
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

        [HttpPost]
        [Route("api/EstatusCita/GetEstatusCitaById")]
        public HttpResponseMessage GetEstatusCitaById(EstatusCitaModel estatusCita)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = estatusCitaBusiness.GetEstatusCitaById(estatusCita);
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

        [HttpGet]
        [Route("api/EstatusCita/GetAllEstatusCitas")]
        public HttpResponseMessage GetAllEstatusCitas()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = estatusCitaBusiness.GetAllEstatusCitas();
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

        #endregion

        #region Escolaridad

        [HttpPost]
        [Route("api/Escolaridad/AddEscolaridad")]
        public HttpResponseMessage AddEscolaridad(EscolaridadModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                escolaridadBusiness.AddEscolaridad(model);
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

        [HttpPost]
        [Route("api/Escolaridad/UpdateEscolaridad")]
        public HttpResponseMessage UpdateEscolaridad(EscolaridadModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                escolaridadBusiness.UpdateEscolaridad(model);
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

        [HttpPost]
        [Route("api/Escolaridad/GetEscolaridadById")]
        public HttpResponseMessage GetEscolaridadById(EscolaridadModel escolaridad)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = escolaridadBusiness.GetEscolaridadById(escolaridad);
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

        [HttpGet]
        [Route("api/Escolaridad/GetAllEscolaridades")]
        public HttpResponseMessage GetAllEscolaridades()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = escolaridadBusiness.GetAllEscolaridades();
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

        #endregion

        #region Patologia

        [HttpPost]
        [Route("api/Patologia/AddPatologia")]
        public HttpResponseMessage AddPatologia(PatologiaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                patologiaBusiness.AddPatologia(model);
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

        [HttpPost]
        [Route("api/Patologia/UpdatePatologia")]
        public HttpResponseMessage UpdatePatologia(PatologiaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                patologiaBusiness.UpdatePatologia(model);
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

        [HttpPost]
        [Route("api/Patologia/GetPatologiaById")]
        public HttpResponseMessage GetPatologiaById(PatologiaModel patologia)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = patologiaBusiness.GetPatologiaById(patologia);
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

        [HttpGet]
        [Route("api/Patologia/GetAllPatologias")]
        public HttpResponseMessage GetAllPatologias()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = patologiaBusiness.GetAllPatologias();
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

        [HttpPost]
        [Route("api/Patologia/GetPatologiaByIdMedico")]
        public HttpResponseMessage GetPatologiaByIdMedico(PatologiaModel patologia)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = patologiaBusiness.GetPatologiaByIdMedico(patologia);
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

        [HttpPost]
        [Route("api/Patologia/GetPatologiaByIdMedicoAndActivo")]
        public HttpResponseMessage GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = patologiaBusiness.GetPatologiaByIdMedicoAndActivo(patologia);
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

        #endregion

        #region Medicamento

        [HttpPost]
        [Route("api/Medicamento/AddMedicamento")]
        public HttpResponseMessage AddMedicamento(MedicamentoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                medicamentoBusiness.AddMedicamento(model);
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

        [HttpPost]
        [Route("api/Medicamento/UpdateMedicamento")]
        public HttpResponseMessage UpdateMedicamento(MedicamentoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                medicamentoBusiness.UpdateMedicamento(model);
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

        [HttpPost]
        [Route("api/Medicamento/GetMedicamentoById")]
        public HttpResponseMessage GetMedicamentoById(MedicamentoModel medicamento)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = medicamentoBusiness.GetMedicamentoById(medicamento);
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

        [HttpGet]
        [Route("api/Medicamento/GetAllMedicamentos")]
        public HttpResponseMessage GetAllMedicamentos()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = medicamentoBusiness.GetAllMedicamentos();
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

        [HttpPost]
        [Route("api/Medicamento/GetMedicamentoByIdMedico")]
        public HttpResponseMessage GetMedicamentoByIdMedico(MedicamentoModel medicamento)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = medicamentoBusiness.GetMedicamentoByIdMedico(medicamento);
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

        [HttpPost]
        [Route("api/Medicamento/GetMedicamentosByIdMedicoAndActivo")]
        public HttpResponseMessage GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = medicamentoBusiness.GetMedicamentosByIdMedicoAndActivo(medicamento);
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

        #endregion

        #region TipoCita

        [HttpPost]
        [Route("api/TipoCita/AddTipoCita")]
        public HttpResponseMessage AddTipoCita(TipoCitaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                tipoCitaBusiness.AddTipoCita(model);
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

        [HttpPost]
        [Route("api/TipoCita/UpdateTipoCita")]
        public HttpResponseMessage UpdateTipoCita(TipoCitaModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                tipoCitaBusiness.UpdateTipoCita(model);
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

        [HttpPost]
        [Route("api/TipoCita/GetTipoCitaById")]
        public HttpResponseMessage GetTipoCitaById(TipoCitaModel tipoCita)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = tipoCitaBusiness.GetTipoCitaById(tipoCita);
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

        [HttpGet]
        [Route("api/TipoCita/GetAllTipoCitas")]
        public HttpResponseMessage GetAllTipoCitas()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = tipoCitaBusiness.GetAllTipoCitas();
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

        #endregion

        #region EstatusOrden

        [HttpGet]
        [Route("api/EstatusOrden/GetAllEstatusOrden")]
        public HttpResponseMessage GetAllEstatusOrdens()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                List<object> listaEstatusOrden = new List<object>();

                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.ENTO, Descripcion = "Entregada a Origen" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.REC, Descripcion = "Recibido" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.PRO, Descripcion = "En proceso" });
                listaEstatusOrden.Add(new { IdEstatusOrden = (int)EstatusOrdenEnum.ENTR, Descripcion = "Entregada a Receptor" });

                response.List = listaEstatusOrden;
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

        #endregion

        #region Ocupacion

        [HttpPost]
        [Route("api/Ocupacion/AddOcupacion")]
        public HttpResponseMessage AddOcupacion(OcupacionModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                ocupacionBusiness.AddOcupacion(model);
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

        [HttpPost]
        [Route("api/Ocupacion/UpdateOcupacion")]
        public HttpResponseMessage UpdateOcupacion(OcupacionModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                ocupacionBusiness.UpdateOcupacion(model);
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

        [HttpPost]
        [Route("api/Ocupacion/GetOcupacionById")]
        public HttpResponseMessage GetOcupacionById(OcupacionModel ocupacion)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = ocupacionBusiness.GetOcupacionById(ocupacion);
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

        [HttpGet]
        [Route("api/Ocupacion/GetAllOcupacions")]
        public HttpResponseMessage GetAllOcupacions()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = ocupacionBusiness.GetAllOcupacions();
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

        #endregion

        #region TipoArchivo
        [HttpPost]
        [Route("api/TipoArchivo/AddTipoArchivo")]
        public HttpResponseMessage AddTipoArchivo(TipoArchivoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                tipoArchivoBusiness.AddTipoArchivo(model);
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

        [HttpPost]
        [Route("api/TipoArchivo/UpdateTipoArchivo")]
        public HttpResponseMessage UpdateTipoArchivo(TipoArchivoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                tipoArchivoBusiness.UpdateTipoArchivo(model);
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

        [HttpPost]
        [Route("api/TipoArchivo/GetTipoArchivoById")]
        public HttpResponseMessage GetTipoArchivoById(TipoArchivoModel tipoArchivo)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = tipoArchivoBusiness.GetTipoArchivoById(tipoArchivo);
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

        [HttpGet]
        [Route("api/TipoArchivo/GetAllTipoArchivos")]
        public HttpResponseMessage GetAllTipoArchivos()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = tipoArchivoBusiness.GetAllTipoArchivos();
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
        #endregion

        #region LugarNacimiento

        [HttpPost]
        [Route("api/LugarNacimiento/AddLugarNacimiento")]
        public HttpResponseMessage AddLugarNacimiento(LugarNacimientoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                lugarNacimientoBusiness.AddLugarNacimiento(model);
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

        [HttpPost]
        [Route("api/LugarNacimiento/UpdateLugarNacimiento")]
        public HttpResponseMessage UpdateLugarNacimiento(LugarNacimientoModel model)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                lugarNacimientoBusiness.UpdateLugarNacimiento(model);
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

        [HttpPost]
        [Route("api/LugarNacimiento/GetLugarNacimientoById")]
        public HttpResponseMessage GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = lugarNacimientoBusiness.GetLugarNacimientoById(lugarNacimiento);
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

        [HttpGet]
        [Route("api/LugarNacimiento/GetAllLugarNacimientoes")]
        public HttpResponseMessage GetAllLugarNacimientoes()
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = lugarNacimientoBusiness.GetAllLugarNacimientoes();
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

        #endregion
    }
}
