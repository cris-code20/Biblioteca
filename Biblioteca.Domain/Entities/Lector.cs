using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Biblioteca.Infrestructure.Entities
{
    public class Lector
    {
        public int IdLector { get; set; }
        public string? Codigo { get; set; }    
        public string? Nombre { get; set; }    
        public string? Apellido { get; set; }
        public string? Correo { get; set; } 
        public string? Clave { get; set; }  
        public int Estado { get; set; }
        public DateTime FechaCreacion {  get; set; }    
    }
}
