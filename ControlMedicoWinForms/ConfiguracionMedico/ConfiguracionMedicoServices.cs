using ControlMedicoWinForms.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ControlMedicoWinForms.ConfiguracionMedico
{
    public class ConfiguracionMedicoServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/ConfiguracionMedico";
        public static HttpClient client = new HttpClient();

        public ConfiguracionMedicoServices()
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<ConfiguracionMedicoModel>> GetAllConfiguracionMedicos()
        {
            string methodUrl = usuariosApiUrl + "/GetAllConfiguracionMedicos";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionMedicos = new JavaScriptSerializer().Deserialize<List<ConfiguracionMedicoModel>>(data.List.ToString());

            return configuracionConfiguracionMedicos;
        }

        public async Task<int> AddConfiguracionMedico(ConfiguracionMedicoModel configuracionConfiguracionMedico)
        {
            string methodUrl = usuariosApiUrl + "/AddConfiguracionMedico";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionMedico);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            ConfiguracionMedicoModel configuracionConfiguracionMedicoApi = new JavaScriptSerializer().Deserialize<ConfiguracionMedicoModel>(data.Entity.ToString());

            return configuracionConfiguracionMedicoApi.IdConfiguracionMedico;
        }

        public async Task<ConfiguracionMedicoModel> GetConfiguracionMedicoById(ConfiguracionMedicoModel configuracionConfiguracionMedico)
        {
            string methodUrl = usuariosApiUrl + "/GetConfiguracionMedicoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionMedico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionMedicoApi = new JavaScriptSerializer().Deserialize<ConfiguracionMedicoModel>(data.Entity.ToString());

            return configuracionConfiguracionMedicoApi;
        }

        public async Task<bool> UpdateConfiguracionMedico(List<ConfiguracionMedicoModel> configuracionConfiguracionMedico)
        {
            string methodUrl = usuariosApiUrl + "/UpdateConfiguracionMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionMedico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<ConfiguracionMedicoModel>> GetConfiguracionMedicoByIdMedico(ConfiguracionMedicoModel configuracionConfiguracionMedico)
        {
            string methodUrl = usuariosApiUrl + "/GetConfiguracionMedicoByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, configuracionConfiguracionMedico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var configuracionConfiguracionMedicoApi = new JavaScriptSerializer().Deserialize<List<ConfiguracionMedicoModel>>(data.List.ToString());

            return configuracionConfiguracionMedicoApi;
        }
    }
}
