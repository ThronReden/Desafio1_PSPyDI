-- createDB.sql: base de datos sencilla de biblioteca (MySQL / MariaDB)

CREATE DATABASE IF NOT EXISTS bibliotecaDesafioPSPyDI
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;
USE bibliotecaDesafioPSPyDI;

CREATE TABLE Autor (
    id           INT AUTO_INCREMENT PRIMARY KEY,
    nombre       VARCHAR(100) NOT NULL,
    apellidos    VARCHAR(150) NOT NULL,
    nacionalidad VARCHAR(60)  NOT NULL
);

CREATE TABLE Libro (
    id                   INT AUTO_INCREMENT PRIMARY KEY,
    titulo               VARCHAR(255) NOT NULL,
    autor_id             INT          NOT NULL,
    isbn                 VARCHAR(17)  UNIQUE,
    genero               ENUM('NOVELA', 'ENSAYO', 'POESIA', 'TEATRO', 'CIENCIA',
                              'HISTORIA', 'INFANTIL', 'OTRO'),
    fecha_publicacion    DATE         NOT NULL,
    edicion              VARCHAR(50),
    editorial            VARCHAR(100),
    CONSTRAINT fk_libro_autor FOREIGN KEY (autor_id) REFERENCES Autor(id)
);

CREATE TABLE Ejemplar (
    id                 INT AUTO_INCREMENT PRIMARY KEY,
    libro_id           INT  NOT NULL,
    fecha_incorporacion DATE NOT NULL,
    CONSTRAINT fk_ejemplar_libro FOREIGN KEY (libro_id) REFERENCES Libro(id)
);

CREATE TABLE Socio (
    id               INT AUTO_INCREMENT PRIMARY KEY,
    nombre           VARCHAR(100) NOT NULL,
    apellidos        VARCHAR(150) NOT NULL,
    fecha_nacimiento DATE         NOT NULL
);

CREATE TABLE Prestamo (
    id                INT AUTO_INCREMENT PRIMARY KEY,
    ejemplar_id       INT  NOT NULL,
    socio_id          INT  NOT NULL,
    fecha_prestamo    DATE NOT NULL,
    fecha_esperada    DATE NOT NULL,
    fecha_entrega     DATE DEFAULT NULL,  -- NULL mientras no se haya devuelto
    -- Columna auxiliar: vale ejemplar_id mientras el préstamo está activo y NULL al devolverlo.
    -- Como UNIQUE admite varios NULL, impide dos préstamos activos del mismo ejemplar.
    ejemplar_activo   INT GENERATED ALWAYS AS (IF(fecha_entrega IS NULL, ejemplar_id, NULL)) STORED,
    CONSTRAINT uq_prestamo_ejemplar_activo UNIQUE (ejemplar_activo),
    CONSTRAINT fk_prestamo_ejemplar FOREIGN KEY (ejemplar_id) REFERENCES Ejemplar(id),
    CONSTRAINT fk_prestamo_socio    FOREIGN KEY (socio_id)    REFERENCES Socio(id),
    CONSTRAINT ck_prestamo_fechas   CHECK (fecha_esperada >= fecha_prestamo),
    CONSTRAINT ck_prestamo_entrega  CHECK (fecha_entrega IS NULL OR fecha_entrega >= fecha_prestamo)
);

CREATE VIEW EjemplarDisponible AS
SELECT e.*
FROM Ejemplar e
WHERE NOT EXISTS (
    SELECT 1 FROM Prestamo p
    WHERE p.ejemplar_id = e.id AND p.fecha_entrega IS NULL
);
