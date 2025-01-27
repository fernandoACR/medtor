using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Business
{
    public class TipoArchivoBusiness : ITipoArchivoBusiness
    {
        public readonly ITipoArchivoRepository tipoArchivoRepository;

        public TipoArchivoBusiness(ITipoArchivoRepository tipoArchivoRepository)
        {
            this.tipoArchivoRepository = tipoArchivoRepository;
        }

        public int AddTipoArchivo(TipoArchivoModel tipoArchivo)
        {
            TipoArchivo tipoArchivoDb = new TipoArchivo();
            tipoArchivoDb.Descripcion = tipoArchivo.Descripcion;
            tipoArchivoDb.Activo = 1;

            return tipoArchivoRepository.AddTipoArchivo(tipoArchivoDb);
        }

        public bool UpdateTipoArchivo(TipoArchivoModel tipoArchivo)
        {
            TipoArchivo tipoArchivoDb = new TipoArchivo();
            tipoArchivoDb.IdTipoArchivo = tipoArchivo.IdTipoArchivo;
            tipoArchivoDb.Descripcion = tipoArchivo.Descripcion;
            tipoArchivoDb.Activo = tipoArchivo.Activo;

            return tipoArchivoRepository.UpdateTipoArchivo(tipoArchivoDb);
        }

        public List<TipoArchivoModel> GetAllTipoArchivos()
        {
            return tipoArchivoRepository.GetAllTipoArchivos();
        }

        public TipoArchivoModel GetTipoArchivoById(TipoArchivoModel tipoArchivo)
        {
            return tipoArchivoRepository.GetTipoArchivoById(tipoArchivo);
        }
    }
}