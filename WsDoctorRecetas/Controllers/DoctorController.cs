using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppDoctor.Negocio;
namespace WsDoctorRecetas.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DoctorController : Controller
    {
        readonly IDoctorNegocio doctorNegocio;
        public DoctorController()
        {
            this.doctorNegocio = new DoctorNegocio();
        }
       
        [HttpGet]
        public List<AppDoctor.DoctorResponse> ObtenerTodos()
        {
            return doctorNegocio.ObtenerDoctores();
        }

        [HttpPost]
        public bool RegistrarDoctor (AppDoctor.Doctor doctor)
        {
            return doctorNegocio.RegistrarDoctor(doctor);
        }
    }
}