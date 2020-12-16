using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestAsignatura
    {
        [TestMethod]
        public void PruebaParaValidarNombreAsignaturaVacio()
        {
            //AAA
            //Arrange
            string nombreAsignatura = "";
            //Act
            Asignatura asignatura = new Asignatura();
            asignatura.Nombre = nombreAsignatura;
            AsignaturaDomainService asignaturaDomainService = new AsignaturaDomainService();
            var resultado = asignaturaDomainService.RegistrarAsignatura(asignatura);
            //Assert
            Assert.AreEqual("Por favor ingresar un nombre de asignatura valido", resultado);
        }
    }
}
