using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlMedicoApi.Controllers
{
    [Authorize]
    public class RecetaController : ApiController
    {
        private IRecetaBusiness recetaBusiness;

        public RecetaController(IRecetaBusiness recetaBusiness)
        {
            this.recetaBusiness = recetaBusiness;
        }

        [HttpPost]
        [Route("api/Receta/AddReceta")]
        public ResponseModel AddReceta(RecetaModel model)
        {

            ResponseModel response = new ResponseModel();

            try
            {
                int idReceta = recetaBusiness.AddReceta(model);
                response.Response = true;
                response.Entity = new RecetaModel() { IdReceta = idReceta };
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Receta/UpdateReceta")]
        public ResponseModel UpdateReceta(RecetaModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                recetaBusiness.UpdateReceta(model);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Receta/GetAllRecetas")]
        public ResponseModel GetAllRecetas()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = recetaBusiness.GetAllRecetas();
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Receta/GetRecetaById")]
        public ResponseModel GetRecetaById(RecetaModel receta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = recetaBusiness.GetRecetaById(receta);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Receta/GetRecetaByIdMedico")]
        public ResponseModel GetRecetaByIdMedico(RecetaModel receta)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = recetaBusiness.GetRecetaByIdMedico(receta);
                response.Response = true;
            }
            catch (Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }
    }
}
