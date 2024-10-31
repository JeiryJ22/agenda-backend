using agenda_telefonica.Entities;
using Microsoft.EntityFrameworkCore;

namespace agenda_telefonica.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Correo> Correos { get; set; }
    }
}
