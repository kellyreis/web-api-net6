using api.Domain.Produto;
using Microsoft.EntityFrameworkCore;

namespace api.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Categoria> Categoria { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Produto>()
                .Property(p => p.Nome).IsRequired();
            builder.Entity<Produto>()
                .Property(p => p.Descricao).HasMaxLength(255);
      

            builder.Entity<Categoria>()
                .Property(c => c.Nome).IsRequired();

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
        {
            configuration.Properties<string>()
                .HaveMaxLength(100);
        }


    }
}
