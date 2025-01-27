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

namespace ControlMedicoWinForms.Suscripcion
{
    public class SuscripcionServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Suscripcion";
        public static HttpClient client = new HttpClient();

        public SuscripcionServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<SuscripcionModel>> GetAllSuscripcions()
        {
            string methodUrl = usuariosApiUrl + "/GetAllSuscripcions";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var suscripcions = new JavaScriptSerializer().Deserialize<List<SuscripcionModel>>(data.List.ToString());

            return suscripcions;
        }

        public async Task<int> AddSuscripcion(SuscripcionModel suscripcion)
        {
            string methodUrl = usuariosApiUrl + "/AddSuscripcion";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, suscripcion);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<SuscripcionModel> GetSuscripcionById(SuscripcionModel suscripcion)
        {
            string methodUrl = usuariosApiUrl + "/GetSuscripcionById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, suscripcion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var suscripcionApi = new JavaScriptSerializer().Deserialize<SuscripcionModel>(data.Entity.ToString());

            return suscripcionApi;
        }

        public async Task<bool> UpdateSuscripcion(SuscripcionModel suscripcion)
        {
            string methodUrl = usuariosApiUrl + "/UpdateSuscripcion";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, suscripcion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }
    }
}
