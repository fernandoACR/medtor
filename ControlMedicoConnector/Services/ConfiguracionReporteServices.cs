using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;
using ControlMedicoConnector.Models;
using Newtonsoft.Json.Linq;

namespace ControlMedicoConnector.Services
{
    public class ConfiguracionReporteServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/ConfiguracionReporte";
        public static HttpClient client = new HttpClient();

        public ConfiguracionReporteServices()
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<ConfiguracionReporteModel>> GetAllConfiguracionReportes()
        {
            string methodUrl = usuariosApiUrl + "/GetAllConfiguracionReportes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionReportes = new JavaScriptSerializer().Deserialize<List<ConfiguracionReporteModel>>(data.List.ToString());

            return configuracionConfiguracionReportes;
        }

        public async Task<int> AddConfiguracionReporte(ConfiguracionReporteModel configuracionConfiguracionReporte)
        {
            string methodUrl = usuariosApiUrl + "/AddConfiguracionReporte";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionReporte);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            ConfiguracionReporteModel configuracionConfiguracionReporteApi = new JavaScriptSerializer().Deserialize<ConfiguracionReporteModel>(data.Entity.ToString());

            return configuracionConfiguracionReporteApi.IdConfiguracionReporte;
        }

        public async Task<ConfiguracionReporteModel> GetConfiguracionReporteById(ConfiguracionReporteModel configuracionConfiguracionReporte)
        {
            string methodUrl = usuariosApiUrl + "/GetConfiguracionReporteById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionReporte);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionReporteApi = new JavaScriptSerializer().Deserialize<ConfiguracionReporteModel>(data.Entity.ToString());

            return configuracionConfiguracionReporteApi;
        }

        public async Task<bool> UpdateConfiguracionReporte(ConfiguracionReporteModel configuracionConfiguracionReporte)
        {
            string methodUrl = usuariosApiUrl + "/UpdateConfiguracionReporte";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionReporte);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<ConfiguracionReporteModel>> GetConfiguracionReporteByIdMedico(ConfiguracionReporteModel configuracionConfiguracionReporte)
        {
            string methodUrl = usuariosApiUrl + "/GetConfiguracionReporteByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionReporte);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionReporteApi = new JavaScriptSerializer().Deserialize<List<ConfiguracionReporteModel>>(data.List.ToString());

            return configuracionConfiguracionReporteApi;
        }
    }
}
