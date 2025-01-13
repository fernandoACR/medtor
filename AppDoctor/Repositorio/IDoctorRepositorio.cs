using System;
using System.Collections.Generic;
using System.Text;

namespace AppDoctor.Repositorio
{
    public interface IDoctorRepositorio
    {
        List<DoctorResponse> ObtenerDoctores();
        bool RegistrarDoctor(Doctor doctor);
    }
}
