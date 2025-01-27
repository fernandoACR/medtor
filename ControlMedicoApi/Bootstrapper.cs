using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity;
using ControlMedicoApi.Repository;
using ControlMedicoApi.Business;
using ControlMedicoApi.Models;
using System.Web;
using Unity.WebApi;
using System.Web.Http;
using Unity.Injection;

namespace ControlMedicoApi
{
    
    public static class Bootstrapper
  {    
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
        var container = new UnityContainer();
            
        //container.AddNewExtension<Interception>();
        // register all your components with the container here
        // it is NOT necessary to register your controllers

        // e.g. container.RegisterType<ITestService, TestService>();   

        

        container.RegisterType<ControlMedicoDBEntities>(new InjectionFactory(c =>
        {
            var context = (ControlMedicoDBEntities)HttpContext.Current.Items["__dbcontext"];

            if (context == null)
            {
                context = new ControlMedicoDBEntities();
                HttpContext.Current.Items["__dbcontext"] = context;
            }

            return context;
        }));
            
            container.RegisterType<IPacienteBusiness, PacienteBusiness>();
            container.RegisterType<IPacienteRepository, PacienteRepository>();

            container.RegisterType<IMedicoBusiness, MedicoBusiness>();
            container.RegisterType<IMedicoRepository, MedicoRepository>();

            container.RegisterType<IEspecialidadBusiness, EspecialidadBusiness>();
            container.RegisterType<IEspecialidadRepository, EspecialidadRepository>();

            container.RegisterType<IEspecimenRepository, EspecimenRepository>();
            container.RegisterType<IEspecimenBusiness, EspecimenBusiness>();

            container.RegisterType<IOrdenBusiness, OrdenBusiness>();
            container.RegisterType<IOrdenRepository, OrdenRepository>();

            container.RegisterType<IClienteBusiness, ClienteBusiness>();
            container.RegisterType<IClienteRepository, ClienteRepository>();

            container.RegisterType<ISuscripcionBusiness, SuscripcionBusiness>();
            container.RegisterType<ISuscripcionRepository, SuscripcionRepository>();

            container.RegisterType<IEstatusSuscripcionRepository, EstatusSuscripcionRepository>();
            container.RegisterType<IEstatusSuscripcionBusiness, EstatusSuscripcionBusiness>();

            container.RegisterType<ICitaBusiness, CitaBusiness>();
            container.RegisterType<ICitaRepository, CitaRepository>();

            container.RegisterType<IEstatusCitaBusiness, EstatusCitaBusiness>();
            container.RegisterType<IEstatusCitaRepository, EstatusCitaRepository>();

            container.RegisterType<IEscolaridadBusiness, EscolaridadBusiness>();
            container.RegisterType<IEscolaridadRepository, EscolaridadRepository>();

            container.RegisterType<IPatologiaRepository, PatologiaRepository>();
            container.RegisterType<IPatologiaBusiness, PatologiaBusiness>();

            container.RegisterType<IMedicamentoBusiness, MedicamentoBusiness>();
            container.RegisterType<IMedicamentoRepository, MedicamentoRepository>();

            container.RegisterType<IRecetaBusiness, RecetaBusiness>();
            container.RegisterType<IRecetaRepository, RecetaRepository>();

            container.RegisterType<IRecetaMedicamentoBusiness, RecetaMedicamentoBusiness>();
            container.RegisterType<IRecetaMedicamentoRepository, RecetaMedicamentoRepository>();

            container.RegisterType<ITipoCitaBusiness, TipoCitaBusiness>();
            container.RegisterType<ITipoCitaRepository, TipoCitaRepository>();

            container.RegisterType<IDiagnosticoBusiness, DiagnosticoBusiness>();
            container.RegisterType<IDiagnosticoRepository, DiagnosticoRepository>();

            container.RegisterType<IPacienteMedicoRepository, PacienteMedicoRepository>();
            container.RegisterType<IPacienteMedicoBusiness, PacienteMedicoBusiness>();

            container.RegisterType<IExpedienteBusiness, ExpedienteBusiness>();

            container.RegisterType<ITransaccionRepository, TransaccionRepository>();

            container.RegisterType<IHistoricoOrdenRepository, HistoricoOrdenRepository>();

            container.RegisterType<IOcupacionRepository, OcupacionRepository>();
            container.RegisterType<IOcupacionBusiness, OcupacionBusiness>();

            container.RegisterType<IArchivoPacienteRepository, ArchivoPacienteRepository>();

            container.RegisterType<ITipoArchivoBusiness, TipoArchivoBusiness>();
            container.RegisterType<ITipoArchivoRepository, TipoArchivoRepository>();

            container.RegisterType<IArchivoDiagnosticoRepository, ArchivoDiagnosticoRepository>();
            container.RegisterType<IArchivoOrdenRepository, ArchivoOrdenRepository>();

            container.RegisterType<INotificacionRepository, NotificacionRepository>();
            container.RegisterType<INotificacionBusiness, NotificacionBusiness>();

            container.RegisterType<ILugarNacimientoRepository, LugarNacimientoRepository>();
            container.RegisterType<ILugarNacimientoBusiness, LugarNacimientoBusiness>();

            container.RegisterType<IEstatusOrdenRepository, EstatusOrdenRepository>();

            container.RegisterType<IConfiguracionMedicoBusiness, ConfiguracionMedicoBusiness>();
            container.RegisterType<IConfiguracionMedicoRepository, ConfiguracionMedicoRepository>();

            container.RegisterType<IUsuarioRepository, UsuarioRepository>();

            container.RegisterType<IArchivoMedicoRepository, ArchivoMedicoRepository>();

            container.RegisterType<IConfiguracionReporteRepository, ConfiguracionReporteRepository>();
            container.RegisterType<ITipoReporteRepository, TipoReporteRepository>();

            container.RegisterType<IReporteBusiness, ReporteBusiness>();
            container.RegisterType<IConfiguracionReporteBusiness, ConfiguracionReporteBusiness>();

            container.RegisterType<ITipoReporteVariableRepository, TipoReporteVariableRepository>();

            RegisterTypes(container);

        return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
    }
}