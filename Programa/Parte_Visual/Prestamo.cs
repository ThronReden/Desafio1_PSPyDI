using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_V2
{
    public class Prestamo
    {
        public int Id { get; set; }                         
        public int EjemplarId { get; set; }                 
        public Ejemplar Ejemplar { get; set; }              
        public int SocioId { get; set; }                    
        public Socio Socio { get; set; }                  
        public DateTime FechaPrestamo { get; set; }         
        public DateTime FechaEsperadaEntrega { get; set; }  
        public DateTime? FechaEntrega { get; set; }         

        public string Estado
        {
            get
            {
                if (FechaEntrega.HasValue) return "Devuelto";
                return DateTime.Today > FechaEsperadaEntrega ? "Retrasado" : "Pendiente";
            }
        }
    }
}
