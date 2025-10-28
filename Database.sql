-- Script para crear la base de datos y tabla necesaria para el proyecto

-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'RegistroNotas')
BEGIN
    CREATE DATABASE RegistroNotas;
END
GO

-- Usar la base de datos
USE RegistroNotas;
GO

-- Crear la tabla Estudiante si no existe
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Estudiante')
BEGIN
    CREATE TABLE Estudiante (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Codigo NVARCHAR(50) NOT NULL,
        Nombre NVARCHAR(200) NOT NULL,
        Laboratorio DECIMAL(5,2) NOT NULL,
        Parcial DECIMAL(5,2) NOT NULL,
        Asistencia DECIMAL(5,2) NOT NULL,
        NotaFinal DECIMAL(5,2) NOT NULL
    );
    
    PRINT 'Tabla Estudiante creada exitosamente';
END
ELSE
BEGIN
    PRINT 'La tabla Estudiante ya existe';
END
GO

-- Insertar datos de prueba (opcional)
-- Descomentar las siguientes líneas si deseas datos de ejemplo

/*
INSERT INTO Estudiante (Codigo, Nombre, Laboratorio, Parcial, Asistencia, NotaFinal)
VALUES 
    ('EST001', 'JUAN PEREZ', 8.5, 7.0, 9.0, 8.1),
    ('EST002', 'MARIA LOPEZ', 9.0, 8.5, 10.0, 8.95),
    ('EST003', 'CARLOS GOMEZ', 7.0, 6.5, 8.0, 6.95);

PRINT 'Datos de prueba insertados';
*/

-- Verificar la estructura de la tabla
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Estudiante'
ORDER BY ORDINAL_POSITION;
GO
