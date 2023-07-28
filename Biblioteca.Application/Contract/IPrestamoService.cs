using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Prestamo;

namespace Biblioteca.Application.Contract
{
    public interface IPrestamoService : IBaseService<PrestamoAddDto, PrestamoUpdateDto, PrestamoRemoveDto>
    {


    }
   
}
