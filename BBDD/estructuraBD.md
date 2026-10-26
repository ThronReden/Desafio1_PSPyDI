Autor:
 - ID (PK)
 - Nombre (NOT NULL)
 - Apellidos (NOT NULL)
 - Nacionalidad (NOT NULL)

Libro:
 - ID (PK)
 - Titulo (NOT NULL)
 - Autor (FK) (NOT NULL)
 - ISBN (UNIQUE)?
 - Genero (Enum)
 - Fecha de publicacion (NOT NULL)
 - Edicion
 - Editorial

Ejemplar:
 - ID (PK)
 - Libro (FK) (NOT NULL)
 - Fecha incorporacion (NOT NULL)

Socio:
 - ID (PK)
 - Nombre (NOT NULL)
 - Apellidos (NOT NULL)
 - Fecha de nacimiento (NOT NULL)

Prestamo:
 - ID (PK)
 - Ejemplar prestado (FK) (NOT NULL)
 - Socio al que se presta (FK) (NOT NULL)
 - Fecha del prestamo (NOT NULL)
 - Fecha esperada de entrega o retorno (NOT NULL)
 - Fecha de entrega
