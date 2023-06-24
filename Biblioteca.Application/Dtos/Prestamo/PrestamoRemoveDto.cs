


using Biblioteca.Application.Datos;

namespace Biblioteca.Application.Dtos.Prestamo
{
    public class PrestamoRemoveDto : DtoBase 
    {
        public int IdPrestamo { get; set; }
        public bool Delete { get; set; }
    }
}
