using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestUsuario
    {
        [TestMethod]
        public void PruebaParaValidarNombreUsuarioVacio()
        {
            //AAA
            //Arrange
            string nombreUsuario = "";
            //Act
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = nombreUsuario;
            UsuarioDomainService usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.RegistrarUsuario(usuario);
            //Assert
            Assert.AreEqual("Por favor ingresar un nombre de usuario valido", resultado);
        }
        [TestMethod]
        public void PruebaParaValidarPasswordVacio()
        {
            //AAA
            //Arrange
            string password = "";
            //Act
            Usuario usuario = new Usuario();
            usuario.passwordUsuario = password;
            UsuarioDomainService usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.RegistrarUsuario(usuario);
            //Assert
            Assert.AreEqual("Por favor ingresar una contraseña valida", resultado);
        }
    }
}
