using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Repository
{
    public class ProductoPorTalleRepository : IRepository<ProductoPorTalle>
    {
        private IndumentariaContext _context;

        public ProductoPorTalleRepository(IndumentariaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductoPorTalle>> Get()
            => await _context.ProductosPorTalle.ToListAsync();

        public async Task<ProductoPorTalle> GetById(int id)
            => await _context.ProductosPorTalle.FindAsync(id);
        public async Task Add(ProductoPorTalle productoPorTalle)
            => await _context.ProductosPorTalle.AddAsync(productoPorTalle);
        public void Update(ProductoPorTalle productoPorTalle)
        {
            _context.Attach(productoPorTalle);
            _context.ProductosPorTalle.Entry(productoPorTalle).State = EntityState.Modified;
        }
        public void Delete(ProductoPorTalle productoPorTalle)
            => _context.ProductosPorTalle.Remove(productoPorTalle);

        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
