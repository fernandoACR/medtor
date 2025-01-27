using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IEspecimenRepository
    {
        int AddEspecimen(Especiman especimen);
        bool UpdateEspecimen(Especiman especimen);
        List<EspecimenModel> GetAllEspecimenes();
        EspecimenModel GetEspecimenById(EspecimenModel especimen);
        List<EspecimenModel> GetEspecimenByIdMedico(EspecimenModel especimen);
        List<EspecimenModel> GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen);
    }
}
