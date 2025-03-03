using API_Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Rest.DB
{
    public class API_RestContext : DbContext
    {
        public API_RestContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RecordRefreshToken> RecordRefreshTokens { get; set; }
        public DbSet<HistorialRefreshToken> HistorialRefreshTokens { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecordRefreshToken>()
                .Property(r => r.IsActive)
                .HasComputedColumnSql("iif(FechaExpiracion < getdate(), convert(bit,0), convert(bit,1))", stored: false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
