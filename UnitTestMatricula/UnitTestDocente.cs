using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestDocente
    {
        [TestMethod]
        public void ValidarCampoNombreVacio()
        {
            //AAA

            //Arrange
            DocenteDomainService docenteDomainService = new DocenteDomainService();
            Docente docente = new Docente();
            docente.Nombre = "";
            docente.Edad = 20;
            docente.Sexo = "M";

            //Act
            var respuesta = docenteDomainService.RegistrarDocente(docente);

            //Assert
            Assert.AreEqual("Por favor ingresar un nombre valido",respuesta);
        }
        [TestMethod]
        public void ValidarEdadMenorA18()
        {
            //AAA

            //Arrange
            DocenteDomainService docenteDomainService = new DocenteDomainService();
            Docente docente = new Docente();
            docente.Nombre = "Test Vanguardia";
            docente.Edad = 14;
            docente.Sexo = "M";

            //Act
            var respuesta =  docenteDomainService.RegistrarDocente(docente);

            //Assert
            Assert.AreEqual("Edad es inválida, debe ser mayor a 18", respuesta);
        }

        [TestMethod]
        public void ValidarCampoSexoDelDocenteMayorA18()
        {
            //AAA

            //Arrange
            DocenteDomainService docenteDomainService = new DocenteDomainService();
            Docente docente = new Docente();
            docente.Nombre = "Test Vanguardia";
            docente.Edad = 20;
            docente.Sexo = "O";

            //Act
            var respuesta = docenteDomainService.RegistrarDocente(docente);

            //Assert
            Assert.AreEqual("El sexo es inválido", respuesta);
        }

    }
}
