Feature: Registrar un curso nuevo

Scenario: Ingresar el campo de nombre vacio
	Given el nombre es ""
	When se ingresa el nombre
	Then debe mostrar "Por favor ingrese un nombre valido para el curso"