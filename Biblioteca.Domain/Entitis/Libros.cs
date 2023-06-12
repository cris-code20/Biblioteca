
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Biblioteca.Infrestructure.Entitis
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string? Titulo { get; set; }
        public string? autor { get; set; }
        public int IdCategoria { get; set; }
        public string? Editorial { get; set; }
        public string? Ubicacion { get; set; }
        public int Ejemplares { get; set; }
        public byte Portada { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }


    }
}
