

using Biblioteca.Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Entitis
{
    public class EstadoPrestamo : BaseEntity
    {
        [Key] public int IdEstadoPrestamo { get; set; }
        public string ? Descripcion { get; set; }

    }
}
