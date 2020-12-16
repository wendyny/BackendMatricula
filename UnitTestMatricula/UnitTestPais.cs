using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestPais
    {
        [TestMethod]
        public void PruebaParaValidarNombrePaisVacio()
        {
            //AAA
            //Arrange
            string nombrePais = "";
            //Act
            Pais pais = new Pais();
            pais.Nombre = nombrePais;
            PaisDomainService paisDomainService = new PaisDomainService();
            var resultado = paisDomainService.RegistrarPais(pais);
            //Assert
            Assert.AreEqual("Por favor ingresar un nombre de pais valido", resultado);
        }
    }
}
