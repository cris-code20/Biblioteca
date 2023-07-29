
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Entities;
using Biblioteca.Infrestructure.Module;

namespace Biblioteca.Infrestructure.Interface
{
    public interface ILector : IRepositoryBaseLector<Lector>
    {
        LectorModel GetLectorById(int id);
        List<LectorModel> GetLectors();
    }
}