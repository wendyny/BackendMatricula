using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestUsuario
    {
       
        [TestMethod]
        public void PruebaParaValidarPasswordVacio()
        {
            //AAA
            //Arrange
            string password = "";
            //Act
            Usuario usuario = new Usuario();
            usuario.PasswordUsuario = password;
            UsuarioDomainService usuarioDomainService = new UsuarioDomainService();
            var resultado = usuarioDomainService.RegistrarUsuario(usuario);
            //Assert
            Assert.AreEqual("Por favor ingresar una contraseña valida", resultado);
        }
    }
}
