using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class AsignaturaAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly AsignaturaDomainService _asignaturaDomainServices;

        public AsignaturaAppService(UniversidadDataContext baseDatos, AsignaturaDomainService asignaturaDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _asignaturaDomainServices = asignaturaDomainServiceaseDatos;
        }

        public async Task<string> RegistrarAsignatura(Asignatura registroAsignatura)
        {
            var asignatura = _baseDatos.Asignaturas.FirstOrDefault(q => q.Id == registroAsignatura.Id);

            var asignaturaExiste = asignatura != null;
            if (asignaturaExiste)
            {
                return "La asignatura ya existe";
            }

            var respuestaDomain = _asignaturaDomainServices.RegistrarAsignatura(registroAsignatura);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Asignaturas.Add(registroAsignatura);

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
