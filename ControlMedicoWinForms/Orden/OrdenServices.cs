using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ControlMedicoWinForms.Models;
using Newtonsoft.Json.Linq;

namespace ControlMedicoWinForms.Orden
{
    public class OrdenServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Orden";
        public static HttpClient client = new HttpClient();

        public OrdenServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<OrdenModel>> GetAllOrdenes()
        {
            string methodUrl = usuariosApiUrl + "/GetAllOrdenes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var ordens = new JavaScriptSerializer().Deserialize<List<OrdenModel>>(data.List.ToString());
            // return URI of the created resource.
            return ordens;
        }

        public async Task<int> AddOrden(OrdenModel orden)
        {
            string methodUrl = usuariosApiUrl + "/AddOrden";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, orden);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            // return URI of the created resource.
            return Convert.ToInt32(respuesta);
        }

        public async Task<OrdenModel> GetOrdenById(OrdenModel orden)
        {
            string methodUrl = usuariosApiUrl + "/GetOrdenById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, orden);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var ordenApi = new JavaScriptSerializer().Deserialize<OrdenModel>(data.Entity.ToString());
          
            return ordenApi;
        }

        public async Task<bool> UpdateOrden(OrdenModel orden)
        {
            string methodUrl = usuariosApiUrl + "/UpdateOrden";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, orden);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<OrdenModel>> GetOrdenByIdMedicoEntrega(OrdenModel orden)
        {
            string methodUrl = usuariosApiUrl + "/GetOrdenByIdMedicoEntrega";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, orden);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var ordens = new JavaScriptSerializer().Deserialize<List<OrdenModel>>(data.List.ToString());
            // return URI of the created resource.
            return ordens;
        }

        public async Task<List<OrdenModel>> GetOrdenByIdMedicoRecepcion(OrdenModel orden)
        {
            string methodUrl = usuariosApiUrl + "/GetOrdenByIdMedicoRecepcion";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, orden);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var ordens = new JavaScriptSerializer().Deserialize<List<OrdenModel>>(data.List.ToString());
            // return URI of the created resource.
            return ordens;
        }
    }
}
