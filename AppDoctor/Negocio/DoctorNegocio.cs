using System;
using System.Collections.Generic;
using System.Text;
using AppDoctor.Repositorio;

namespace AppDoctor.Negocio
{
    public class DoctorNegocio : IDoctorNegocio
    {
        private readonly IDoctorRepositorio doctorRepositorio;

        public DoctorNegocio()
        {
            this.doctorRepositorio = new DoctorRepositorio();
        }
      
        public List<DoctorResponse> ObtenerDoctores()
        {
            return doctorRepositorio.ObtenerDoctores();
        }

        public bool RegistrarDoctor(Doctor doctor)
        {
            return doctorRepositorio.RegistrarDoctor(doctor);
        }
    }
}
