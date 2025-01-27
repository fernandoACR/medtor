using ControlMedicoWinForms.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ControlMedicoWinForms.Catalogo
{
    public class CatalogoServices
    {
        private static string especialidadApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Especialidad";
        private static string especimenApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Especimen";
        private static string escolaridadApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Escolaridad";
        private static string patologiaApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Patologia";
        private static string estatusCitaApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/EstatusCita";
        private static string tipoCitaApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/TipoCita";
        private static string medicamentoApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Medicamento";
        private static string ocupacionApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Ocupacion";
        private static string tipoArchivoApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/TipoArchivo";
        private static string lugarNacimientoApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/LugarNacimiento";

        public static HttpClient client = new HttpClient();

        public CatalogoServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        #region Especialidad

        public async Task<List<EspecialidadModel>> GetAllEspecialidades()
        {
            string methodUrl = especialidadApiUrl + "/GetAllEspecialidades";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<EspecialidadModel> especialidads = new JavaScriptSerializer().Deserialize<List<EspecialidadModel>>(data.List.ToString());

            return especialidads;
        }

        public async Task<int> AddEspecialidad(EspecialidadModel especialidad)
        {
            string methodUrl = especialidadApiUrl + "/AddEspecialidad";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especialidad);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<EspecialidadModel> GetEspecialidadById(EspecialidadModel especialidad)
        {
            string methodUrl = especialidadApiUrl + "/GetEspecialidadById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especialidad);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var especialidadApi = new JavaScriptSerializer().Deserialize<EspecialidadModel>(data.Entity.ToString());
          
            return especialidadApi;
        }

        public async Task<bool> UpdateEspecialidad(EspecialidadModel especialidad)
        {
            string methodUrl = especialidadApiUrl + "/UpdateEspecialidad";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especialidad);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        #endregion

        #region Especimen
        public async Task<List<EspecimenModel>> GetAllEspecimenes()
        {
            string methodUrl = especimenApiUrl + "/GetAllEspecimenes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var especimens = new JavaScriptSerializer().Deserialize<List<EspecimenModel>>(data.List.ToString());
            
            return especimens;
        }

        public async Task<int> AddEspecimen(EspecimenModel especimen)
        {
            string methodUrl = especimenApiUrl + "/AddEspecimen";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especimen);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<EspecimenModel> GetEspecimenById(EspecimenModel especimen)
        {
            string methodUrl = especimenApiUrl + "/GetEspecimenById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especimen);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var especimenApi = new JavaScriptSerializer().Deserialize<EspecimenModel>(data.Entity.ToString());
           
            return especimenApi;
        }

        public async Task<bool> UpdateEspecimen(EspecimenModel especimen)
        {
            string methodUrl = especimenApiUrl + "/UpdateEspecimen";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especimen);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());
           
            return respuesta;
        }

        public async Task<List<EspecimenModel>> GetEspecimenByIdMedico(EspecimenModel especimen)
        {
            string methodUrl = especimenApiUrl + "/GetEspecimenByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especimen);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<EspecimenModel> especimens = new JavaScriptSerializer().Deserialize<List<EspecimenModel>>(data.List.ToString());

            return especimens;
        }

        public async Task<List<EspecimenModel>> GetEspecimenesByIdMedicoAndActivo(EspecimenModel especimen)
        {
            string methodUrl = especimenApiUrl + "/GetEspecimenesByIdMedicoAndActivo";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, especimen);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<EspecimenModel> especimens = new JavaScriptSerializer().Deserialize<List<EspecimenModel>>(data.List.ToString());

            return especimens;
        }
        #endregion

        #region Escolaridad

        public async Task<List<EscolaridadModel>> GetAllEscolaridades()
        {
            string methodUrl = escolaridadApiUrl + "/GetAllEscolaridades";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<EscolaridadModel> escolaridads = new JavaScriptSerializer().Deserialize<List<EscolaridadModel>>(data.List.ToString());

            return escolaridads;
        }

        public async Task<int> AddEscolaridad(EscolaridadModel escolaridad)
        {
            string methodUrl = escolaridadApiUrl + "/AddEscolaridad";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, escolaridad);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<EscolaridadModel> GetEscolaridadById(EscolaridadModel escolaridad)
        {
            string methodUrl = escolaridadApiUrl + "/GetEscolaridadById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, escolaridad);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var escolaridadApi = new JavaScriptSerializer().Deserialize<EscolaridadModel>(data.Entity.ToString());

            return escolaridadApi;
        }

        public async Task<bool> UpdateEscolaridad(EscolaridadModel escolaridad)
        {
            string methodUrl = escolaridadApiUrl + "/UpdateEscolaridad";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, escolaridad);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        #endregion

        #region Patologia

        public async Task<List<PatologiaModel>> GetAllPatologias()
        {
            string methodUrl = patologiaApiUrl + "/GetAllPatologias";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<PatologiaModel> patologias = new JavaScriptSerializer().Deserialize<List<PatologiaModel>>(data.List.ToString());

            return patologias;
        }

        public async Task<int> AddPatologia(PatologiaModel patologia)
        {
            string methodUrl = patologiaApiUrl + "/AddPatologia";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, patologia);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<PatologiaModel> GetPatologiaById(PatologiaModel patologia)
        {
            string methodUrl = patologiaApiUrl + "/GetPatologiaById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, patologia);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var patologiaApi = new JavaScriptSerializer().Deserialize<PatologiaModel>(data.Entity.ToString());

            return patologiaApi;
        }

        public async Task<bool> UpdatePatologia(PatologiaModel patologia)
        {
            string methodUrl = patologiaApiUrl + "/UpdatePatologia";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, patologia);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<PatologiaModel>> GetPatologiaByIdMedico(PatologiaModel patologia)
        {
            string methodUrl = patologiaApiUrl + "/GetPatologiaByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, patologia);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<PatologiaModel> patologias = new JavaScriptSerializer().Deserialize<List<PatologiaModel>>(data.List.ToString());

            return patologias;
        }

        public async Task<List<PatologiaModel>> GetPatologiaByIdMedicoAndActivo(PatologiaModel patologia)
        {
            string methodUrl = patologiaApiUrl + "/GetPatologiaByIdMedicoAndActivo";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, patologia);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<PatologiaModel> patologias = new JavaScriptSerializer().Deserialize<List<PatologiaModel>>(data.List.ToString());

            return patologias;
        }

        #endregion

        #region EstatusCita

        public async Task<List<EstatusCitaModel>> GetAllEstatusCitas()
        {
            string methodUrl = estatusCitaApiUrl + "/GetAllEstatusCitas";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<EstatusCitaModel> estatusCitas = new JavaScriptSerializer().Deserialize<List<EstatusCitaModel>>(data.List.ToString());

            return estatusCitas;
        }

        public async Task<int> AddEstatusCita(EstatusCitaModel estatusCita)
        {
            string methodUrl = estatusCitaApiUrl + "/AddEstatusCita";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, estatusCita);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<EstatusCitaModel> GetEstatusCitaById(EstatusCitaModel estatusCita)
        {
            string methodUrl = estatusCitaApiUrl + "/GetEstatusCitaById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, estatusCita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var estatusCitaApi = new JavaScriptSerializer().Deserialize<EstatusCitaModel>(data.Entity.ToString());

            return estatusCitaApi;
        }

        public async Task<bool> UpdateEstatusCita(EstatusCitaModel estatusCita)
        {
            string methodUrl = estatusCitaApiUrl + "/UpdateEstatusCita";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, estatusCita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        #endregion

        #region TipoCita

        public async Task<List<TipoCitaModel>> GetAllTipoCitas()
        {
            string methodUrl = tipoCitaApiUrl + "/GetAllTipoCitas";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<TipoCitaModel> tipoCitas = new JavaScriptSerializer().Deserialize<List<TipoCitaModel>>(data.List.ToString());

            return tipoCitas;
        }

        public async Task<int> AddTipoCita(TipoCitaModel tipoCita)
        {
            string methodUrl = tipoCitaApiUrl + "/AddTipoCita";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoCita);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<TipoCitaModel> GetTipoCitaById(TipoCitaModel tipoCita)
        {
            string methodUrl = tipoCitaApiUrl + "/GetTipoCitaById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoCita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var tipoCitaApi = new JavaScriptSerializer().Deserialize<TipoCitaModel>(data.Entity.ToString());

            return tipoCitaApi;
        }

        public async Task<bool> UpdateTipoCita(TipoCitaModel tipoCita)
        {
            string methodUrl = tipoCitaApiUrl + "/UpdateTipoCita";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoCita);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        #endregion

        #region Medicamento

        public async Task<List<MedicamentoModel>> GetAllMedicamentos()
        {
            string methodUrl = medicamentoApiUrl + "/GetAllMedicamentos";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<MedicamentoModel> medicamentos = new JavaScriptSerializer().Deserialize<List<MedicamentoModel>>(data.List.ToString());

            return medicamentos;
        }

        public async Task<int> AddMedicamento(MedicamentoModel medicamento)
        {
            string methodUrl = medicamentoApiUrl + "/AddMedicamento";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medicamento);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<MedicamentoModel> GetMedicamentoById(MedicamentoModel medicamento)
        {
            string methodUrl = medicamentoApiUrl + "/GetMedicamentoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medicamento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var medicamentoApi = new JavaScriptSerializer().Deserialize<MedicamentoModel>(data.Entity.ToString());

            return medicamentoApi;
        }

        public async Task<bool> UpdateMedicamento(MedicamentoModel medicamento)
        {
            string methodUrl = medicamentoApiUrl + "/UpdateMedicamento";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medicamento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<MedicamentoModel>> GetMedicamentoByIdMedico(MedicamentoModel medicamento)
        {
            string methodUrl = medicamentoApiUrl + "/GetMedicamentoByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medicamento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<MedicamentoModel> medicamentos = new JavaScriptSerializer().Deserialize<List<MedicamentoModel>>(data.List.ToString());

            return medicamentos;
        }

        public async Task<List<MedicamentoModel>> GetMedicamentosByIdMedicoAndActivo(MedicamentoModel medicamento)
        {
            string methodUrl = medicamentoApiUrl + "/GetMedicamentosByIdMedicoAndActivo";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, medicamento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<MedicamentoModel> medicamentos = new JavaScriptSerializer().Deserialize<List<MedicamentoModel>>(data.List.ToString());

            return medicamentos;
        }

        #endregion

        #region Ocupacion

        public async Task<List<OcupacionModel>> GetAllOcupacions()
        {
            string methodUrl = ocupacionApiUrl + "/GetAllOcupacions";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<OcupacionModel> ocupacions = new JavaScriptSerializer().Deserialize<List<OcupacionModel>>(data.List.ToString());

            return ocupacions;
        }

        public async Task<int> AddOcupacion(OcupacionModel ocupacion)
        {
            string methodUrl = ocupacionApiUrl + "/AddOcupacion";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, ocupacion);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<OcupacionModel> GetOcupacionById(OcupacionModel ocupacion)
        {
            string methodUrl = ocupacionApiUrl + "/GetOcupacionById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, ocupacion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var ocupacionApi = new JavaScriptSerializer().Deserialize<OcupacionModel>(data.Entity.ToString());

            return ocupacionApi;
        }

        public async Task<bool> UpdateOcupacion(OcupacionModel ocupacion)
        {
            string methodUrl = ocupacionApiUrl + "/UpdateOcupacion";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, ocupacion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        public async Task<List<OcupacionModel>> GetOcupacionByIdMedico(OcupacionModel ocupacion)
        {
            string methodUrl = ocupacionApiUrl + "/GetOcupacionByIdMedico";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, ocupacion);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<OcupacionModel> ocupacions = new JavaScriptSerializer().Deserialize<List<OcupacionModel>>(data.List.ToString());

            return ocupacions;
        }

        #endregion

        #region TipoArchivo
        public async Task<List<TipoArchivoModel>> GetAllTipoArchivos()
        {
            string methodUrl = tipoArchivoApiUrl + "/GetAllTipoArchivos";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<TipoArchivoModel> tipoArchivos = new JavaScriptSerializer().Deserialize<List<TipoArchivoModel>>(data.List.ToString());

            return tipoArchivos;
        }

        public async Task<int> AddTipoArchivo(TipoArchivoModel tipoArchivo)
        {
            string methodUrl = tipoArchivoApiUrl + "/AddTipoArchivo";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoArchivo);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<TipoArchivoModel> GetTipoArchivoById(TipoArchivoModel tipoArchivo)
        {
            string methodUrl = tipoArchivoApiUrl + "/GetTipoArchivoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoArchivo);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var tipoArchivoApi = new JavaScriptSerializer().Deserialize<TipoArchivoModel>(data.Entity.ToString());

            return tipoArchivoApi;
        }

        public async Task<bool> UpdateTipoArchivo(TipoArchivoModel tipoArchivo)
        {
            string methodUrl = tipoArchivoApiUrl + "/UpdateTipoArchivo";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, tipoArchivo);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }
        #endregion

        #region LugarNacimiento 

        public async Task<List<LugarNacimientoModel>> GetAllLugarNacimientoes()
        {
            string methodUrl = lugarNacimientoApiUrl + "/GetAllLugarNacimientoes";
            HttpResponseMessage response = await client.GetAsync(
                methodUrl);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            List<LugarNacimientoModel> lugarNacimientos = new JavaScriptSerializer().Deserialize<List<LugarNacimientoModel>>(data.List.ToString());

            return lugarNacimientos;
        }

        public async Task<int> AddLugarNacimiento(LugarNacimientoModel lugarNacimiento)
        {
            string methodUrl = lugarNacimientoApiUrl + "/AddLugarNacimiento";

            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, lugarNacimiento);

            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return Convert.ToInt32(respuesta);
        }

        public async Task<LugarNacimientoModel> GetLugarNacimientoById(LugarNacimientoModel lugarNacimiento)
        {
            string methodUrl = lugarNacimientoApiUrl + "/GetLugarNacimientoById";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, lugarNacimiento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var lugarNacimientoApi = new JavaScriptSerializer().Deserialize<LugarNacimientoModel>(data.Entity.ToString());

            return lugarNacimientoApi;
        }

        public async Task<bool> UpdateLugarNacimiento(LugarNacimientoModel lugarNacimiento)
        {
            string methodUrl = lugarNacimientoApiUrl + "/UpdateLugarNacimiento";
            HttpResponseMessage response = await client.PostAsJsonAsync(
                methodUrl, lugarNacimiento);
            response.EnsureSuccessStatusCode();

            dynamic data = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            var respuesta = Convert.ToBoolean(data.Response.ToString().ToLower());

            return respuesta;
        }

        #endregion
    }
}
