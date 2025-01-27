using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using ControlMedicoConnector.Models;
using ControlMedicoConnector.Models.Login;
using Newtonsoft.Json.Linq;

namespace ControlMedicoConnector.Services
{    
    public class UsuarioServices
    {
        private static string usuariosApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Account";
        public static HttpClient client = new HttpClient();

        public async Task<LoginResponse> Login(string user, string pass)
        {
            string methodUrl = usuariosApiUrl + "/Login";
            object model = new
            {
                Username = user,
                Password = pass
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, model);
            response.EnsureSuccessStatusCode();

            var loginInfo = new JavaScriptSerializer().Deserialize<LoginResponse>(response.Content.ReadAsStringAsync().Result);
            // return URI of the created resource.
            return loginInfo;
        }

        public async Task<bool> Register(RegistroUsuarioModel registroUsuario)
        {
            string methodUrl = usuariosApiUrl + "/Register";
            object model = new
            {
                Email = registroUsuario.Correo,
                Password = registroUsuario.Password,
                ConfirmPassword = registroUsuario.ConfirmaPassword,
                Role = registroUsuario.Rol,
                IdSuscripcion = registroUsuario.IdSuscripcion,
                IdMedico = registroUsuario.IdMedico
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, model);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            if(!respuesta)
            {

            }

            return respuesta;
        }

        public async Task<bool> ChangePassword(EditarPasswordModel editarPasswordModel)
        {
            string methodUrl = usuariosApiUrl + "/ChangePassword";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
            object model = new
            {
                UserId = editarPasswordModel.UserId,
                OldPassword = editarPasswordModel.PasswordActual,
                NewPassword = editarPasswordModel.NuevoPassword,
                ConfirmPassword = editarPasswordModel.ConfirmarPassword
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, model);
            response.EnsureSuccessStatusCode();

            //var respuesta = Convert.ToBoolean(response.Content.ReadAsStringAsync().Result);
            // return URI of the created resource.
            return true;
        }
    }
}
