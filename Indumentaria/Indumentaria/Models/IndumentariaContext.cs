using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Models
{
    public class IndumentariaContext : DbContext
    {
        public IndumentariaContext(DbContextOptions<IndumentariaContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoDeProducto> TiposDeProducto { get; set; }
        public DbSet<ProductoPorTalle> ProductosPorTalle { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ProveedorMarca> ProveedoresMarcas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProveedorMarca>().HasKey(pm => new
            {
                pm.ProveedorCuit,
                pm.MarcaId
            });
        }
    }
}
