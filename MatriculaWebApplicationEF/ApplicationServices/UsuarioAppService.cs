using MatriculaWebApplicationEF.DataContext;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatriculaWebApplicationEF.ApplicationServices
{
    public class UsuarioAppService
    {
        private readonly UniversidadDataContext _baseDatos;
        private readonly UsuarioDomainService _usuarioDomainService;

        public UsuarioAppService(UniversidadDataContext baseDatos, UsuarioDomainService usuarioDomainServiceaseDatos)
        {
            _baseDatos = baseDatos;
            _usuarioDomainService = usuarioDomainServiceaseDatos;
        }

        public async Task<string> RegistrarUsuario(Usuario registroUsuario)
        {
            var usuario = _baseDatos.Usuarios.FirstOrDefault(q => q.Id == registroUsuario.Id);

            var usuarioExiste = usuario != null;
            if (usuarioExiste)
            {
                return "El usuario ya existe";
            }

            var respuestaDomain = _usuarioDomainService.RegistrarUsuario(registroUsuario);

            var vieneConErrorEnElDomain = respuestaDomain != null;
            if (vieneConErrorEnElDomain)
            {
                return respuestaDomain;
            }


            _baseDatos.Usuarios.Add(registroUsuario);

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
