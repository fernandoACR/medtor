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
    public class DiagnosticoController : ApiController
    {
        private IDiagnosticoBusiness diagnosticoBusiness;

        public DiagnosticoController(IDiagnosticoBusiness diagnosticoBusiness)
        {
            this.diagnosticoBusiness = diagnosticoBusiness;
        }

        [HttpPost]
        [Route("api/Diagnostico/AddDiagnostico")]
        public ResponseModel AddDiagnostico(DiagnosticoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                int idDiagnostico = diagnosticoBusiness.AddDiagnostico(model);
                response.Entity = new DiagnosticoModel() { IdDiagnostico = idDiagnostico };                
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
        [Route("api/Diagnostico/UpdateDiagnostico")]
        public ResponseModel UpdateDiagnostico(DiagnosticoModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                diagnosticoBusiness.UpdateDiagnostico(model);
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
        [Route("api/Diagnostico/GetAllDiagnosticos")]
        public ResponseModel GetAllDiagnosticos()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = diagnosticoBusiness.GetAllDiagnosticos();
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
        [Route("api/Diagnostico/GetDiagnosticoById")]
        public ResponseModel GetDiagnosticoById(DiagnosticoModel diagnostico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = diagnosticoBusiness.GetDiagnosticoById(diagnostico);
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
        [Route("api/Diagnostico/GetDiagnosticoByIdMedico")]
        public ResponseModel GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = diagnosticoBusiness.GetDiagnosticoByIdMedico(diagnostico);
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
        [Route("api/Diagnostico/GetDiagnosticoByIdPaciente")]
        public ResponseModel GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = diagnosticoBusiness.GetDiagnosticoByIdPaciente(diagnostico);
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
