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

            if (registroUsuario.NombreUsuario == "")
            {
                return "Por favor ingresar un nombre de usuario valido";
            }
            if (registroUsuario.passwordUsuario == "")
            {
                return "Por favor ingresar una contraseña valida";
            }
            return null;
        }
    }
}
