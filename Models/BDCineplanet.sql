-- Crear la base de datos
CREATE DATABASE Cineplanet;
GO

USE Cineplanet;
GO

-- Tabla de Generos
CREATE TABLE Generos (
    GenerosId INT IDENTITY(1,1) PRIMARY KEY,  -- Cambio en el nombre de la columna
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(255),
    fecha_creacion DATE,
    activo BIT,
    pais_origen VARCHAR(50)
);
GO

-- Insertar datos de ejemplo en Generos
INSERT INTO Generos (nombre, descripcion, fecha_creacion, activo, pais_origen)
VALUES 
    ('Ciencia Ficción', 'Género que explora avances científicos y tecnológicos.', '2024-01-01', 1, 'Estados Unidos'),
    ('Acción', 'Género centrado en escenas dinámicas y emocionantes.', '2024-02-01', 1, 'México'),
    ('Suspenso', 'Género que mantiene al espectador en tensión constante.', '2024-03-01', 1, 'Reino Unido');
GO

-- Tabla de Peliculas
CREATE TABLE Peliculas (
    PeliculasId INT IDENTITY(1,1) PRIMARY KEY,  -- Cambio en el nombre de la columna
    titulo VARCHAR(255) NOT NULL,
    duracion INT NOT NULL,  -- Duración en minutos
    clasificacion VARCHAR(20),
    estreno DATE,
    GenerosId INT,  -- Referencia con el nombre correcto
    FOREIGN KEY (GenerosId) REFERENCES Generos(GenerosId)
);
GO

-- Insertar datos de ejemplo en Peliculas
INSERT INTO Peliculas (titulo, duracion, clasificacion, estreno, GenerosId)
VALUES 
('Avatar 2', 192, 'PG-13', '2022-12-16', 1),
('Avengers: Endgame', 181, 'PG-13', '2019-04-26', 2),
('The Batman', 155, 'PG-13', '2022-03-04', 3);
GO

-- Tabla de Cines
CREATE TABLE Cines (
    CinesId INT IDENTITY(1,1) PRIMARY KEY,  -- Cambio en el nombre de la columna
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(255),
    telefono VARCHAR(15)
);
GO

-- Insertar datos de ejemplo en Cines
INSERT INTO Cines (nombre, direccion, telefono)
VALUES 
('Cineplanet Miraflores', 'Av. Pardo y Aliaga 640, Lima', '012345678'),
('Cineplanet San Isidro', 'Av. Comandante Espinar 789, Lima', '0987654321');
GO

-- Tabla de Salas
CREATE TABLE Salas (
    SalasId INT IDENTITY(1,1) PRIMARY KEY,  -- Cambio en el nombre de la columna
    CinesId INT,  -- Referencia con el nombre correcto
    nombre VARCHAR(50) NOT NULL,
    capacidad INT,
    FOREIGN KEY (CinesId) REFERENCES Cines(CinesId)
);
GO

-- Insertar datos de ejemplo en Salas
INSERT INTO Salas (CinesId, nombre, capacidad)
VALUES 
(1, 'Sala 1', 150),
(1, 'Sala 2', 200),
(2, 'Sala 3', 180);
GO

-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuariosId INT IDENTITY(1,1) PRIMARY KEY,  -- Cambio en el nombre de la columna
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE,
    telefono VARCHAR(15),
    tipo_usuario VARCHAR(50) NOT NULL  -- Ejemplo: 'Admin', 'Empleado', 'Cliente'
);
GO

-- Insertar datos de ejemplo en Usuarios
INSERT INTO Usuarios (nombre, email, telefono, tipo_usuario)
VALUES 
('Juan Pérez', 'juan.perez@email.com', '987654321', 'Admin'),
('Maria García', 'maria.garcia@email.com', '987654322', 'Empleado'),
('Carlos López', 'carlos.lopez@email.com', '987654323', 'Cliente');
GO

-- Consultas para ver los datos
SELECT * FROM Cines;

SELECT * FROM Generos;

SELECT * FROM Peliculas;

