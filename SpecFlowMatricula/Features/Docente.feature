Feature: Registrar un nuevo docente

Scenario: Ingresar el nombre del docente vacio
	Given el nombre del docente es ""
	When  ingresar al docente
	Then el resultado es "Por favor ingresar un nombre valido"
	
Scenario: Ingresar la edad del docente menor a 18
	Given la edad del docente es 15
	When  ingresar edad
	Then el resultado es "Edad es inválida, debe ser mayor a 18"

Scenario: Ingresar el genero del docente incorrecto
	Given el genero del docente es "O"
	When  ingresar genero
	Then el resultado es "El sexo es inválido"