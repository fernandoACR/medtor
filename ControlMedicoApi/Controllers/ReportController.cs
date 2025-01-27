using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ControlMedicoApi.Controllers
{
    public class ReportController : ApiController
    {
        private IExpedienteBusiness expedienteBusiness;
        private IRecetaBusiness recetaBusiness;
        private ICitaBusiness citaBusiness;
        private IOrdenBusiness ordenBusiness;
        private IReporteBusiness reporteBusiness;
        public ReportController(IExpedienteBusiness expedienteBusiness, IRecetaBusiness recetaBusiness, ICitaBusiness citaBusiness, IOrdenBusiness ordenBusiness, IReporteBusiness reporteBusiness)
        {
            this.expedienteBusiness = expedienteBusiness;
            this.recetaBusiness = recetaBusiness;
            this.citaBusiness = citaBusiness;
            this.ordenBusiness = ordenBusiness;
            this.reporteBusiness = reporteBusiness;
        }

        #region Paciente

        [HttpGet]
        [Route("api/report/GetExpedienteByIdPaciente")]
        public HttpResponseMessage GetExpedienteByIdPaciente(int idPaciente)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            byte[] buffer = new byte[0];

            try
            {
                buffer = expedienteBusiness.GetExpedienteByIdPaciente(new PacienteModel() {IdPaciente = idPaciente }).ToArray();
                var contentLength = buffer.Length;

                var statuscode = HttpStatusCode.OK;
                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + "Expediente_" + idPaciente + ".pdf", out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }

            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }
        #endregion

        #region Receta

        [HttpGet]
        [Route("api/report/PrintRecetaByIdReceta")]
        public HttpResponseMessage PrintRecetaByIdReceta(int idReceta)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            byte[] buffer = new byte[0];

            try
            {
                buffer = recetaBusiness.PrintRecetaByIdReceta(new RecetaModel() { IdReceta = idReceta }).ToArray();
                var contentLength = buffer.Length;

                var statuscode = HttpStatusCode.OK;
                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + "Expediente_" + idReceta.ToString() + ".pdf", out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }

            }
            catch (Exception ex)
            {                
                return response;
            }

            return response;
        }

        #endregion

        #region Cita

        [HttpGet]
        [Route("api/report/PrintCitasByFecha")]
        public HttpResponseMessage PrintCitasByFecha(string fecha)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            byte[] buffer = new byte[0];

            try
            {
                buffer = citaBusiness.PrintCitasByFecha(Convert.ToDateTime(fecha)).ToArray();
                var contentLength = buffer.Length;

                var statuscode = HttpStatusCode.OK;
                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + "Citas_" + fecha + ".pdf", out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }

            }
            catch (Exception ex)
            {
                response.ReasonPhrase = ex.Message;
                return response;
            }

            return response;
        }

        #endregion

        #region Orden

        [HttpGet]
        [Route("api/report/PrintOrdenByIdOrden")]
        public HttpResponseMessage PrintOrdenByIdOrden(int idOrden)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
            byte[] buffer = new byte[0];

            try
            {
                buffer = ordenBusiness.PrintOrdenByIdOrden(new OrdenModel() { IdOrden = idOrden }).ToArray();
                var contentLength = buffer.Length;

                var statuscode = HttpStatusCode.OK;
                response = Request.CreateResponse(statuscode);
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;
                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + "Orden_" + idOrden.ToString() + ".pdf", out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }

            }
            catch (Exception ex)
            {
                return response;
            }

            return response;
        }

        #endregion
    }
}
