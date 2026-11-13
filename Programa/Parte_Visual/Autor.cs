using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class Autor
    {
        public int Id { get; set; }                
        public string Nombre { get; set; }        
        public string Apellidos { get; set; }       
        public string Nacionalidad { get; set; }   

        public string NombreCompleto => Nombre + " " + Apellidos;
    }
}
