using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class PaisAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly PaisDomainService _paisDomainServices;

        public PaisAppService(UniversidadDataContext baseDatos, PaisDomainService paisDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _paisDomainServices = paisDomainServiceaseDatos;
        }

        public async Task<string> RegistrarPais(Pais paisRequest)
        {
            var pais = _baseDatos.Paises.FirstOrDefault(q => q.Id == paisRequest.Id);

            var paisExiste = pais != null;
            if (paisExiste)
            {
                return "El pais ya existe";
            }
            var respuestaDomain = _paisDomainServices.RegistrarPais(paisRequest);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }

            _baseDatos.Paises.Add(paisRequest);

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
