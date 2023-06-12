using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Module;
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
        List<LectorModel> GetLector(int IdLector);
    }
}