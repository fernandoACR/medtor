using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IEspecimenBusiness
    {
        int AddEspecimen(EspecimenModel especimen);
        bool UpdateEspecimen(EspecimenModel especimen);
        List<EspecimenModel> GetAllEspecimenes();
        EspecimenModel GetEspecimenById(EspecimenModel especimen);
        List<EspecimenModel> GetEspecimenByIdMedico(EspecimenModel especimen);
        List<EspecimenModel> GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen);
    }
}
