using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;


namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class EstudianteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        EstudianteDomainService estudianteDomainService = new EstudianteDomainService();
        private Estudiante _estudiante = new Estudiante();
        private string _resultado;

        public EstudianteSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"la edad del estudiante es (.*)")]
        public void GivenLaEdadDelEstudianteEs(int edad)
        {
            edad = 15;
            _estudiante.Edad = edad;
        }
        
        [Given(@"el genero del estudiante es ""(.*)""")]
        public void GivenElGeneroDelEstudianteEs(string genero)
        {
            genero = "O";
            _estudiante.Sexo = genero;
        }
        
        [When(@"ingresar edad del estudiante")]
        public void WhenIngresarEdadDelEstudiante()
        {
            _estudiante.Nombre = "Test Vanguardia";
            _estudiante.Edad = 14;
            _estudiante.Sexo = "M";

          _resultado = estudianteDomainService.RegistrarEstudiante(_estudiante);
        }
        
        [When(@"ingresar genero del estudiante")]
        public void WhenIngresarGeneroDelEstudiante()
        {
            _estudiante.Nombre = "Test Vanguardia";
            _estudiante.Edad = 20;
            _estudiante.Sexo = "O";

            _resultado = estudianteDomainService.RegistrarEstudiante(_estudiante);
        }
        
        [Then(@"muestra el resultado ""(.*)""")]
        public void ThenMuestraElResultado(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }
    }
}
