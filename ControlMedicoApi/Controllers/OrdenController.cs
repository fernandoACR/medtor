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
    public class OrdenController : ApiController
    {
        private IOrdenBusiness ordenBusiness;

        public OrdenController(IOrdenBusiness ordenBusiness)
        {
            this.ordenBusiness = ordenBusiness;
        }

        [HttpPost]
        [Route("api/Orden/AddOrden")]
        public ResponseModel AddOrden(OrdenModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ordenBusiness.AddOrden(model);
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Orden/UpdateOrden")]
        public ResponseModel UpdateOrden(OrdenModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                ordenBusiness.UpdateOrden(model);
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Orden/GetAllOrdenes")]
        public ResponseModel GetAllOrdenes()
        {
            ResponseModel response = new ResponseModel();
            
            try
            {
                response.List = ordenBusiness.GetAllOrdenes();
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }            

            return response;
        }

        [HttpPost]
        [Route("api/Orden/GetOrdenById")]
        public ResponseModel GetOrdenById(OrdenModel orden)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = ordenBusiness.GetOrdenById(orden);
                response.Response = true;
            }
            catch(Exception ex)
            {
                response.Response = false;
                response.ErrorList.Add(ex.Message);
            }

            return response;
        }

        [HttpPost]
        [Route("api/Orden/GetOrdenByIdMedicoEntrega")]
        public ResponseModel GetOrdenByIdMedicoEntrega(OrdenModel orden)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = ordenBusiness.GetOrdenByIdMedicoEntrega(orden);
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
        [Route("api/Orden/GetOrdenByIdMedicoRecepcion")]
        public ResponseModel GetOrdenByIdMedicoRecepcion(OrdenModel orden)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = ordenBusiness.GetOrdenByIdMedicoRecepcion(orden);
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
