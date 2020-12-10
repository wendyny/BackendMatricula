using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class CursoAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly CursoDomainService _cursoDomainServices;

        public CursoAppService(UniversidadDataContext baseDatos, CursoDomainService cursoDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _cursoDomainServices = cursoDomainServiceaseDatos;
        }

        public async Task<string> RegistrarCurso(Curso registroCurso)
        {
            var curso = _baseDatos.Cursos.FirstOrDefault(q => q.Id == registroCurso.Id);

            var cursoExiste = curso != null;
            if (cursoExiste)
            {
                return "El curso ya existe";
            }

             var respuestaDomain = _cursoDomainServices.RegistrarCurso(registroCurso);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Cursos.Add(registroCurso);

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
