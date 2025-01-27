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

namespace ControlMedicoWinForms.Paciente
{
    public class PacienteServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Paciente";
        public static HttpClient client = new HttpClient();

        public PacienteServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<PacienteModel>> GetAllPacientes()
        {
            string methodUrl = usuariosApiUrl + "/GetAllPacientes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var pacientes = new JavaScriptSerializer().Deserialize<List<PacienteModel>>(data.List.ToString());
         
            return pacientes;
        }

        public async Task<int> AddPaciente(PacienteModel paciente)
        {
            string methodUrl = usuariosApiUrl + "/AddPaciente";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, paciente);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<PacienteModel> GetPacienteById(PacienteModel paciente)
        {
            try
            {
                string methodUrl = usuariosApiUrl + "/GetPacienteById";
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    methodUrl, paciente);
                response.EnsureSuccessStatusCode();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                serializer.MaxJsonLength = 500000000;

                dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                var pacienteApi = serializer.Deserialize<PacienteModel>(data.Entity.ToString());

                return pacienteApi;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<bool> UpdatePaciente(PacienteModel paciente)
        {
            string methodUrl = usuariosApiUrl + "/UpdatePaciente";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, paciente);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<PacienteModel>> GetPacienteByIdMedico(PacienteModel paciente)
        {
            string methodUrl = usuariosApiUrl + "/GetPacienteByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, paciente);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var pacientes = new JavaScriptSerializer().Deserialize<List<PacienteModel>>(data.List.ToString());

            return pacientes;
        }

        public async Task<int> DeletePaciente(PacienteModel paciente)
        {
            string methodUrl = usuariosApiUrl + "/DeletePaciente";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, paciente);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }
    }
}
