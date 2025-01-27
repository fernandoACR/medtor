using ControlMedicoApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMedicoApi.Business
{
    public interface IExpedienteBusiness
    {
        MemoryStream GetExpedienteByIdPaciente(PacienteModel paciente);
    }
}
