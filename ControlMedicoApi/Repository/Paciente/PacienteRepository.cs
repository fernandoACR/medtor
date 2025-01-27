using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlMedicoApi.Models;
namespace ControlMedicoApi.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddPaciente(Paciente paciente)
        {
            db.Pacientes.Add(paciente);
            db.SaveChanges();

            return paciente.IdPaciente; 
        }

        public bool UpdatePaciente(Paciente paciente)
        {
            Paciente pacienteDb = db.Pacientes.Where(x => x.IdPaciente == paciente.IdPaciente).FirstOrDefault();
            pacienteDb.PrimerNombre = paciente.PrimerNombre;
            pacienteDb.Telefono = paciente.Telefono;
            pacienteDb.Identificacion = paciente.Identificacion;
            pacienteDb.EstadoCivil = paciente.EstadoCivil;
            pacienteDb.Activo = paciente.Activo;
            pacienteDb.IdSuscripcion = paciente.IdSuscripcion;
            pacienteDb.CorreoElectronico = paciente.CorreoElectronico;
            pacienteDb.FechaNacimiento = paciente.FechaNacimiento;
            pacienteDb.Direccion = paciente.Direccion;
            pacienteDb.Escolaridad = paciente.Escolaridad;
            pacienteDb.Patologia = paciente.Patologia;
            pacienteDb.IdLugarNacimiento = paciente.IdLugarNacimiento;
            pacienteDb.NombreFamiliar = paciente.NombreFamiliar;
            pacienteDb.TelefonoFamiliar = paciente.TelefonoFamiliar;
            pacienteDb.Observaciones = paciente.Observaciones;
            pacienteDb.IdMedico = paciente.IdMedico;

            pacienteDb.SegundoNombre = paciente.SegundoNombre;
            pacienteDb.PrimerApellido = paciente.PrimerApellido;
            pacienteDb.SegundoApellido = paciente.SegundoApellido;
            pacienteDb.Genero = paciente.Genero;
            pacienteDb.MedicamentoActual = paciente.MedicamentoActual;
            pacienteDb.IdOcupacion = paciente.IdOcupacion;
            pacienteDb.Religion = paciente.Religion;
            pacienteDb.SeguroVida = paciente.SeguroVida;
            pacienteDb.TelefonoMovil = paciente.TelefonoMovil;

            db.SaveChanges();

            return true;
        }

        public List<PacienteModel> GetAllPacientes()
        {
            return (from c in db.Pacientes
                    select new PacienteModel
                    {
                        IdPaciente = c.IdPaciente,
                        EstadoCivil = c.EstadoCivil,
                        PrimerNombre = c.PrimerNombre,
                        Identificacion = c.Identificacion,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        IdSuscripcion = c.IdSuscripcion,
                        CorreoElectronico = c.CorreoElectronico,
                        FechaNacimiento = c.FechaNacimiento,
                        Direccion = c.Direccion,
                        Patologia = new PatologiaModel() { IdPatologia = c.Patologia == null ? 0 : (int)c.Patologia },
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = c.Escolaridad == null ? 0 : (int)c.Escolaridad },
                        LugarNacimiento = new LugarNacimientoModel() { IdLugarNacimiento = c.LugarNacimiento == null ? 0 : (int)c.IdLugarNacimiento },
                        NombreFamiliar = c.NombreFamiliar,
                        TelefonoFamiliar = c.TelefonoFamiliar,
                        Observaciones = c.Observaciones,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        SegundoNombre = c.SegundoNombre,
                        PrimerApellido = c.PrimerApellido,
                        SegundoApellido = c.SegundoApellido,
                        Genero = c.Genero,
                        MedicamentoActual = new MedicamentoModel() { IdMedicamento = c.MedicamentoActual == null ? 0 : (int)c.MedicamentoActual },
                        Ocupacion = new OcupacionModel() { IdOcupacion = c.Ocupacion == null ? 0 : (int)c.IdOcupacion },
                        Religion = c.Religion,
                        SeguroVida = c.SeguroVida != null ? (int)c.SeguroVida : 0,
                        TelefonoMovil = c.TelefonoMovil
                    }
                    ).ToList();
        }

        public PacienteModel GetPacienteById(PacienteModel paciente)
        {
            return (from c in db.Pacientes
                    select new PacienteModel
                    {
                        IdPaciente = c.IdPaciente,
                        EstadoCivil = c.EstadoCivil,
                        PrimerNombre = c.PrimerNombre,
                        Identificacion = c.Identificacion,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        IdSuscripcion = c.IdSuscripcion,
                        CorreoElectronico = c.CorreoElectronico,
                        FechaNacimiento = c.FechaNacimiento,
                        Direccion = c.Direccion,
                        Patologia = new PatologiaModel() { IdPatologia = c.Patologia == null ? 0 : (int)c.Patologia },
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = c.Escolaridad == null ? 0 : (int)c.Escolaridad },
                        LugarNacimiento = new LugarNacimientoModel() { IdLugarNacimiento = c.LugarNacimiento == null ? 0 : (int)c.IdLugarNacimiento },
                        NombreFamiliar = c.NombreFamiliar,
                        TelefonoFamiliar = c.TelefonoFamiliar,
                        Observaciones = c.Observaciones,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        SegundoNombre = c.SegundoNombre,
                        PrimerApellido = c.PrimerApellido,
                        SegundoApellido = c.SegundoApellido,
                        Genero = c.Genero,
                        MedicamentoActual = new MedicamentoModel() { IdMedicamento = c.MedicamentoActual == null ? 0 : (int)c.MedicamentoActual },
                        Ocupacion = new OcupacionModel() { IdOcupacion = c.Ocupacion == null ? 0 : (int)c.IdOcupacion },
                        Religion = c.Religion,
                        SeguroVida = c.SeguroVida != null ? (int)c.SeguroVida : 0,
                        TelefonoMovil = c.TelefonoMovil
                    }
                    ).Where(d => d.IdPaciente == paciente.IdPaciente).FirstOrDefault();
        }

        public List<PacienteModel> GetPacienteByIdMedico(PacienteModel paciente)
        {
            return (from c in db.Pacientes
                    select new PacienteModel
                    {
                        IdPaciente = c.IdPaciente,
                        EstadoCivil = c.EstadoCivil,
                        PrimerNombre = c.PrimerNombre,
                        Identificacion = c.Identificacion,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        IdSuscripcion = c.IdSuscripcion,
                        CorreoElectronico = c.CorreoElectronico,
                        FechaNacimiento = c.FechaNacimiento,
                        Direccion = c.Direccion,
                        Patologia = new PatologiaModel() { IdPatologia = c.Patologia == null ? 0 : (int)c.Patologia },
                        Escolaridad = new EscolaridadModel() { IdEscolaridad = c.Escolaridad == null ? 0 : (int)c.Escolaridad },
                        LugarNacimiento = new LugarNacimientoModel() { IdLugarNacimiento = c.LugarNacimiento == null ? 0 : (int)c.IdLugarNacimiento },
                        NombreFamiliar = c.NombreFamiliar,
                        TelefonoFamiliar = c.TelefonoFamiliar,
                        Observaciones = c.Observaciones,
                        Medico = new MedicoModel() { IdMedico = (int)c.IdMedico },
                        SegundoNombre = c.SegundoNombre,
                        PrimerApellido = c.PrimerApellido,
                        SegundoApellido = c.SegundoApellido,
                        Genero = c.Genero,
                        MedicamentoActual = new MedicamentoModel() { IdMedicamento = c.MedicamentoActual == null ? 0 : (int)c.MedicamentoActual },
                        Ocupacion = new OcupacionModel() { IdOcupacion = c.Ocupacion == null ? 0 : (int)c.IdOcupacion },
                        Religion = c.Religion,
                        SeguroVida = c.SeguroVida != null ? (int)c.SeguroVida : 0,
                        TelefonoMovil = c.TelefonoMovil
                    }
                    ).Where(x => x.Medico.IdMedico == paciente.Medico.IdMedico).ToList();
        }

        public int DeletePaciente(Paciente paciente)
        {
            var pacienteDb = db.Pacientes.Where(x => x.IdPaciente == paciente.IdPaciente).FirstOrDefault();
            db.Pacientes.Remove(pacienteDb);
            db.SaveChanges();

            return paciente.IdPaciente;
        }
    }
}