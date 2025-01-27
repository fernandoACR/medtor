using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Business
{
    public class DiagnosticoBusiness : IDiagnosticoBusiness
    {
        public readonly IDiagnosticoRepository diagnosticoRepository;
        public readonly IPacienteRepository pacienteRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IArchivoDiagnosticoRepository archivoDiagnosticoRepository;
        public readonly ICitaRepository citaRepository;

        public DiagnosticoBusiness(IDiagnosticoRepository diagnosticoRepository, IPacienteRepository pacienteRepository, IMedicoRepository medicoRepository, IArchivoDiagnosticoRepository archivoDiagnosticoRepository, ICitaRepository citaRepository)
        {
            this.diagnosticoRepository = diagnosticoRepository;
            this.pacienteRepository = pacienteRepository;
            this.medicoRepository = medicoRepository;
            this.archivoDiagnosticoRepository = archivoDiagnosticoRepository;
            this.citaRepository = citaRepository;
        }

        public int AddDiagnostico(DiagnosticoModel diagnostico)
        {
            Diagnostico diagnosticoDb = new Diagnostico();
            diagnosticoDb.IdDiagnostico = diagnostico.IdDiagnostico;
            diagnosticoDb.Descripcion = diagnostico.Descripcion;
            diagnosticoDb.IdPaciente = diagnostico.Paciente.IdPaciente;
            diagnosticoDb.IdMedico = diagnostico.Medico.IdMedico;
            diagnosticoDb.Peso = diagnostico.Peso;
            diagnosticoDb.Alergias = diagnostico.Alergias;
            diagnosticoDb.Altura = diagnostico.Altura;
            diagnosticoDb.Activo = 1;
            diagnosticoDb.FechaCreacion = DateTime.Now;
            diagnosticoDb.IdCita = diagnostico.Cita.IdCita;

            int idDiagnostico = diagnosticoRepository.AddDiagnostico(diagnosticoDb);

            if (idDiagnostico > 0 && diagnostico.ArchivosAdjuntos != null)
            {
                if(diagnostico.ArchivosAdjuntos.Count > 0)
                {
                    foreach(ArchivoDiagnosticoModel archivo in diagnostico.ArchivosAdjuntos)
                    {
                        archivoDiagnosticoRepository.AddArchivoDiagnostico(new ArchivoDiagnostico()
                        {
                            IdArchivoDiagnostico = 0,
                            IdDiagnostico = idDiagnostico,
                            IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                            Descripcion = archivo.Descripcion,
                            Codigo = Guid.NewGuid(),
                            Archivo = Convert.FromBase64String(archivo.Archivo),
                            ExtensionArchivo = archivo.ExtensionArchivo
                        });
                    }                    
                }                
            }

            diagnostico.Cita.EstatusCita.IdEstatusCita = (int)EstatusCitaEnum.CMP;

            citaRepository.UpdateCita(new Cita() {

                IdCita = diagnostico.Cita.IdCita,
                IdMedico = diagnostico.Cita.Medico.IdMedico,
                IdPaciente = diagnostico.Cita.Paciente.IdPaciente,
                FechaCitaDesde = diagnostico.Cita.FechaCitaDesde,
                FechaModificacion = DateTime.Now,
                Comentarios = diagnostico.Cita.Comentarios,
                Titulo = diagnostico.Cita.Titulo,
                Estatus = diagnostico.Cita.EstatusCita.IdEstatusCita,
                FechaCitaHasta = diagnostico.Cita.FechaCitaHasta,
                IdTipoCita = diagnostico.Cita.TipoCita.IdTipoCita
            });

            return idDiagnostico;
        }

        public bool UpdateDiagnostico(DiagnosticoModel diagnostico)
        {
            Diagnostico diagnosticoDb = new Diagnostico();
            diagnosticoDb.IdDiagnostico = diagnostico.IdDiagnostico;
            diagnosticoDb.IdDiagnostico = diagnostico.IdDiagnostico;
            diagnosticoDb.IdPaciente = diagnostico.Paciente.IdPaciente;
            diagnosticoDb.IdMedico = diagnostico.Medico.IdMedico;
            diagnosticoDb.Peso = diagnostico.Peso;
            diagnosticoDb.Alergias = diagnostico.Alergias;
            diagnosticoDb.Altura = diagnostico.Altura;
            diagnosticoDb.Activo = diagnostico.Activo;
            diagnosticoDb.FechaModificacion = DateTime.Now;
            diagnosticoDb.Descripcion = diagnostico.Descripcion;

            bool updateDiagnostico = diagnosticoRepository.UpdateDiagnostico(diagnosticoDb);

            if (updateDiagnostico)
            {
                List<ArchivoDiagnosticoModel> listaArchivosTotales = archivoDiagnosticoRepository.GetArchivoDiagnosticoByIdDiagnostico(new ArchivoDiagnosticoModel() { Diagnostico = diagnostico });
                if (diagnostico.ArchivosAdjuntos != null)
                {
                    //Verificar si se eliminaron archivos adjuntos                    
                    List<ArchivoDiagnosticoModel> listaArchivosDepurados = new List<ArchivoDiagnosticoModel>();

                    foreach (ArchivoDiagnosticoModel archivo in listaArchivosTotales)
                    {
                        if (!diagnostico.ArchivosAdjuntos.Exists(d => d.Codigo == archivo.Codigo && d.Codigo != Guid.Empty))
                        {
                            listaArchivosDepurados.Add(archivo);
                        }
                    }

                    //Elminar de BD los archivos eliminados
                    if (listaArchivosDepurados.Count > 0)
                    {
                        foreach (ArchivoDiagnosticoModel archivo in listaArchivosDepurados)
                        {
                            archivoDiagnosticoRepository.DeleteArchivoDiagnostico(new ArchivoDiagnostico()
                            {

                                IdArchivoDiagnostico = archivo.IdArchivoDiagnostico,
                                IdDiagnostico = archivo.Diagnostico.IdDiagnostico,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = archivo.Codigo,
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                Activo = archivo.Activo,
                                ExtensionArchivo = archivo.ExtensionArchivo

                            });
                        }
                    }

                    //Si el valor de diagnostico.ArchivosAdjuntos = NULL, quiere decir que se eliminaron todos los archivos adjuntos


                    //Agregamos solo los nuevos archivos, aquellos donde el Codigo sea igual a Guid.Empty, el resto no se modifican
                    if (diagnostico.ArchivosAdjuntos.Count > 0)
                    {
                        foreach (ArchivoDiagnosticoModel archivo in diagnostico.ArchivosAdjuntos.Where(x => x.Codigo == Guid.Empty))
                        {
                            archivoDiagnosticoRepository.AddArchivoDiagnostico(new ArchivoDiagnostico()
                            {
                                IdArchivoDiagnostico = 0,
                                IdDiagnostico = diagnostico.IdDiagnostico,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = Guid.NewGuid(),
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                ExtensionArchivo = archivo.ExtensionArchivo
                            });
                        }
                    }
                }
                else
                {
                    if(listaArchivosTotales.Count > 0)
                    {
                        foreach(ArchivoDiagnosticoModel archivo in listaArchivosTotales)
                        {
                            archivoDiagnosticoRepository.DeleteArchivoDiagnostico(new ArchivoDiagnostico()
                            {

                                IdArchivoDiagnostico = archivo.IdArchivoDiagnostico,
                                IdDiagnostico = archivo.Diagnostico.IdDiagnostico,
                                IdTipoArchivo = archivo.TipoArchivo.IdTipoArchivo,
                                Descripcion = archivo.Descripcion,
                                Codigo = archivo.Codigo,
                                Archivo = Convert.FromBase64String(archivo.Archivo),
                                Activo = archivo.Activo,
                                ExtensionArchivo = archivo.ExtensionArchivo

                            });
                        }
                    }
                }
            }

            return updateDiagnostico;
        }

        public List<DiagnosticoModel> GetAllDiagnosticos()
        {
            List<DiagnosticoModel> listDiagnosticos = new List<DiagnosticoModel>();
            listDiagnosticos = diagnosticoRepository.GetAllDiagnosticos();
            listDiagnosticos.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listDiagnosticos.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listDiagnosticos.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listDiagnosticos;
        }

        public DiagnosticoModel GetDiagnosticoById(DiagnosticoModel diagnostico)
        {
            diagnostico = diagnosticoRepository.GetDiagnosticoById(diagnostico);
            diagnostico.ArchivosAdjuntos = archivoDiagnosticoRepository.GetArchivoDiagnosticoByIdDiagnostico(new ArchivoDiagnosticoModel() { Diagnostico = diagnostico });

            return diagnostico;
        }

        public List<DiagnosticoModel> GetDiagnosticoByIdMedico(DiagnosticoModel diagnostico)
        {
            List<DiagnosticoModel> listDiagnosticos = new List<DiagnosticoModel>();
            listDiagnosticos = diagnosticoRepository.GetDiagnosticoByIdMedico(diagnostico);
            listDiagnosticos.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listDiagnosticos.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listDiagnosticos.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listDiagnosticos;
        }

        public List<DiagnosticoModel> GetDiagnosticoByIdPaciente(DiagnosticoModel diagnostico)
        {
            List<DiagnosticoModel> listDiagnosticos = new List<DiagnosticoModel>();
            listDiagnosticos = diagnosticoRepository.GetDiagnosticoByIdPaciente(diagnostico);
            listDiagnosticos.ForEach(x => x.Paciente = pacienteRepository.GetPacienteById(new PacienteModel() { IdPaciente = x.Paciente.IdPaciente }));
            listDiagnosticos.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listDiagnosticos.ForEach(x => x.ArchivosAdjuntos = archivoDiagnosticoRepository.GetArchivoDiagnosticoByIdDiagnostico(new ArchivoDiagnosticoModel() { Diagnostico = new DiagnosticoModel() { IdDiagnostico = x.IdDiagnostico } }));
            listDiagnosticos.ForEach(x => x.Paciente.NombreCompleto = x.Paciente.PrimerNombre + " " + x.Paciente.SegundoNombre + " " + x.Paciente.PrimerApellido + " " + x.Paciente.SegundoApellido);

            return listDiagnosticos;
        }
    }
}