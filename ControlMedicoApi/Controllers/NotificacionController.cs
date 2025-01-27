using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Controllers
{
    public class NotificacionController : ApiController
    {
        private INotificacionBusiness notificacionBusiness;

        public NotificacionController(INotificacionBusiness notificacionBusiness)
        {
            this.notificacionBusiness = notificacionBusiness;
        }

        [HttpPost]
        [Route("api/Notificacion/AddNotificacion")]
        public ResponseModel AddNotificacion(NotificacionModel model)
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //model.IdSuscripcion = Convert.ToInt32(identity.Claims.Where(x=>x.Type == "IdSuscripcion").FirstOrDefault().Value);
            ResponseModel response = new ResponseModel();
            try
            {
                int idNotificacion = notificacionBusiness.AddNotificacion(model);
                response.Entity = new NotificacionModel() { IdNotificacion = idNotificacion };
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
        [Route("api/Notificacion/UpdateNotificacion")]
        public ResponseModel UpdateNotificacion(NotificacionModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                notificacionBusiness.UpdateNotificacion(model);
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
        [Route("api/Notificacion/NotificarPorEmail")]
        public ResponseModel NotificarPorEmail(EmailModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                notificacionBusiness.NotificarPorEmail(model, HttpContext.Current, model.TipoNotificacion);
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
        [Route("api/Notificacion/EnviarNotificacionPorIdNotificacion")]
        public ResponseModel EnviarNotificacionPorIdNotificacion(NotificacionModel notificacion)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                notificacionBusiness.EnviarNotificacionPorIdNotificacion(notificacion);
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
