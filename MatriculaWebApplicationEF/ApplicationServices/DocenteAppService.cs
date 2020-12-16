using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class DocenteAppService 
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly DocenteDomainService _docenteDomainServices;

        public DocenteAppService(UniversidadDataContext baseDatos, DocenteDomainService docenteDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _docenteDomainServices = docenteDomainServiceaseDatos;
        }

        public async Task<string> RegistrarDocente(Docente registroDocente)
        {
            var docente = _baseDatos.Docentes.FirstOrDefault(q => q.Id == registroDocente.Id);

            var docenteExiste = docente != null;
            if (docenteExiste)
            {
                return "El docente ya existe";
            }

            var respuestaDomain = _docenteDomainServices.RegistrarDocente(registroDocente);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Docentes.Add(registroDocente);

            try
            {
                await _baseDatos.SaveChangesAsync();
                return null;
            }
            catch (Exception)
            {

                return "Oops! hubo un problema al guardar en la base de datos";
            }

        }
    }
}
