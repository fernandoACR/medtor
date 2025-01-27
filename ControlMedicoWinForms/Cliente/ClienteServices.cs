using ControlMedicoWinForms.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ControlMedicoWinForms.Cliente
{
    public class ClienteServices
    {
        private static string clientesApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Cliente";
        public static HttpClient client = new HttpClient();

        public ClienteServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<ClienteModel>> GetAllClientes()
        {
            string methodUrl = clientesApiUrl + "/GetAllClientes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var clientes = new JavaScriptSerializer().Deserialize<List<ClienteModel>>(data.List.ToString());

            return clientes;
        }

        public async Task<int> AddCliente(ClienteModel cliente)
        {
            string methodUrl = clientesApiUrl + "/AddCliente";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cliente);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            ClienteModel respuesta = new JavaScriptSerializer().Deserialize<ClienteModel>(data.Entity.ToString());

            return Convert.ToInt32(respuesta.IdCliente);
        }

        public async Task<ClienteModel> GetClienteById(ClienteModel cliente)
        {
            string methodUrl = clientesApiUrl + "/GetClienteById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cliente);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var clienteApi = new JavaScriptSerializer().Deserialize<ClienteModel>(data.Entity.ToString());

            return clienteApi;
        }

        public async Task<bool> UpdateCliente(ClienteModel cliente)
        {
            string methodUrl = clientesApiUrl + "/UpdateCliente";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cliente);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }
    }
}
