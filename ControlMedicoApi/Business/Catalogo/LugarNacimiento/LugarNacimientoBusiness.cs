using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class LugarNacimientoBusiness : ILugarNacimientoBusiness
    {
        public readonly ILugarNacimientoRepository lugarNacimientoRepository;

        public LugarNacimientoBusiness(ILugarNacimientoRepository lugarNacimientoRepository)
        {
            this.lugarNacimientoRepository = lugarNacimientoRepository;
        }

        public int AddLugarNacimiento(LugarNacimientoModel lugarNacimiento)
        {
            LugarNacimiento lugarNacimientoDb = new LugarNacimiento();
            lugarNacimientoDb.Descripcion = lugarNacimiento.Descripcion;
            lugarNacimientoDb.Clave = lugarNacimiento.Clave;
            lugarNacimientoDb.Activo = 1;

            return lugarNacimientoRepository.AddLugarNacimiento(lugarNacimientoDb);
        }

        public bool UpdateLugarNacimiento(LugarNacimientoModel lugarNacimiento)
        {
            LugarNacimiento lugarNacimientoDb = new LugarNacimiento();
            lugarNacimientoDb.IdLugarNacimiento = lugarNacimiento.IdLugarNacimiento;
            lugarNacimientoDb.Clave = lugarNacimiento.Clave;
            lugarNacimientoDb.Descripcion = lugarNacimiento.Descripcion;
            lugarNacimientoDb.Activo = lugarNacimiento.Activo;

            return lugarNacimientoRepository.UpdateLugarNacimiento(lugarNacimientoDb);
        }

        public List<LugarNacimientoModel> GetAllLugarNacimientoes()
        {
            return lugarNacimientoRepository.GetAllLugarNacimientoes();
        }

        public LugarNacimientoModel GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento)
        {
            return lugarNacimientoRepository.GetLugarNacimientoById(lugarNacimiento);
        }
    }
}