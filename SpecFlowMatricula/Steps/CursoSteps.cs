using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class CursoSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Curso _curso = new Curso();
        private string _resultado;
        public CursoSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"el nombre es ""(.*)""")]
        public void GivenElNombreEs(string nombre)
        {
            nombre = "";
            _curso.Nombre = nombre;
        }
        
        [When(@"se ingresa el nombre")]
        public void WhenSeIngresaElNombre()
        {
            CursoDomainService cursoDomainService = new CursoDomainService();
            _resultado = cursoDomainService.RegistrarCurso(_curso);
        }
        
        [Then(@"debe mostrar ""(.*)""")]
        public void ThenDebeMostrar(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }
    }
}
