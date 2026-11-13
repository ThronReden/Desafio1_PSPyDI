using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class Libro
    {
        public int Id { get; set; }                         
        public string Titulo { get; set; }                  
        public int AutorId { get; set; }                    
        public Autor Autor { get; set; }                    
        public string ISBN { get; set; }                    
        public Genero Genero { get; set; }              
        public DateTime FechaPublicacion { get; set; }     
        public int? Edicion { get; set; }                  
        public string Editorial { get; set; }              
    }
}


