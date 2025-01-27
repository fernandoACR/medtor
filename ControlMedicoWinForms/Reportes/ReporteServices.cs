using ControlMedicoWinForms.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ControlMedicoWinForms.Reportes
{
    public class ReporteServices
    {
        private static string reportesApiUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"] + "/Report";
        public static HttpClient client = new HttpClient();

        public ReporteServices()
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LoginModel.Token);
        }

        public string GetExpedienteByIdPaciente(PacienteModel paciente)
        {
            string methodUrl = reportesApiUrl + "/GetExpedienteByIdPaciente?idPaciente=" + paciente.IdPaciente;
            //HttpResponseMessage response = await client.GetAsync(
            //    methodUrl);
            //response.EnsureSuccessStatusCode();
            //Stream x = await response.Content.ReadAsStreamAsync();
            //StreamReader sr = new StreamReader(x);

            //var fileStream = File.Create(@"C:\Users\Luis Serrano\Documents");
            //x.Seek(0, SeekOrigin.Begin);
            //x.CopyTo(fileStream);
            //fileStream.Close();
            return methodUrl;
        }

        public string PrintRecetaByIdReceta(RecetaModel receta)
        {
            string methodUrl = reportesApiUrl + "/PrintRecetaByIdReceta?idReceta=" + receta.IdReceta;
            return methodUrl;
        }

        public string PrintCitasByFecha(DateTime fecha)
        {
            string methodUrl = reportesApiUrl + "/PrintCitasByFecha?fecha=" + fecha.Date.ToString("MM/dd/yyyy");
            return methodUrl;
        }

        public string PrintOrdenByIdOrden(OrdenModel orden)
        {
            string methodUrl = reportesApiUrl + "/PrintOrdenByIdOrden?idOrden=" + orden.IdOrden;
            return methodUrl;
        }

        public string PrintReporteByIdTipoReporteAndIdMedico(ConfiguracionReporteModel reporte)
        {
            reporte = new ConfiguracionReporteModel()
            {

                IdConfiguracionReporte = 1,
                Medico = new MedicoModel() { IdMedico = 5 },
                TipoReporte = new TipoReporteModel() { IdTipoReporte = 1 }
            };

            string methodUrl = reportesApiUrl + "/PrintReporteByIdTipoReporteAndIdMedico?idMedico=" + reporte.Medico.IdMedico+"&idTipoReporte="+reporte.TipoReporte.IdTipoReporte;
            return methodUrl;
        }
    }
}
