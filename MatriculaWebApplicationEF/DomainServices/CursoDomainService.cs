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
                return "Por favor ingrese un nombre valido para el curso";
            }

            return null;
        }
    }
}
