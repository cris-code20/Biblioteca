

using Biblioteca.Domain.Entitis;
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Module;

namespace Biblioteca.Infrestructure.Interface
{
    public interface IprestamosRepository : IRepositoriobase<Prestamo> 
    {
        dynamic GetPrestamoById(int id);
        List<prestamoModels> GetPrestamos(int IdPrestamo);
        dynamic GetPrestamos();
    }
}
