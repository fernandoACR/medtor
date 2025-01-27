using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface ILugarNacimientoBusiness
    {
        int AddLugarNacimiento(LugarNacimientoModel lugarNacimiento);
        bool UpdateLugarNacimiento(LugarNacimientoModel lugarNacimiento);
        List<LugarNacimientoModel> GetAllLugarNacimientoes();
        LugarNacimientoModel GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento);
    }
}
