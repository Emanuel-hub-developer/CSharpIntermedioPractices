using CreacionAPI_Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace CreacionAPI_Rest.DB
{
    public class CreacionAPI_RestContext:DbContext
    {
        public CreacionAPI_RestContext(DbContextOptions options)
            : base(options) 
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
