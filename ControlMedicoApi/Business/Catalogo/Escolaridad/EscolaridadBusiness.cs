using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class EscolaridadBusiness : IEscolaridadBusiness
    {
        public readonly IEscolaridadRepository escolaridadRepository;

        public EscolaridadBusiness(IEscolaridadRepository escolaridadRepository)
        {
            this.escolaridadRepository = escolaridadRepository;
        }

        public int AddEscolaridad(EscolaridadModel escolaridad)
        {
            Escolaridad escolaridadDb = new Escolaridad();
            escolaridadDb.Descripcion = escolaridad.Descripcion;
            escolaridadDb.Clave = escolaridad.Clave;
            escolaridadDb.Activo = 1;

            return escolaridadRepository.AddEscolaridad(escolaridadDb);
        }

        public bool UpdateEscolaridad(EscolaridadModel escolaridad)
        {
            Escolaridad escolaridadDb = new Escolaridad();
            escolaridadDb.IdEscolaridad = escolaridad.IdEscolaridad;
            escolaridadDb.Clave = escolaridad.Clave;
            escolaridadDb.Descripcion = escolaridad.Descripcion;
            escolaridadDb.Activo = escolaridad.Activo;

            return escolaridadRepository.UpdateEscolaridad(escolaridadDb);
        }

        public List<EscolaridadModel> GetAllEscolaridades()
        {
            return escolaridadRepository.GetAllEscolaridades();
        }

        public EscolaridadModel GetEscolaridadById(EscolaridadModel escolaridad)
        {
            return escolaridadRepository.GetEscolaridadById(escolaridad);
        }
    }
}