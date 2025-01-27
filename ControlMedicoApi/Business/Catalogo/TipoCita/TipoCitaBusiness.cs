using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class TipoCitaBusiness : ITipoCitaBusiness
    {
        public readonly ITipoCitaRepository tipoCitaRepository;

        public TipoCitaBusiness(ITipoCitaRepository tipoCitaRepository)
        {
            this.tipoCitaRepository = tipoCitaRepository;
        }

        public int AddTipoCita(TipoCitaModel tipoCita)
        {
            TipoCita tipoCitaDb = new TipoCita();
            tipoCitaDb.Descripcion = tipoCita.Descripcion;
            tipoCitaDb.Clave = tipoCita.Clave;
            tipoCitaDb.Activo = 1;

            return tipoCitaRepository.AddTipoCita(tipoCitaDb);
        }

        public bool UpdateTipoCita(TipoCitaModel tipoCita)
        {
            TipoCita tipoCitaDb = new TipoCita();
            tipoCitaDb.IdTipoCita = tipoCita.IdTipoCita;
            tipoCitaDb.Clave = tipoCita.Clave;
            tipoCitaDb.Descripcion = tipoCita.Descripcion;
            tipoCitaDb.Activo = tipoCita.Activo;

            return tipoCitaRepository.UpdateTipoCita(tipoCitaDb);
        }

        public List<TipoCitaModel> GetAllTipoCitas()
        {
            return tipoCitaRepository.GetAllTipoCitas();
        }

        public TipoCitaModel GetTipoCitaById(TipoCitaModel tipoCita)
        {
            return tipoCitaRepository.GetTipoCitaById(tipoCita);
        }
    }
}