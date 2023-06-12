using Biblioteca.Domain.Repositories;
using Biblioteca.Infrestructure.Entitis;
using Biblioteca.Infrestructure.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Interface
{
    public interface ILibroRepository : Irepository <Libro>
    {
        List<LibroModels> GetLibro(int IdLibro);

    }
}
