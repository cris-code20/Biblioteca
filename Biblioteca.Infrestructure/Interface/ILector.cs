using Biblioteca.Infrestructure.Module;
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Entities;

namespace Biblioteca.Infrestructure.Interface
{
    public interface ILector : IRepositoryBaseLector<Lector>
    {
        dynamic GetById(int id);
        List<Lector> GetLector(int Lector);
        dynamic GetLector();
        dynamic GetLectorById(int id);  
    }
}