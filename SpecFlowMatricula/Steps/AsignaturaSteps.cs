using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class AsignaturaSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Asignatura _asignatura = new Asignatura();
        private string _resultado;
        public AsignaturaSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
      
        [Given(@"el nombre de la asignatura es ""(.*)""")]
        public void GivenElNombreDeLaAsignaturaEs(string nombre)
        {
            nombre = "";
            _asignatura.Nombre = nombre;
        }

        [When(@"ingresar la asignatura")]
        public void WhenIngresarLaAsignatura()
        {
            AsignaturaDomainService asignaturaDomainService = new AsignaturaDomainService();
            _resultado = asignaturaDomainService.RegistrarAsignatura(_asignatura);
        }
        [Then(@"el resultado debe ser ""(.*)""")]
        public void ThenElResultadoDebeSer(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }

    }
}
