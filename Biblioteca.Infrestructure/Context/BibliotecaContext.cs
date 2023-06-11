using Biblioteca.Domain.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrestructure.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
        {
        }

        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<EstadoPrestamo> estado { get; set; }
    }
}
