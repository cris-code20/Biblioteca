using Biblioteca.Infrestructure.Module;
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Entities;

namespace Biblioteca.Infrestructure.Interface
{
    public interface ILector : IRepositoryBaseLector<Lector>
    {
        List<Lector> GetLector(int Lector);
    }
}