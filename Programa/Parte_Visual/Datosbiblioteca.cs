
using System;
using System.Collections.Generic;
using System.Text;

namespace Parte_Visual
{
    // Datos genéricos compartidos por todas las ventanas.
    // Más adelante se pueden sustituir por una base de datos.
    public static class DatosBiblioteca
    {
        public static List<Cliente> Clientes { get; } = new List<Cliente>
        {
            new Cliente { Id = 1, Nombre = "Cliente 1", Email = "cliente1@correo.com", Telefono = "600 000 001" },
            new Cliente { Id = 2, Nombre = "Cliente 2", Email = "cliente2@correo.com", Telefono = "600 000 002" },
            new Cliente { Id = 3, Nombre = "Cliente 3", Email = "cliente3@correo.com", Telefono = "600 000 003" }
        };

        public static List<Libro> Libros { get; } = new List<Libro>
        {
            new Libro { Id = 1, Titulo = "Libro A", Autor = "Autor 1", Genero = "Novela",  Disponible = false },
            new Libro { Id = 2, Titulo = "Libro B", Autor = "Autor 2", Genero = "Ensayo",  Disponible = false },
            new Libro { Id = 3, Titulo = "Libro C", Autor = "Autor 3", Genero = "Ciencia", Disponible = false },
            new Libro { Id = 4, Titulo = "Libro D", Autor = "Autor 4", Genero = "Historia", Disponible = true }
        };

        public static List<Prestamo> Prestamos { get; } = new List<Prestamo>
        {
            new Prestamo { Cliente = "Cliente 1", Libro = "Libro A",
                           FechaPrestamo = DateTime.Today,
                           FechaCaducidad = DateTime.Today.AddDays(15) },
            new Prestamo { Cliente = "Cliente 2", Libro = "Libro B",
                           FechaPrestamo = DateTime.Today.AddDays(-3),
                           FechaCaducidad = DateTime.Today.AddDays(12) },
            new Prestamo { Cliente = "Cliente 3", Libro = "Libro C",
                           FechaPrestamo = DateTime.Today.AddDays(-10),
                           FechaCaducidad = DateTime.Today.AddDays(5) }
        };
    }
}
