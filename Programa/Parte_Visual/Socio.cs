using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class Socio
    {
        public int Id { get; set; }                         
        public string Nombre { get; set; }                  
        public string Apellidos { get; set; }               
        public DateTime FechaNacimiento { get; set; }      

        public string NombreCompleto => Nombre + " " + Apellidos;
    }
}

    