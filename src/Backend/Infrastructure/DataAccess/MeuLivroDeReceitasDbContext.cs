

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class MeuLivroDeReceitasDbContext:DbContext
    {
        public MeuLivroDeReceitasDbContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuLivroDeReceitasDbContext).Assembly);
        }
    }
}