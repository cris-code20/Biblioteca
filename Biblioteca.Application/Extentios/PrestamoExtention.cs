using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Interface;


namespace Biblioteca.Application.Extentios
{
    public static class PrestamoExtention
    {
        public static Prestamo ConvertDtoAddToEntity(this PrestamoAddDto prestamoAddDto)
        {
            return new Prestamo()
            {
                Codigo = prestamoAddDto.Codigo,
                IdEstadoPrestamo = prestamoAddDto.IdPrestamo,
                FechaDevolucion = prestamoAddDto.FechaDevolucion,
                IdPrestamo = prestamoAddDto.IdPrestamo,
                CreationUser = prestamoAddDto.ChangeUser,
                CreationDate = prestamoAddDto.ChangeDate,

            };
        }

        public static Prestamo ConvertDtoUpdateToEntity(this PrestamoUpdateDto prestamoUpdateDto)
        {
            return new Prestamo()
            {
                Codigo = prestamoUpdateDto.Codigo,
                IdEstadoPrestamo = prestamoUpdateDto.IdPrestamo,
                FechaDevolucion = prestamoUpdateDto.FechaDevolucion,
                IdPrestamo = prestamoUpdateDto.IdPrestamo
            };
        }
    }
}
