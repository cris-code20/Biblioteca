using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Module
{
    public class prestamoModels
    {
        public int IdPrestamo { get; set; }
        public string? Codigo { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public int IdLector { get; set; }
        public int IdLibro { get; set; }
    }
}
