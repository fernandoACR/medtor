using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface ICitaBusiness
    {
        int AddCita(CitaModel cita);
        bool UpdateCita(CitaModel cita);
        List<CitaModel> GetAllCitas();
        CitaModel GetCitaById(CitaModel cita);
        List<CitaModel> GetCitasByIdMedico(CitaModel cita);
        void DeleteCita(CitaModel cita);
        MemoryStream PrintCitasByFecha(DateTime fecha);
        List<CitaModel> GetCitasByFechaAndIdMedico(CitaModel cita);
        List<CitaModel> GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita);
    }
}
