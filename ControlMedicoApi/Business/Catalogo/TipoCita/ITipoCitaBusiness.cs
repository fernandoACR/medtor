using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface ITipoCitaBusiness
    {
        int AddTipoCita(TipoCitaModel tipoCita);
        bool UpdateTipoCita(TipoCitaModel tipoCita);
        List<TipoCitaModel> GetAllTipoCitas();
        TipoCitaModel GetTipoCitaById(TipoCitaModel tipoCita);
    }
}
