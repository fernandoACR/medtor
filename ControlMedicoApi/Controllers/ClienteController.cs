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
    public class ClienteController : ApiController
    {
        private IClienteBusiness clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            this.clienteBusiness = clienteBusiness;
        }

        [HttpPost]
        [Route("api/Cliente/AddCliente")]
        public ResponseModel AddCliente(ClienteModel model)
        {

            ResponseModel response = new ResponseModel();

            try
            {
                int idCliente = clienteBusiness.AddCliente(model);
                response.Entity = new ClienteModel() { IdCliente = idCliente };
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
        [Route("api/Cliente/UpdateCliente")]
        public ResponseModel UpdateCliente(ClienteModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                clienteBusiness.UpdateCliente(model);
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
        [Route("api/Cliente/GetAllClientes")]
        public ResponseModel GetAllClientes()
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.List = clienteBusiness.GetAllClientes();
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
        [Route("api/Cliente/GetClienteById")]
        public ResponseModel GetClienteById(ClienteModel cliente)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Entity = clienteBusiness.GetClienteById(cliente);
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
