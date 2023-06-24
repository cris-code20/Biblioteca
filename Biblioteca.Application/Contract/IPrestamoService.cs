using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Prestamo;

namespace Biblioteca.Application.Contract
{
    public interface IPrestamoService
    {
        public interface IPretamoService : IBaseService<PrestamoAddDto, PrestamoUpdateDto, PrestamoRemoveDto>
        {

        }
    }
}
