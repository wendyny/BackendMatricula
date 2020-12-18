using System;
using TechTalk.SpecFlow;
using FluentAssertions;
using MatriculaWebApplicationEF.DomainServices;
using MatriculaWebApplicationEF.Models;

namespace SpecFlowMatricula.Steps
{
    [Binding]
    public sealed class UsuarioSteps
    {
        private readonly ScenarioContext _scenarioContext;
        UsuarioDomainService usuarioDomainService = new UsuarioDomainService();
        private Usuario _usuario = new Usuario();
        private string _resultado;
        
        public UsuarioSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"el nombre del usuario es ""(.*)""")]
        
        
        [Given(@"el password del usuario es ""(.*)""")]
        public void GivenElPasswordDelUsuarioEs(string password)
        {
            password = "";
            _usuario.PasswordUsuario = password;
        }
        
        [When(@"ingresar el usuario")]
        public void WhenIngresarElUsuario()
        {
           
            _resultado = usuarioDomainService.RegistrarUsuario(_usuario);
        }
        
        [When(@"ingresar el password")]
        public void WhenIngresarElPassword()
        {
           
            _resultado = usuarioDomainService.RegistrarUsuario(_usuario);
        }
        
        [Then(@"debe mostrar  ""(.*)""")]
        public void ThenDebeMostrar(string respuesta)
        {
            _resultado.Should().Be(respuesta);
        }
    }
}
