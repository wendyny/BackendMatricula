using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class AsignaturaDomainService
    {
        public string RegistrarAsignatura(Asignatura registroAsignatura)
        {

            if (registroAsignatura.Nombre == "")
            {
                return "Por favor ingresar un nombre de asignatura valido";
            }

            return null;
        }
    }
}
