
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
        public DateTime DeleteDate { get; set; }
        public int UserDeleted { get; set; }
        public bool Deleted { get; set; }
    }
}
