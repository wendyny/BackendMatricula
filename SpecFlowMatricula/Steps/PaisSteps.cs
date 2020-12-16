using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class PaisSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private Pais _pais = new Pais();
        private string _resultado;
  
        public PaisSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"el nombre del pais es ""(.*)""")]
        public void GivenElNombreDelPaisEs(string nombre)
        {
            nombre = "";
            _pais.Nombre = nombre;
        }
        
        [When(@"ingresa el nombre del pais")]
        public void WhenIngresaElNombreDelPais()
        {
            PaisDomainService paisDomainService = new PaisDomainService();
            _resultado = paisDomainService.RegistrarPais(_pais);
        }
        
        [Then(@"la respuesta debe ser ""(.*)""")]
        public void ThenLaRespuestaDebeSer(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }
    }
}
