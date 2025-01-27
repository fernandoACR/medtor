using ControlMedicoApi.Models;
using ControlMedicoApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ControlMedicoApi.Models.UtlilityModel;

namespace ControlMedicoApi.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        public readonly IClienteRepository clienteRepository;
        public readonly ISuscripcionRepository suscripcionRepository;
        public readonly ITransaccionRepository transaccionRepository;

        public ClienteBusiness(IClienteRepository clienteRepository, ISuscripcionRepository suscripcionRepository, ITransaccionRepository transaccionRepository)
        {
            this.clienteRepository = clienteRepository;
            this.suscripcionRepository = suscripcionRepository;
            this.transaccionRepository = transaccionRepository;
        }

        public int AddCliente(ClienteModel cliente)
        {
            Cliente clienteDb = new Cliente();
            clienteDb.Nombre = cliente.Nombre;
            clienteDb.Identificacion = cliente.Identificacion;
            clienteDb.Direccion = cliente.Direccion;
            clienteDb.Telefono = cliente.Telefono;
            clienteDb.Activo = 1;

            int idCliente = clienteRepository.AddCliente(clienteDb);

            if (idCliente > 0)
            {
                decimal saldo = cliente.Suscripcion.Transaccion.Monto - cliente.Suscripcion.Transaccion.MontoPagado;
                int idSuscripcion = suscripcionRepository.AddSuscripcion(new Suscripcion()
                {
                    IdSuscriptor = cliente.Suscripcion.IdSuscriptor,
                    IdCliente = idCliente,
                    MaxUsuarios = cliente.Suscripcion.MaxUsuarios,
                    FechaInicio = cliente.Suscripcion.FechaInicio,
                    FechaFin = cliente.Suscripcion.FechaFin,
                    Estatus = saldo > 0 ? (int)EstatusSuscripEnum.PAP : saldo <= 0 ? (int)EstatusSuscripEnum.PAG : saldo > cliente.Suscripcion.Transaccion.Monto ? (int)EstatusSuscripEnum.DEU : (int)EstatusSuscripEnum.POP,
                    Activo = cliente.Suscripcion.Activo
                });

                if(idSuscripcion > 0 )
                {
                    transaccionRepository.AddTransaccion(new Transaccion()
                    {
                        IdTipoTransaccion = (int)TipoTransaccionEnum.SUS,
                        IdOperacionContable = cliente.Suscripcion.Transaccion.NumReferencia != "" ? (int)OperacionContableEnum.SUMA : (int)OperacionContableEnum.RESTA,
                        Fecha = DateTime.Now,
                        IdGenerado = idSuscripcion,
                        Monto = cliente.Suscripcion.Transaccion.Monto,
                        NumReferencia = cliente.Suscripcion.Transaccion.NumReferencia,
                        Observaciones = cliente.Suscripcion.Transaccion.Observaciones,
                        Estatus = 1,
                        Saldo = saldo,
                        MontoPagado = cliente.Suscripcion.Transaccion.MontoPagado
                    });
                }
            }

            return idCliente;
        }

        public bool UpdateCliente(ClienteModel cliente)
        {
            Cliente clienteDb = new Cliente();
            clienteDb.IdCliente = cliente.IdCliente;
            clienteDb.Nombre = cliente.Nombre;
            clienteDb.Identificacion = cliente.Identificacion;
            clienteDb.Direccion = cliente.Direccion;
            clienteDb.Telefono = cliente.Telefono;
            clienteDb.Activo = cliente.Activo;

            return clienteRepository.UpdateCliente(clienteDb);
        }

        public List<ClienteModel> GetAllClientes()
        {
            List<ClienteModel> listClientes = clienteRepository.GetAllClientes();
            listClientes.ForEach(x => x.Suscripcion = suscripcionRepository.GetSuscripcionByIdCliente(new SuscripcionModel() { Cliente = new ClienteModel() { IdCliente = x.IdCliente } }));
            return listClientes;
        }

        public ClienteModel GetClienteById(ClienteModel cliente)
        {
            return clienteRepository.GetClienteById(cliente);
        }
    }
}