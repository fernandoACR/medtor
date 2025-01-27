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

namespace ControlMedicoWinForms.Cita
{
    public class CitaServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Cita";
        public static HttpClient client = new HttpClient();

        public CitaServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<CitaModel>> GetAllCitas()
        {
            string methodUrl = usuariosApiUrl + "/GetAllCitas";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var citas = new JavaScriptSerializer().Deserialize<List<CitaModel>>(data.List.ToString());
            // return URI of the created resource.
            return citas;
        }

        public async Task<int> AddCita(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/AddCita";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            CitaModel citaApi = new JavaScriptSerializer().Deserialize<CitaModel>(data.Entity.ToString());
            // return URI of the created resource.
            return citaApi.IdCita;
        }

        public async Task<CitaModel> GetCitaById(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/GetCitaById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var citaApi = new JavaScriptSerializer().Deserialize<CitaModel>(data.Entity.ToString());

            return citaApi;
        }

        public async Task<bool> UpdateCita(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/UpdateCita";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<CitaModel>> GetCitasByIdMedico(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/GetCitasByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var citas = new JavaScriptSerializer().Deserialize<List<CitaModel>>(data.List.ToString());
            // return URI of the created resource.
            return citas;
        }

        public async Task<int> DeleteCita(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/DeleteCita";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            // return URI of the created resource.
            return Convert.ToInt32(respuesta);
        }

        public async Task<List<CitaModel>> GetCitasByFechaAndIdMedico(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/GetCitasByFechaAndIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var citas = new JavaScriptSerializer().Deserialize<List<CitaModel>>(data.List.ToString());
            // return URI of the created resource.
            return citas;
        }

        public async Task<List<CitaModel>> GetCitasByIdMedicoAndIdEstatusCita(CitaModel cita)
        {
            string methodUrl = usuariosApiUrl + "/GetCitasByIdMedicoAndIdEstatusCita";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, cita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var citas = new JavaScriptSerializer().Deserialize<List<CitaModel>>(data.List.ToString());
            // return URI of the created resource.
            return citas;
        }
    }
}
