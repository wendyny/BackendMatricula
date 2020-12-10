using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class CursoDomainService
    {
        public string RegistrarCurso(Curso registroCurso)
        {

            if (registroCurso.Nombre == "")
            {
                return "Por favor ingresar un nombre de curso valido";
            }

            return null;
        }
    }
}
