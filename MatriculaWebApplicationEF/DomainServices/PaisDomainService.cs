using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.DomainServices
{
    public class PaisDomainService
    {
        public string RegistrarPais(Pais registroPais)
        {

            if (registroPais.Nombre == "")
            {
                return "Por favor ingresar un nombre de pais valido";
            }

            return null;
        }

    }
}
