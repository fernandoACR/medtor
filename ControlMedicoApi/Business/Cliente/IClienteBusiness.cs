using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IClienteBusiness
    {
        int AddCliente(ClienteModel cliente);
        bool UpdateCliente(ClienteModel cliente);
        List<ClienteModel> GetAllClientes();
        ClienteModel GetClienteById(ClienteModel cliente);
    }
}
