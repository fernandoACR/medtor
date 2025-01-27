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
using static ControlMedicoWinForms.Models.ComunModel;

namespace ControlMedicoWinForms.Notificacion
{
    public class NotificacionServices
    {
        private static string notificacionApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Notificacion";
        public static HttpClient client = new HttpClient();

        public NotificacionServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public async Task<int> AddNotificacion(NotificacionModel notificacion)
        {
            string methodUrl = notificacionApiUrl + "/AddNotificacion";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, notificacion);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
            NotificacionModel notificacionApi = new JavaScriptSerializer().Deserialize<NotificacionModel>(data.Entity.ToString());

            return notificacionApi.IdNotificacion;
        }

        public async Task<NotificacionModel> GetNotificacionById(NotificacionModel notificacion)
        {
            string methodUrl = notificacionApiUrl + "/GetNotificacionById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, notificacion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var notificacionApi = new JavaScriptSerializer().Deserialize<NotificacionModel>(data.Entity.ToString());

            return notificacionApi;
        }

        public async Task<int> NotificarPorEmail(EmailModel emailModel)
        {
            string methodUrl = notificacionApiUrl + "/NotificarPorEmail";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, emailModel);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<int> EnviarNotificacionPorIdNotificacion(NotificacionModel notificacion)
        {
            string methodUrl = notificacionApiUrl + "/EnviarNotificacionPorIdNotificacion";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, notificacion);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }
    }
}
