using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMedicoApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public int AddCliente(Cliente cliente)
        {
            db.Clientes.Add(cliente);
            db.SaveChanges();

            return cliente.IdCliente;
        }

        public bool UpdateCliente(Cliente cliente)
        {
            Cliente clienteDb = db.Clientes.Where(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();
            clienteDb.Nombre = cliente.Nombre;
            clienteDb.Telefono = cliente.Telefono;
            clienteDb.Identificacion = cliente.Identificacion;
            clienteDb.Direccion = cliente.Direccion;
            clienteDb.Activo = cliente.Activo;
            db.SaveChanges();

            return true;
        }

        public List<ClienteModel> GetAllClientes()
        {
            return (from c in db.Clientes
                    select new ClienteModel
                    {
                        IdCliente = c.IdCliente,
                        Nombre = c.Nombre,
                        Identificacion = c.Identificacion,
                        Telefono = c.Telefono,
                        Activo = c.Activo,
                        Direccion = c.Direccion
                    }
                    ).ToList();
        }

        public ClienteModel GetClienteById(ClienteModel cliente)
        {
            return (from c in db.Clientes
                    select new ClienteModel
                    {
                        IdCliente = c.IdCliente,
                        Direccion = c.Direccion,
                        Nombre = c.Nombre,
                        Identificacion = c.Identificacion,
                        Telefono = c.Telefono,
                        Activo = c.Activo
                    }
                    ).Where(d => d.IdCliente == cliente.IdCliente).FirstOrDefault();
        }
    }
}