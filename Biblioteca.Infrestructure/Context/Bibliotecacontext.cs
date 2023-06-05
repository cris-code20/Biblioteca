
using Biblioteca.Infrestructure.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrestructure.Context
{
    public class Bibliotecacontext : DbContext

    {
        public Bibliotecacontext()
        {
        }

        public Bibliotecacontext(DbContextOptions<Bibliotecacontext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }

    }
} 
