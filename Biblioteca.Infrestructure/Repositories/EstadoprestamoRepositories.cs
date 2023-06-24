

using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Context;

namespace Biblioteca.Infrestructure.Repositories
{
    public class EstadoprestamoRepositories : BaseRepository<EstadoPrestamo>, IestadoPrestamo
    {
     public EstadoprestamoRepositories(BibliotecaContext context) : base(context) { }
    }
}
