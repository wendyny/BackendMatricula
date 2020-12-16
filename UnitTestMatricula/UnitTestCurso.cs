using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMatricula
{
    [TestClass]
    public class UnitTestCurso
    {
        [TestMethod]
        public void PruebaParaValidarNombreCursoVacio()
        {
            //AAA
            //Arrange
            string nombreCurso = "";
            //Act
            Curso curso = new Curso();
            curso.Nombre = nombreCurso;
            CursoDomainService cursoDomainService = new CursoDomainService();
            var resultado = cursoDomainService.RegistrarCurso(curso);
            //Assert
            Assert.AreEqual("Por favor ingrese un nombre valido para el curso", resultado);
        }
    }
}
