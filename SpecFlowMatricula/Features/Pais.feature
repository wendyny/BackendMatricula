Feature: Registrar un pais nuevo

Scenario: Validar el campo de nombre vacio
	Given el nombre del pais es ""
	When ingresa el nombre del pais
	Then la respuesta debe ser "Por favor ingresar un nombre de pais valido"