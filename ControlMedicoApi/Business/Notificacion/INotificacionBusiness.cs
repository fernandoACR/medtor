using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Business
{
    public interface INotificacionBusiness
    {
        void NotificarPorEmail(EmailModel model, HttpContext context, int tipoNotificacion);
        int AddNotificacion(NotificacionModel notificacion);
        bool UpdateNotificacion(NotificacionModel notificacion);
        void EnviarNotificacionPorIdNotificacion(NotificacionModel notificacion);
    }
}
