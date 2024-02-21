Create database ProyectoTec02AMMA;
use Escuela;

CREATE TABLE Profesores (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Edad INT,
    Foto IMAGE,
    IdCarrera int,
    FOREIGN KEY (IdCarrera) REFERENCES Carrera(Id)
);
;

CREATE TABLE Carrera (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100),
);

select*from categoria

