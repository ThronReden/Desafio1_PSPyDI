using System;
using System.Collections.Generic;
using System.Text;

namespace Parte_Visual
{
    public class Prestamo
    {
        public string Cliente { get; set; }
        public string Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaCaducidad { get; set; }
    }
}
