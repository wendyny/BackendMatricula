using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class DocenteDomainService
    {
        public string RegistrarDocente(Docente registroDocente)
        {

            if (registroDocente.Nombre == "")
            {
                return "Por favor ingresar un nombre valido";
            }
            var esEdadValida = registroDocente.Edad < 18;
            if (esEdadValida)
            {
                return "Edad es inválida, debe ser mayor a 18";
            }
            var esSexoValid = registroDocente.Sexo != "M" && registroDocente.Sexo != "F";
            if (esSexoValid)
            {
                return "El sexo es inválido";
            }

            return null;
           
        }
    }
}
