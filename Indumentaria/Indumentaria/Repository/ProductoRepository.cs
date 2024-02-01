using Indumentaria.DTOs;
using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Repository
{
    public class ProductoRepository : IRepository<Producto>
    {
        private IndumentariaContext _context;
        public ProductoRepository(IndumentariaContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> Get() 
            => await _context.Productos.ToListAsync();

        public async Task<Producto> GetById(int id)
            => await _context.Productos.FindAsync(id);
        public async Task Add(Producto producto)
            => await _context.Productos.AddAsync(producto);

        public void Update(Producto producto)
        {
            _context.Productos.Attach(producto);
            _context.Productos.Entry(producto).State= EntityState.Modified;
        }
        public void Delete(Producto producto)
            => _context.Productos.Remove(producto);
        public async Task Save() 
            => await _context.SaveChangesAsync();
    }
}
