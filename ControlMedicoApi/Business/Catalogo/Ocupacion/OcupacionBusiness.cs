using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class OcupacionBusiness : IOcupacionBusiness
    {
        public readonly IOcupacionRepository ocupacionRepository;

        public OcupacionBusiness(IOcupacionRepository ocupacionRepository)
        {
            this.ocupacionRepository = ocupacionRepository;
        }

        public int AddOcupacion(OcupacionModel ocupacion)
        {
            Ocupacion ocupacionDb = new Ocupacion();
            ocupacionDb.Descripcion = ocupacion.Descripcion;
            ocupacionDb.Clave = ocupacion.Clave;
            ocupacionDb.Activo = 1;

            return ocupacionRepository.AddOcupacion(ocupacionDb);
        }

        public bool UpdateOcupacion(OcupacionModel ocupacion)
        {
            Ocupacion ocupacionDb = new Ocupacion();
            ocupacionDb.IdOcupacion = ocupacion.IdOcupacion;
            ocupacionDb.Clave = ocupacion.Clave;
            ocupacionDb.Descripcion = ocupacion.Descripcion;
            ocupacionDb.Activo = ocupacion.Activo;

            return ocupacionRepository.UpdateOcupacion(ocupacionDb);
        }

        public List<OcupacionModel> GetAllOcupacions()
        {
            return ocupacionRepository.GetAllOcupacions();
        }

        public OcupacionModel GetOcupacionById(OcupacionModel ocupacion)
        {
            return ocupacionRepository.GetOcupacionById(ocupacion);
        }
    }
}