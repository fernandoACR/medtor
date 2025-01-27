using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Repository
{
    public interface ITransaccionRepository
    {
        int AddTransaccion(Transaccion transaccion);
        bool UpdateTransaccion(Transaccion transaccion);
        List<TransaccionModel> GetAllTransaccions();
        TransaccionModel GetTransaccionById(TransaccionModel transaccion);
    }
}
