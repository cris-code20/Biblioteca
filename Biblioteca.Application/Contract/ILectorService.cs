using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Department;
using Biblioteca.Application.Dtos.Lector;

namespace Biblioteca.Application.Contract
{
    public interface ILectorService : IBaseService<LectorAddDto,
                                                   LectorUpdateDto,
                                                   LectorRemoveDto>
    {

    }
}