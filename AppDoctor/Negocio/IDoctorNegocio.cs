using System;
using System.Collections.Generic;
using System.Text;

namespace AppDoctor.Negocio
{
    public interface IDoctorNegocio
    {
        List<DoctorResponse> ObtenerDoctores();
        bool RegistrarDoctor(Doctor doctor);
    }
}
