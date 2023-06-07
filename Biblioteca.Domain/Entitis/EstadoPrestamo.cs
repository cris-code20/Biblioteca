

using Biblioteca.Domain.Core;

namespace Biblioteca.Domain.Entitis
{
    public class EstadoPrestamo : BaseEntity
    {
        public int IdEstadoPrestamo { get; set; }
        public string ? Descripcion { get; set; }

    }
}
