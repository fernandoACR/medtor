using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface IClienteRepository
    {
        int AddCliente(Cliente cliente);
        bool UpdateCliente(Cliente cliente);
        List<ClienteModel> GetAllClientes();
        ClienteModel GetClienteById(ClienteModel cliente);
    }
}
