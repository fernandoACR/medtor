using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEstatusCitaRepository
    {
        int AddEstatusCita(EstatusCita estatusCita);
        bool UpdateEstatusCita(EstatusCita estatusCita);
        List<EstatusCitaModel> GetAllEstatusCitas();
        EstatusCitaModel GetEstatusCitaById(EstatusCitaModel estatusCita);
    }
}
