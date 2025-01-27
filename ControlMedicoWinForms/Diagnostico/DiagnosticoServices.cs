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

namespace ControlMedicoWinForms.Diagnostico
{
    public class DiagnosticoServices
    {
        private static string diagnosticosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Diagnostico";
        public static HttpClient client = new HttpClient();

        public DiagnosticoServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<DiagnosticoModel>> GetAllDiagnosticos()
        {
            string methodUrl = diagnosticosApiUrl + "/GetAllDiagnosticos";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var diagnosticos = new JavaScriptSerializer().Deserialize<List<DiagnosticoModel>>(data.List.ToString());
            // return URI of the created resource.
            return diagnosticos;
        }

        public async Task<int> AddDiagnostico(DiagnosticoModel diagnostico)
        {
            string methodUrl = diagnosticosApiUrl + "/AddDiagnostico";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, diagnostico);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            DiagnosticoModel diagnosticoApi = new JavaScriptSerializer().Deserialize<DiagnosticoModel>(data.Entity.ToString());

            // return URI of the created resource.
            return diagnosticoApi.IdDiagnostico;
        }

        public async Task<DiagnosticoModel> GetDiagnosticoById(DiagnosticoModel diagnostico)
        {
            string methodUrl = diagnosticosApiUrl + "/GetDiagnosticoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, diagnostico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var diagnosticoApi = new JavaScriptSerializer().Deserialize<DiagnosticoModel>(data.Entity.ToString());

            return diagnosticoApi;
        }

        public async Task<bool> UpdateDiagnostico(DiagnosticoModel diagnostico)
        {
            string methodUrl = diagnosticosApiUrl + "/UpdateDiagnostico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, diagnostico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<DiagnosticoModel>> GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico)
        {
            string methodUrl = diagnosticosApiUrl + "/GetDiagnosticoByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, diagnostico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var diagnosticos = new JavaScriptSerializer().Deserialize<List<DiagnosticoModel>>(data.List.ToString());
            // return URI of the created resource.
            return diagnosticos;
        }

        public async Task<List<DiagnosticoModel>> GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico)
        {
            string methodUrl = diagnosticosApiUrl + "/GetDiagnosticoByIdPaciente";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, diagnostico);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var diagnosticos = new JavaScriptSerializer().Deserialize<List<DiagnosticoModel>>(data.List.ToString());
            // return URI of the created resource.
            return diagnosticos;
        }
    }
}
