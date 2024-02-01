using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Repository
{
    public class ProveedorRepository : IRepository<Proveedor>
    {
        private IndumentariaContext _context;
        public ProveedorRepository(IndumentariaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> Get()
            => await _context.Proveedores.ToListAsync();
        public async Task<Proveedor> GetById(int id)
            => await _context.Proveedores.FindAsync(id);
        public async Task Add(Proveedor proveedor)
            => await _context.Proveedores.AddAsync(proveedor);
        public void Update(Proveedor proveedor)
        {
            _context.Attach(proveedor);
            _context.Entry(proveedor).State = EntityState.Modified;
        }
        public void Delete(Proveedor proveedor)
            => _context.Proveedores.Remove(proveedor);
        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
