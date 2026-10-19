Autor:
 - ID (PK)
 - Nombre
 - Apellidos
 - Nacionalidad

Libro:
 - ID (PK)
 - Titulo
 - Autor (FK)
 - ISBN (UNIQUE)
 - Genero (Enum)
 - Fecha de publicacion
 - Edicion
 - Editorial

Ejemplar:
 - ID (PK)
 - Libro (FK)
 - Fecha incorporacion

Socio:
 - ID (PK)
 - Nombre
 - Apellidos
 - Fecha de nacimiento

Prestamo:
 - ID (PK)
 - Ejemplar prestado (FK)
 - Socio al que se presta (FK)
 - Fecha del prestamo
 - Fecha esperada de entrega o retorno
 - Fecha de entrega
