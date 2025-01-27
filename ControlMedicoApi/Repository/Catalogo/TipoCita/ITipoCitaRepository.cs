using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ITipoCitaRepository
    {
        int AddTipoCita(TipoCita tipoCita);
        bool UpdateTipoCita(TipoCita tipoCita);
        List<TipoCitaModel> GetAllTipoCitas();
        TipoCitaModel GetTipoCitaById(TipoCitaModel tipoCita);
    }
}
