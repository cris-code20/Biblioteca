using Biblioteca.Application.Datos;
using System;


namespace Biblioteca.Application.Dtos.Prestamo
{
    public abstract class PrestamoDto : DtoBase
    {
        public string? Name { get; set; }
        public decimal? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? IdPrestamo { get; set; }


    }
}
