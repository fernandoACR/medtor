using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface INotificacionRepository
    {
        int AddNotificacion(Notificacion notificacion);
        bool UpdateNotificacion(Notificacion notificacion);
        List<NotificacionModel> GetAllNotificacions();
        NotificacionModel GetNotificacionById(NotificacionModel notificacion);
        List<NotificacionModel> GetNotificacionByIdPaciente(NotificacionModel notificacion);
    }
}
