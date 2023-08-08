using System;


namespace Biblioteca.Application.Dtos.Lector
{
    public abstract class LectorDto : DtoBase
    {

        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Clave { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}