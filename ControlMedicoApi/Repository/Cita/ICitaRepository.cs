using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ICitaRepository
    {
        int AddCita(Cita cita);
        bool UpdateCita(Cita cita);
        List<CitaModel> GetAllCitas();
        CitaModel GetCitaById(CitaModel cita);
        List<CitaModel> GetCitasByIdMedico(CitaModel cita);
        void DeleteCita(Cita cita);
        List<CitaModel> GetCitasByFechaAndIdMedico(CitaModel cita);
        List<CitaModel> GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita);
    }
}
