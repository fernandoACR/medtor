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

namespace ControlMedicoWinForms.Receta
{
    public class RecetaServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Receta";
        public static HttpClient client = new HttpClient();

        public RecetaServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<List<RecetaModel>> GetAllRecetas()
        {
            string methodUrl = usuariosApiUrl + "/GetAllRecetas";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var recetas = new JavaScriptSerializer().Deserialize<List<RecetaModel>>(data.List.ToString());
            // return URI of the created resource.
            return recetas;
        }

        public async Task<int> AddReceta(RecetaModel receta)
        {
            string methodUrl = usuariosApiUrl + "/AddReceta";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, receta);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            RecetaModel recetaApi = new JavaScriptSerializer().Deserialize<RecetaModel>(data.Entity.ToString());
            // return URI of the created resource.
            return recetaApi.IdReceta;
        }

        public async Task<RecetaModel> GetRecetaById(RecetaModel receta)
        {
            string methodUrl = usuariosApiUrl + "/GetRecetaById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, receta);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var recetaApi = new JavaScriptSerializer().Deserialize<RecetaModel>(data.Entity.ToString());
          
            return recetaApi;
        }

        public async Task<bool> UpdateReceta(RecetaModel receta)
        {
            string methodUrl = usuariosApiUrl + "/UpdateReceta";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, receta);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<RecetaModel>> GetRecetaByIdMedico(RecetaModel receta)
        {
            string methodUrl = usuariosApiUrl + "/GetRecetaByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, receta);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var recetas = new JavaScriptSerializer().Deserialize<List<RecetaModel>>(data.List.ToString());
            // return URI of the created resource.
            return recetas;
        }
    }
}
