Feature: Registrar un usuario nuevo

Scenario: Ingresar el campo de nombre de usuario vacio
	Given el nombre del usuario es ""
	When  ingresar el usuario
	Then debe mostrar  "Por favor ingresar un nombre de usuario valido"

Scenario: Ingresar el campo de password de usuario vacio
	Given el password del usuario es ""
	When  ingresar el password
	Then debe mostrar  "Por favor ingresar una contraseña valida"

