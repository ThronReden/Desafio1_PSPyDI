using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class Ejemplar
    {
        public int Id { get; set; }                         
        public int LibroId { get; set; }                   
        public Libro Libro { get; set; }                   
        public DateTime FechaIncorporacion { get; set; }  

        // Disponible si no tiene ningún préstamo sin devolver
        public bool Disponible =>
            DatosBiblioteca.Prestamos.All(p => p.EjemplarId != Id || p.FechaEntrega.HasValue);
    }
}

   
