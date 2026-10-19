Autor:
 - ID (PK)
 - Nombre
 - Apellidos
 - Nacionalidad

Libro:
 - ID (PK)
 - Titulo
 - Autor (SK)
 - ISBN
 - Genero (Enum)
 - Fecha de publicacion
 - Edicion
 - Editorial

Ejemplar:
 - Libro (SK) (PK comp)
 - Fecha incorporacion (PK comp)

Socio:
 - ID (PK)
 - Nombre
 - Apellidos
 - Fecha de nacimiento
 - Puntos

Prestamos:
 - ID (PK)
 - Ejemplar prestado (SK)
 - Socio al que se presta (SK)
 - Fecha del prestamo
 - Fecha esperada de entrega o retorno
 - Estado entrega
