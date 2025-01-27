using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class OrdenRepository : IOrdenRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddOrden(Orden orden)
        {
            db.Ordens.Add(orden);
            db.SaveChanges();

            return orden.IdOrden;
        }

        public bool UpdateOrden(Orden orden)
        {
            Orden ordenDb = db.Ordens.Where(x => x.IdOrden == orden.IdOrden).FirstOrDefault();
            ordenDb.IdDiagnostico = orden.IdDiagnostico;
            ordenDb.PersonaEntrega = orden.PersonaEntrega;
            ordenDb.IdEspecimen = orden.IdEspecimen;
            ordenDb.IdMedicoEntrega = orden.IdMedicoEntrega;
            ordenDb.IdPaciente = orden.IdPaciente;
            ordenDb.IdMedicoRecepcion = orden.IdMedicoRecepcion;
            ordenDb.PersonaRecepcion = orden.PersonaRecepcion;
            ordenDb.Observaciones = orden.Observaciones;
            ordenDb.Pagado = orden.Pagado;
            ordenDb.Monto = orden.Monto;
            ordenDb.Estatus = orden.Estatus;
            ordenDb.FechaRecepcion = orden.FechaRecepcion;
            ordenDb.FechaEntregaOrigen = orden.FechaEntregaOrigen;
            ordenDb.FechaModificacion = orden.FechaModificacion;
            ordenDb.Activo = orden.Activo;
            ordenDb.CorreoPersonaRecepcion = orden.CorreoPersonaRecepcion;
            ordenDb.MovilPersonaRecepcion = orden.MovilPersonaRecepcion;
            ordenDb.IdSuscripcion = orden.IdSuscripcion;
            db.SaveChanges();

            return true;
        }

        public List<OrdenModel> GetAllOrdenes()
        {
            return (from c in db.Ordens
                    select new OrdenModel
                    {
                        IdOrden = c.IdOrden,
                        FechaRecepcion = c.FechaRecepcion,
                        FechaEntregaOrigen = c.FechaEntregaOrigen,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico },
                        PersonaEntrega = c.PersonaEntrega,
                        PersonaRecepcion = c.PersonaRecepcion,
                        Especimen = new EspecimenModel() { IdEspecimen = (int)c.IdEspecimen },
                        MedicoEntrega = new MedicoModel() { IdMedico = (int)c.IdMedicoEntrega },
                        MedicoRecepcion = new MedicoModel() { IdMedico = (int)c.IdMedicoRecepcion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Observaciones = c.Observaciones,
                        Pagado = c.Pagado,
                        Monto = c.Monto,
                        Estatus = new EstatusOrdenModel() { IdEstatusOrden = (int)c.Estatus },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion= c.FechaModificacion,
                        CorreoPersonaRecepcion = c.CorreoPersonaRecepcion,
                        MovilPersonaRecepcion = c.MovilPersonaRecepcion,
                        IdSuscripcion = c.IdSuscripcion
                    }
                    ).ToList();
        }

        public OrdenModel GetOrdenById(OrdenModel orden)
        {
            return (from c in db.Ordens
                    select new OrdenModel
                    {
                        IdOrden = c.IdOrden,
                        FechaRecepcion = c.FechaRecepcion,
                        FechaEntregaOrigen = c.FechaEntregaOrigen,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico },
                        PersonaEntrega = c.PersonaEntrega,
                        PersonaRecepcion = c.PersonaRecepcion,
                        Especimen = new EspecimenModel() { IdEspecimen = (int)c.IdEspecimen },
                        MedicoEntrega = new MedicoModel() { IdMedico = (int)c.IdMedicoEntrega },
                        MedicoRecepcion = new MedicoModel() { IdMedico = (int)c.IdMedicoRecepcion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Observaciones = c.Observaciones,
                        Pagado = c.Pagado,
                        Monto = c.Monto,
                        Estatus = new EstatusOrdenModel() { IdEstatusOrden = (int)c.Estatus },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        CorreoPersonaRecepcion = c.CorreoPersonaRecepcion,
                        MovilPersonaRecepcion = c.MovilPersonaRecepcion,
                        IdSuscripcion = c.IdSuscripcion
                    }
                    ).Where(d => d.IdOrden == orden.IdOrden).FirstOrDefault();
        }

        public List<OrdenModel> GetOrdenByIdMedicoEntrega(OrdenModel orden)
        {
            return (from c in db.Ordens
                    select new OrdenModel
                    {
                        IdOrden = c.IdOrden,
                        FechaRecepcion = c.FechaRecepcion,
                        FechaEntregaOrigen = c.FechaEntregaOrigen,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico },
                        PersonaEntrega = c.PersonaEntrega,
                        PersonaRecepcion = c.PersonaRecepcion,
                        Especimen = new EspecimenModel() { IdEspecimen = (int)c.IdEspecimen },
                        MedicoEntrega = new MedicoModel() { IdMedico = (int)c.IdMedicoEntrega },
                        MedicoRecepcion = new MedicoModel() { IdMedico = (int)c.IdMedicoRecepcion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Observaciones = c.Observaciones,
                        Pagado = c.Pagado,
                        Monto = c.Monto,
                        Estatus = new EstatusOrdenModel() { IdEstatusOrden = (int)c.Estatus },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        CorreoPersonaRecepcion = c.CorreoPersonaRecepcion,
                        MovilPersonaRecepcion = c.MovilPersonaRecepcion,
                        IdSuscripcion = c.IdSuscripcion
                    }
                    ).Where(d => d.MedicoEntrega.IdMedico == orden.MedicoEntrega.IdMedico).ToList();
        }

        public List<OrdenModel> GetOrdenByIdMedicoRecepcion(OrdenModel orden)
        {
            return (from c in db.Ordens
                    select new OrdenModel
                    {
                        IdOrden = c.IdOrden,
                        FechaRecepcion = c.FechaRecepcion,
                        FechaEntregaOrigen = c.FechaEntregaOrigen,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico },
                        PersonaEntrega = c.PersonaEntrega,
                        PersonaRecepcion = c.PersonaRecepcion,
                        Especimen = new EspecimenModel() { IdEspecimen = (int)c.IdEspecimen },
                        MedicoEntrega = new MedicoModel() { IdMedico = (int)c.IdMedicoEntrega },
                        MedicoRecepcion = new MedicoModel() { IdMedico = (int)c.IdMedicoRecepcion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Observaciones = c.Observaciones,
                        Pagado = c.Pagado,
                        Monto = c.Monto,
                        Estatus = new EstatusOrdenModel() { IdEstatusOrden = (int)c.Estatus },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        CorreoPersonaRecepcion = c.CorreoPersonaRecepcion,
                        MovilPersonaRecepcion = c.MovilPersonaRecepcion,
                        IdSuscripcion = c.IdSuscripcion
                    }
                    ).Where(d => d.MedicoRecepcion.IdMedico == orden.MedicoRecepcion.IdMedico).ToList();
        }

        public List<OrdenModel> GetOrdenByIdDiagnostico(OrdenModel orden)
        {
            return (from c in db.Ordens
                    select new OrdenModel
                    {
                        IdOrden = c.IdOrden,
                        FechaRecepcion = c.FechaRecepcion,
                        FechaEntregaOrigen = c.FechaEntregaOrigen,
                        Diagnostico = new DiagnosticoModel() { IdDiagnostico = (int)c.IdDiagnostico },
                        PersonaEntrega = c.PersonaEntrega,
                        PersonaRecepcion = c.PersonaRecepcion,
                        Especimen = new EspecimenModel() { IdEspecimen = (int)c.IdEspecimen },
                        MedicoEntrega = new MedicoModel() { IdMedico = (int)c.IdMedicoEntrega },
                        MedicoRecepcion = new MedicoModel() { IdMedico = (int)c.IdMedicoRecepcion },
                        Paciente = new PacienteModel() { IdPaciente = (int)c.IdPaciente },
                        Observaciones = c.Observaciones,
                        Pagado = c.Pagado,
                        Monto = c.Monto,
                        Estatus = new EstatusOrdenModel() { IdEstatusOrden = (int)c.Estatus },
                        Activo = c.Activo,
                        FechaCreacion = c.FechaCreacion,
                        FechaModificacion = c.FechaModificacion,
                        CorreoPersonaRecepcion = c.CorreoPersonaRecepcion,
                        MovilPersonaRecepcion = c.MovilPersonaRecepcion,
                        IdSuscripcion = c.IdSuscripcion
                    }
                    ).Where(d => d.Diagnostico.IdDiagnostico == orden.Diagnostico.IdDiagnostico).ToList();
        }
    }
}