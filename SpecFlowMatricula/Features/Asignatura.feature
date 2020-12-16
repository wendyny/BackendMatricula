Feature: Registrar una asignatura nueva

Scenario: Ingresar el campo de nombre vacio
	Given el nombre de la asignatura es ""
	When  ingresar la asignatura
	Then el resultado debe ser "Por favor ingresar un nombre de asignatura valido"