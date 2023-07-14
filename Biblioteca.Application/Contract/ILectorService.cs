using Biblioteca.Application.Core;
using Biblioteca.Application.Dtos.Department;

namespace Biblioteca.Application.Contract
{
    public interface ILectorService : IBaseService<LectorAddDto,
                                                   LectorUpdateDto,
                                                   LectorRemoveDto>
    {

    }
}