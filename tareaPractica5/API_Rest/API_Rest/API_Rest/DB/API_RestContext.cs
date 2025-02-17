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
    }
}
