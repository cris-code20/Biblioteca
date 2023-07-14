using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrestructure.Context
{
    public class Bibliotecacontext : DbContext
    {
        public Bibliotecacontext()
        {
        }
        public Bibliotecacontext(DbContextOptions<Bibliotecacontext> options) : base(options) { }
        public DbSet<Lector> Lector { get; set; }   
    }
}
