using Biblioteca.Application.Datos;
using System;


namespace Biblioteca.Application.Dtos.Prestamo
{
    public abstract class PrestamoDto : DtoBase
    {
        public string? Codigo { get; set; }
        public int IdEstadoPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int IdPrestamo { get; set; }


    }
}
