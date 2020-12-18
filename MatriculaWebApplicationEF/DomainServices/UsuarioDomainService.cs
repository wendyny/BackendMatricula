using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class UsuarioDomainService
    {
        public string RegistrarUsuario(Usuario registroUsuario)
        {

           
            if (registroUsuario.PasswordUsuario == "")
            {
                return "Por favor ingresar una contraseña valida";
            }
         
            return null;
        }
        public string TieneAcceso(Usuario usuario)
        {
            var usuarioExiste = usuario == null;
            if (usuarioExiste)
            {
                return "El usuario o la contraseña no son válidos";
            }

            if (usuario.isActive == false)
            {
                return "El usuario no está activo";
            }

            return "sucess";
        }
    }
}
