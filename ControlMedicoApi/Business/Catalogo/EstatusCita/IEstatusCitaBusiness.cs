using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IEstatusCitaBusiness
    {
        int AddEstatusCita(EstatusCitaModel estatusCita);
        bool UpdateEstatusCita(EstatusCitaModel estatusCita);
        List<EstatusCitaModel> GetAllEstatusCitas();
        EstatusCitaModel GetEstatusCitaById(EstatusCitaModel estatusCita);
    }
}
