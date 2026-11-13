using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class DatosBiblioteca
    {
        public static List<Autor> Autores { get; } = new List<Autor>();
        public static List<Libro> Libros { get; } = new List<Libro>();
        public static List<Ejemplar> Ejemplares { get; } = new List<Ejemplar>();
        public static List<Socio> Socios { get; } = new List<Socio>();
        public static List<Prestamo> Prestamos { get; } = new List<Prestamo>();

        static DatosBiblioteca()
        {
            // ---------- AUTORES ----------
            var a1 = new Autor { Id = 1, Nombre = "Autor 1", Apellidos = "Apellido 1", Nacionalidad = "Española" };
            var a2 = new Autor { Id = 2, Nombre = "Autor 2", Apellidos = "Apellido 2", Nacionalidad = "Mexicana" };
            var a3 = new Autor { Id = 3, Nombre = "Autor 3", Apellidos = "Apellido 3", Nacionalidad = "Argentina" };
            Autores.AddRange(new[] { a1, a2, a3 });

            // ---------- LIBROS ----------
            var l1 = new Libro
            {
                Id = 1,
                Titulo = "Libro A",
                AutorId = a1.Id,
                Autor = a1,
                ISBN = "978-0-00-000001-1",
                Genero = Genero.Novela,
                FechaPublicacion = new DateTime(2005, 3, 15),
                Edicion = 1,
                Editorial = "Editorial X"
            };
            var l2 = new Libro
            {
                Id = 2,
                Titulo = "Libro B",
                AutorId = a2.Id,
                Autor = a2,
                ISBN = "978-0-00-000002-8",
                Genero = Genero.Ensayo,
                FechaPublicacion = new DateTime(2010, 9, 1),
                Edicion = 2,
                Editorial = "Editorial Y"
            };
            var l3 = new Libro
            {
                Id = 3,
                Titulo = "Libro C",
                AutorId = a3.Id,
                Autor = a3,
                ISBN = "978-0-00-000003-5",
                Genero = Genero.Ciencia,
                FechaPublicacion = new DateTime(2018, 6, 20),
                Edicion = 1,
                Editorial = "Editorial X"
            };
            var l4 = new Libro
            {
                Id = 4,
                Titulo = "Libro D",
                AutorId = a1.Id,
                Autor = a1,
                ISBN = null,
                Genero = Genero.Historia,
                FechaPublicacion = new DateTime(1999, 11, 5),
                Edicion = null,
                Editorial = null
            };
            Libros.AddRange(new[] { l1, l2, l3, l4 });

            // ---------- EJEMPLARES ----------
            var e1 = new Ejemplar { Id = 1, LibroId = l1.Id, Libro = l1, FechaIncorporacion = new DateTime(2020, 1, 10) };
            var e2 = new Ejemplar { Id = 2, LibroId = l1.Id, Libro = l1, FechaIncorporacion = new DateTime(2020, 1, 10) };
            var e3 = new Ejemplar { Id = 3, LibroId = l2.Id, Libro = l2, FechaIncorporacion = new DateTime(2021, 5, 2) };
            var e4 = new Ejemplar { Id = 4, LibroId = l3.Id, Libro = l3, FechaIncorporacion = new DateTime(2022, 3, 18) };
            var e5 = new Ejemplar { Id = 5, LibroId = l4.Id, Libro = l4, FechaIncorporacion = new DateTime(2023, 9, 30) };
            Ejemplares.AddRange(new[] { e1, e2, e3, e4, e5 });

            // ---------- SOCIOS ----------
            var s1 = new Socio { Id = 1, Nombre = "Socio 1", Apellidos = "Apellido 1", FechaNacimiento = new DateTime(1990, 4, 12) };
            var s2 = new Socio { Id = 2, Nombre = "Socio 2", Apellidos = "Apellido 2", FechaNacimiento = new DateTime(1985, 8, 30) };
            var s3 = new Socio { Id = 3, Nombre = "Socio 3", Apellidos = "Apellido 3", FechaNacimiento = new DateTime(2001, 1, 22) };
            Socios.AddRange(new[] { s1, s2, s3 });

            // ---------- PRESTAMOS ----------
            Prestamos.AddRange(new[]
            {
                // Pendiente (dentro de plazo)
                new Prestamo { Id = 1, EjemplarId = e1.Id, Ejemplar = e1, SocioId = s1.Id, Socio = s1,
                               FechaPrestamo = DateTime.Today,
                               FechaEsperadaEntrega = DateTime.Today.AddDays(15),
                               FechaEntrega = null },
                // Retrasado
                new Prestamo { Id = 2, EjemplarId = e3.Id, Ejemplar = e3, SocioId = s2.Id, Socio = s2,
                               FechaPrestamo = DateTime.Today.AddDays(-30),
                               FechaEsperadaEntrega = DateTime.Today.AddDays(-15),
                               FechaEntrega = null },
                // Devuelto
                new Prestamo { Id = 3, EjemplarId = e4.Id, Ejemplar = e4, SocioId = s3.Id, Socio = s3,
                               FechaPrestamo = DateTime.Today.AddDays(-20),
                               FechaEsperadaEntrega = DateTime.Today.AddDays(-5),
                               FechaEntrega = DateTime.Today.AddDays(-7) }
            });
        }
    }
}

  
