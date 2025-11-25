CREATE DATABASE DBAlumnos;

CREATE TABLE Alumnos ( 
Id INT IDENTITY(1,1) PRIMARY KEY, 
Nombre NVARCHAR(100), 
Cedula NVARCHAR(20),
Carrera NVARCHAR(50), 
Semestre NVARCHAR(20), 
Jornada NVARCHAR(20), 
Usuario NVARCHAR(50),
Contrasena NVARCHAR(100), 
RecibirNotificaciones BIT, 
FechaRegistro DATETIME DEFAULT GETDATE() );


select * from Alumnos