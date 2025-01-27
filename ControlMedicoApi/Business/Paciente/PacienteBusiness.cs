using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;

namespace ControlMedicoApi.Business
{
    public class PacienteBusiness : IPacienteBusiness
    {
        public readonly IPacienteRepository pacienteRepository;
        public readonly IEscolaridadRepository escolaridadRepository;
        public readonly IPatologiaRepository patologiaRepository;
        public readonly IPacienteMedicoRepository pacienteMedicoRepository;
        public readonly IMedicoRepository medicoRepository;
        public readonly IMedicamentoRepository medicamentoRepository;
        public readonly IOcupacionRepository ocupacionRepository;
        public readonly IArchivoPacienteRepository archivoPacienteRepository;
        public readonly ILugarNacimientoRepository lugarNacimientoRepository;

        public PacienteBusiness(IPacienteRepository pacienteRepository, IEscolaridadRepository escolaridadRepository, IPatologiaRepository patologiaRepository, IPacienteMedicoRepository pacienteMedicoRepository,
            IMedicoRepository medicoRepository, IMedicamentoRepository medicamentoRepository, IOcupacionRepository ocupacionRepository, IArchivoPacienteRepository archivoPacienteRepository,
            ILugarNacimientoRepository lugarNacimientoRepository)
        {
            this.pacienteRepository = pacienteRepository;
            this.escolaridadRepository = escolaridadRepository;
            this.patologiaRepository = patologiaRepository;
            this.pacienteMedicoRepository = pacienteMedicoRepository;
            this.medicoRepository = medicoRepository;
            this.medicamentoRepository = medicamentoRepository;
            this.ocupacionRepository = ocupacionRepository;
            this.archivoPacienteRepository = archivoPacienteRepository;
            this.lugarNacimientoRepository = lugarNacimientoRepository;
        }

        public int AddPaciente(PacienteModel paciente)
        {
            Paciente pacienteDb = new Paciente();
            pacienteDb.PrimerNombre = paciente.PrimerNombre;            
            pacienteDb.Identificacion = paciente.Identificacion;
            pacienteDb.EstadoCivil = paciente.EstadoCivil;
            pacienteDb.Telefono = paciente.Telefono;
            pacienteDb.Activo = 1;
            pacienteDb.IdSuscripcion = paciente.IdSuscripcion;
            pacienteDb.CorreoElectronico = paciente.CorreoElectronico;
            pacienteDb.FechaNacimiento = paciente.FechaNacimiento;
            pacienteDb.Direccion = paciente.Direccion;

            if(paciente.Escolaridad.IdEscolaridad > 0)
                pacienteDb.Escolaridad = paciente.Escolaridad.IdEscolaridad;

            if (paciente.Patologia.IdPatologia > 0)
                pacienteDb.Patologia = paciente.Patologia.IdPatologia;

            if (paciente.LugarNacimiento.IdLugarNacimiento > 0)
                pacienteDb.IdLugarNacimiento = paciente.LugarNacimiento.IdLugarNacimiento;
            
            pacienteDb.NombreFamiliar = paciente.NombreFamiliar;
            pacienteDb.TelefonoFamiliar = paciente.TelefonoFamiliar;
            pacienteDb.Observaciones = paciente.Observaciones;
            pacienteDb.IdMedico = paciente.Medico.IdMedico;

            pacienteDb.SegundoNombre = paciente.SegundoNombre;
            pacienteDb.PrimerApellido = paciente.PrimerApellido;
            pacienteDb.SegundoApellido = paciente.SegundoApellido;
            pacienteDb.Genero = paciente.Genero;

            if (paciente.MedicamentoActual.IdMedicamento > 0)
                pacienteDb.MedicamentoActual = paciente.MedicamentoActual.IdMedicamento;

            if (paciente.Ocupacion.IdOcupacion > 0)
                pacienteDb.IdOcupacion = paciente.Ocupacion.IdOcupacion;

            pacienteDb.Religion = paciente.Religion;
            pacienteDb.SeguroVida = paciente.SeguroVida;
            pacienteDb.TelefonoMovil = paciente.TelefonoMovil;

            int idPaciente = pacienteRepository.AddPaciente(pacienteDb);

            if(paciente.Foto != null)
            {
                archivoPacienteRepository.AddArchivoPaciente(new ArchivoPaciente()
                {
                    IdArchivoPaciente = 0,
                    IdPaciente = idPaciente,
                    IdTipoArchivo = paciente.Foto.TipoArchivo.IdTipoArchivo,
                    Descripcion = paciente.Foto.Descripcion,
                    Codigo = Guid.NewGuid(),
                    Archivo = Convert.FromBase64String(paciente.Foto.Archivo),
                    ExtensionArchivo = paciente.Foto.ExtensionArchivo
                });
            }

            return idPaciente;
        }

        public bool UpdatePaciente(PacienteModel paciente)
        {
            Paciente pacienteDb = new Paciente();
            pacienteDb.IdPaciente = paciente.IdPaciente;
            pacienteDb.PrimerNombre = paciente.PrimerNombre;
            pacienteDb.Identificacion = paciente.Identificacion;
            pacienteDb.EstadoCivil = paciente.EstadoCivil;
            pacienteDb.Telefono = paciente.Telefono;
            pacienteDb.Activo = paciente.Activo;
            pacienteDb.IdSuscripcion = paciente.IdSuscripcion;
            pacienteDb.CorreoElectronico = paciente.CorreoElectronico;
            pacienteDb.FechaNacimiento = paciente.FechaNacimiento;
            pacienteDb.Direccion = paciente.Direccion;

            if (paciente.Escolaridad.IdEscolaridad > 0)
                pacienteDb.Escolaridad = paciente.Escolaridad.IdEscolaridad;

            if (paciente.Patologia.IdPatologia > 0)
                pacienteDb.Patologia = paciente.Patologia.IdPatologia;

            if (paciente.LugarNacimiento.IdLugarNacimiento > 0)
                pacienteDb.IdLugarNacimiento = paciente.LugarNacimiento.IdLugarNacimiento;

            pacienteDb.NombreFamiliar = paciente.NombreFamiliar;
            pacienteDb.TelefonoFamiliar = paciente.TelefonoFamiliar;
            pacienteDb.Observaciones = paciente.Observaciones;
            pacienteDb.IdMedico = paciente.Medico.IdMedico;

            pacienteDb.SegundoNombre = paciente.SegundoNombre;
            pacienteDb.PrimerApellido = paciente.PrimerApellido;
            pacienteDb.SegundoApellido = paciente.SegundoApellido;
            pacienteDb.Genero = paciente.Genero;

            if (paciente.MedicamentoActual.IdMedicamento > 0)
                pacienteDb.MedicamentoActual = paciente.MedicamentoActual.IdMedicamento;

            if (paciente.Ocupacion.IdOcupacion > 0)
                pacienteDb.IdOcupacion = paciente.Ocupacion.IdOcupacion;

            pacienteDb.Religion = paciente.Religion;
            pacienteDb.SeguroVida = paciente.SeguroVida;
            pacienteDb.TelefonoMovil = paciente.TelefonoMovil;

            if (paciente.Foto != null)
            {
                if (paciente.Foto.IdArchivoPaciente > 0)
                {
                    archivoPacienteRepository.UpdateArchivoPaciente(new ArchivoPaciente()
                    {
                        IdArchivoPaciente = paciente.Foto.IdArchivoPaciente,
                        IdPaciente = paciente.IdPaciente,
                        IdTipoArchivo = paciente.Foto.TipoArchivo.IdTipoArchivo,
                        Descripcion = paciente.Foto.Descripcion,
                        Codigo = paciente.Foto.Codigo,
                        Archivo = Convert.FromBase64String(paciente.Foto.Archivo),
                        ExtensionArchivo = paciente.Foto.ExtensionArchivo
                    });
                }
                else
                {
                    archivoPacienteRepository.AddArchivoPaciente(new ArchivoPaciente()
                    {
                        IdArchivoPaciente = paciente.Foto.IdArchivoPaciente,
                        IdPaciente = paciente.IdPaciente,
                        IdTipoArchivo = paciente.Foto.TipoArchivo.IdTipoArchivo,
                        Descripcion = paciente.Foto.Descripcion,
                        Codigo = Guid.NewGuid(),
                        Archivo = Convert.FromBase64String(paciente.Foto.Archivo),
                        ExtensionArchivo = paciente.Foto.ExtensionArchivo,
                        Activo = 1
                    });
                }
            }

            return pacienteRepository.UpdatePaciente(pacienteDb);
        }

        public List<PacienteModel> GetAllPacientes()
        {
            List<PacienteModel> listPacientes = new List<PacienteModel>();

            listPacientes = pacienteRepository.GetAllPacientes();
            listPacientes.ForEach(x =>x.Escolaridad = escolaridadRepository.GetEscolaridadById(new EscolaridadModel() { IdEscolaridad = x.Escolaridad.IdEscolaridad }));
            listPacientes.ForEach(x => x.Patologia = patologiaRepository.GetPatologiaById(new PatologiaModel() { IdPatologia = x.Patologia.IdPatologia }));
            listPacientes.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listPacientes.ForEach(x => x.MedicamentoActual = medicamentoRepository.GetMedicamentoById(new MedicamentoModel() { IdMedicamento = x.MedicamentoActual.IdMedicamento }));
            listPacientes.ForEach(x => x.Ocupacion = ocupacionRepository.GetOcupacionById(new OcupacionModel() { IdOcupacion = x.Ocupacion.IdOcupacion }));
            listPacientes.ForEach(x => x.NombreCompleto = x.PrimerNombre + " " + x.SegundoNombre + " " + x.PrimerApellido + " " + x.SegundoApellido);
            listPacientes.ForEach(x => x.LugarNacimiento = lugarNacimientoRepository.GetLugarNacimientoById(new LugarNacimientoModel() { IdLugarNacimiento = x.LugarNacimiento.IdLugarNacimiento }));

            return listPacientes;
        }

        public PacienteModel GetPacienteById(PacienteModel paciente)
        {
            paciente = pacienteRepository.GetPacienteById(paciente);
            paciente.Foto = archivoPacienteRepository.GetArchivoPacienteByIdPaciente(new ArchivoPacienteModel() { Paciente = paciente });
            paciente.NombreCompleto = paciente.PrimerNombre + " " + paciente.SegundoNombre + " " + paciente.PrimerApellido + " " + paciente.SegundoApellido;

            return paciente;
        }

        public List<PacienteModel> GetPacienteByIdMedico(PacienteModel paciente)
        {
            List<PacienteModel> listPacientes = new List<PacienteModel>();

            listPacientes = pacienteRepository.GetPacienteByIdMedico(paciente);
            listPacientes.ForEach(x => x.Escolaridad = escolaridadRepository.GetEscolaridadById(new EscolaridadModel() { IdEscolaridad = x.Escolaridad.IdEscolaridad }));
            listPacientes.ForEach(x => x.Patologia = patologiaRepository.GetPatologiaById(new PatologiaModel() { IdPatologia = x.Patologia.IdPatologia }));
            listPacientes.ForEach(x => x.Medico = medicoRepository.GetMedicoById(new MedicoModel() { IdMedico = x.Medico.IdMedico }));
            listPacientes.ForEach(x => x.MedicamentoActual = medicamentoRepository.GetMedicamentoById(new MedicamentoModel() { IdMedicamento = x.MedicamentoActual.IdMedicamento }));
            listPacientes.ForEach(x => x.Ocupacion = ocupacionRepository.GetOcupacionById(new OcupacionModel() { IdOcupacion = x.Ocupacion.IdOcupacion }));
            listPacientes.ForEach(x => x.NombreCompleto = x.PrimerNombre.Trim() + " " + x.SegundoNombre.Trim() + " " + x.PrimerApellido.Trim() + " " + x.SegundoApellido.Trim());
            listPacientes.ForEach(x => x.LugarNacimiento = lugarNacimientoRepository.GetLugarNacimientoById(new LugarNacimientoModel() { IdLugarNacimiento = x.LugarNacimiento.IdLugarNacimiento }));

            return listPacientes;
        }

        public int DeletePaciente (PacienteModel paciente)
        {
            return pacienteRepository.DeletePaciente(new Paciente() { IdPaciente = paciente.IdPaciente });
        }
    }
}