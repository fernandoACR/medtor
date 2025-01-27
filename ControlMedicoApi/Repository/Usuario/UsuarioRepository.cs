using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControlMedicoApi.Models;
namespace ControlMedicoApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ControlMedicoDBEntities db = new ControlMedicoDBEntities();

        public UsuarioModel GetUsuarioByIdMedico(MedicoModel medico)
        {
            return (from c in db.AspNetUsers
                    select new UsuarioModel
                    {
                        Id = c.Id,
                        Correo = c.Email,
                        PasswordHash = c.PasswordHash,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico == null ? 0 : (int)c.IdMedico }
                    }
                    ).Where(x => x.Medico.IdMedico == medico.IdMedico).FirstOrDefault();
        }

        public UsuarioModel GetUsuarioByEmail(UsuarioModel usuario)
        {
            return (from c in db.AspNetUsers
                    select new UsuarioModel
                    {
                        Id = c.Id,
                        Correo = c.Email,
                        PasswordHash = c.PasswordHash,
                        Medico = new MedicoModel() { IdMedico = c.IdMedico == null ? 0 : (int)c.IdMedico }
                    }
                    ).Where(x => x.Correo == usuario.Correo).FirstOrDefault();
        }
    }
}