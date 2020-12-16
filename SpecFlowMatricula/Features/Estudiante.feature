Feature: Registrar un nuevo estudiante

Scenario: Ingresar la edad del estudiante menor a 18
	Given la edad del estudiante es 15
	When  ingresar edad del estudiante
	Then muestra el resultado "Edad es inválida, debe ser mayor a 18"

Scenario: Ingresar el genero del estudiante incorrecto
	Given el genero del estudiante es "O"
	When  ingresar genero del estudiante
	Then muestra el resultado "El sexo es inválido"