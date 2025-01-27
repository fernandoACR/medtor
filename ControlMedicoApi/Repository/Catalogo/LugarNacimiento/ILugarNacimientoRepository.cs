using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ILugarNacimientoRepository
    {
        int AddLugarNacimiento(LugarNacimiento lugarNacimiento);
        bool UpdateLugarNacimiento(LugarNacimiento lugarNacimiento);
        List<LugarNacimientoModel> GetAllLugarNacimientoes();
        LugarNacimientoModel GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento);
    }
}
