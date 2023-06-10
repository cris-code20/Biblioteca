using Biblioteca.Domain.Entitis;
using Biblioteca.Domain.Repository;

namespace Biblioteca.Infrestructure.Interface
{
    public interface  IestadoPrestamo : IRepositoriobase<EstadoPrestamo>
    {
        List<EstadoPrestamo> GetEstadoPrestamos(int IdEstadoPrestamo);
    }
}
