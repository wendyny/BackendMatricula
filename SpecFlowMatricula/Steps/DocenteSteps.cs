using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class RegistrarUnNuevoDocenteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        DocenteDomainService docenteDomainService = new DocenteDomainService();
        private Docente _docente = new Docente();
        private string _resultado;

        public RegistrarUnNuevoDocenteSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"el nombre del docente es ""(.*)""")]
        public void GivenElNombreDelDocenteEs(string nombre)
        {
            nombre = "";
            _docente.Nombre = nombre;
        }
        [Given(@"la edad del docente es (.*)")]
        public void GivenLaEdadDelDocenteEs(int edad)
        {
            edad = 15;
            _docente.Edad = edad;
        }

        
        
        [Given(@"el genero del docente es ""(.*)""")]
        public void GivenElGeneroDelDocenteEs(string genero)
        {
            genero = "O";
            _docente.Sexo = genero;
        }
        
        [When(@"ingresar al docente")]
        public void WhenIngresarAlDocente()
        {
           _docente.Edad = 20;
           _docente.Sexo = "M";
           _resultado = docenteDomainService.RegistrarDocente(_docente);
        }

        [When(@"ingresar edad")]
        public void WhenIngresarEdad()
        {
           
            _docente.Nombre = "Test Vanguardia";
            _docente.Edad = 14;
            _docente.Sexo = "M";

            //Act
            _resultado = docenteDomainService.RegistrarDocente(_docente);

        }

        [When(@"ingresar genero")]
        public void WhenIngresarGenero()
        {
            _docente.Edad = 20;
            _docente.Sexo = "O";
            _resultado = docenteDomainService.RegistrarDocente(_docente);
        }
        
        [Then(@"el resultado es ""(.*)""")]
        public void ThenElResultadoEs(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }
    }
}
