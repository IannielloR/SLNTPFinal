using Microsoft.EntityFrameworkCore;
using SWProvincias_Ianniello.Models;

namespace SWProvincias_Ianniello.Data
{
    public class DbProvinciasContext: DbContext
    {
        public DbProvinciasContext(DbContextOptions<DbProvinciasContext> options
           ) : base(options) { }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
