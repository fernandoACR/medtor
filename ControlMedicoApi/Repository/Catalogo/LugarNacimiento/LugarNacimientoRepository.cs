using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class LugarNacimientoRepository : ILugarNacimientoRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddLugarNacimiento(LugarNacimiento lugarNacimiento)
        {
            db.LugarNacimientoes.Add(lugarNacimiento);
            db.SaveChanges();

            return lugarNacimiento.IdLugarNacimiento;
        }

        public bool UpdateLugarNacimiento(LugarNacimiento lugarNacimiento)
        {
            LugarNacimiento lugarNacimientoDb = db.LugarNacimientoes.Where(x => x.IdLugarNacimiento == lugarNacimiento.IdLugarNacimiento).FirstOrDefault();
            lugarNacimientoDb.Descripcion = lugarNacimiento.Descripcion;
            lugarNacimientoDb.Clave = lugarNacimiento.Clave;
            lugarNacimientoDb.Activo = lugarNacimiento.Activo;

            db.SaveChanges();

            return true;
        }

        public List<LugarNacimientoModel> GetAllLugarNacimientoes()
        {
            return (from c in db.LugarNacimientoes
                    select new LugarNacimientoModel
                    {
                        IdLugarNacimiento = c.IdLugarNacimiento,
                        Clave = c.Clave,
                        Descripcion = c.Descripcion,
                        Activo = c.Activo
                    }
                    ).ToList();
        }

        public LugarNacimientoModel GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento)
        {
            return (from c in db.LugarNacimientoes
                    select new LugarNacimientoModel
                    {
                        IdLugarNacimiento = c.IdLugarNacimiento,
                        Descripcion = c.Descripcion,
                        Clave = c.Clave,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdLugarNacimiento == lugarNacimiento.IdLugarNacimiento).FirstOrDefault();
        }
    }
}