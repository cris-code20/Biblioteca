using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Interface
{
    public interface ILector : IRepositoriobase<Lector>
    {
        List<Lector> GetLector(int Lector);
    }
}