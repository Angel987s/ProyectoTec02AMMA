

-- Crear la base de datos
CREATE DATABASE Universidad;
GO

-- Usar la base de datos creada
USE Universidad;
GO

-- Crear tabla Carreras
CREATE TABLE Carreras (
    CarreraID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

-- Crear tabla Profesores
CREATE TABLE Profesores (
    ProfesorID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellido NVARCHAR(100),
    Foto IMAGE, -- Columna para almacenar imagen
    CarreraID INT FOREIGN KEY REFERENCES Carreras(CarreraID)
);
