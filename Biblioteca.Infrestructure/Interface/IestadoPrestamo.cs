using Biblioteca.Domain.Entitis;
using Biblioteca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Interface
{
    public interface  IestadoPrestamo : IRepositoriobase<EstadoPrestamo>
    {
        List<EstadoPrestamo> GetEstadoPrestamos(int IdEstadoPrestamo);
    }
}
