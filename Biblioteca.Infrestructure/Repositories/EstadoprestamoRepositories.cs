

using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Core;

namespace Biblioteca.Infrestructure.Repositories
{
    public class EstadoprestamoRepositories : BaseRepository<EstadoPrestamo>, IestadoPrestamo
    {
        public EstadoprestamoRepositories() { }
        List<EstadoPrestamo> IestadoPrestamo.GetEstadoPrestamos(int IdEstadoPrestamo)
        {
            throw new NotImplementedException();
        }
    }
}
