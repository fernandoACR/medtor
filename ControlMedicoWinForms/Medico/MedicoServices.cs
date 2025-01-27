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

namespace ControlMedicoWinForms.Medico
{
    public class MedicoServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Medico";
        public static HttpClient client = new HttpClient();

        public MedicoServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<MedicoModel>> GetAllMedicos()
        {
            string methodUrl = usuariosApiUrl + "/GetAllMedicos";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var medicos = new JavaScriptSerializer().Deserialize<List<MedicoModel>>(data.List.ToString());
            
            return medicos;
        }

        public async Task<int> AddMedico(MedicoModel medico)
        {
            string methodUrl = usuariosApiUrl + "/AddMedico";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medico);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            MedicoModel medicoApi = new JavaScriptSerializer().Deserialize<MedicoModel>(data.Entity.ToString());

            return medicoApi.IdMedico;
        }

        public async Task<MedicoModel> GetMedicoById(MedicoModel medico)
        {
            string methodUrl = usuariosApiUrl + "/GetMedicoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var medicoApi = new JavaScriptSerializer().Deserialize<MedicoModel>(data.Entity.ToString());
            
            return medicoApi;
        }

        public async Task<bool> UpdateMedico(MedicoModel medico)
        {
            string methodUrl = usuariosApiUrl + "/UpdateMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<MedicoModel>> GetMedicoByIdSuscripcion(MedicoModel medico)
        {
            string methodUrl = usuariosApiUrl + "/GetMedicoByIdSuscripcion";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var medicoApi = new JavaScriptSerializer().Deserialize<List<MedicoModel>>(data.List.ToString());

            return medicoApi;
        }
    }
}
