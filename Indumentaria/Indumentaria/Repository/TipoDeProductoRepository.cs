using Indumentaria.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Repository
{
    public class TipoDeProductoRepository : IRepository<TipoDeProducto>
    {
        private IndumentariaContext _context;

        public TipoDeProductoRepository(IndumentariaContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<TipoDeProducto>> Get()
            => await _context.TiposDeProducto.ToListAsync();

        public async Task<TipoDeProducto> GetById(int id)
            => await _context.TiposDeProducto.FindAsync(id);
        public async Task Add(TipoDeProducto tipoDeProducto) 
            => await _context.TiposDeProducto.AddAsync(tipoDeProducto);
        public void Update(TipoDeProducto tipoDeProducto)
        {
            _context.Attach(tipoDeProducto);
            _context.TiposDeProducto.Entry(tipoDeProducto).State = EntityState.Modified;
        }
        public void Delete(TipoDeProducto tipoDeProducto) 
            => _context.Remove(tipoDeProducto);

        public async Task Save() 
            => await _context.SaveChangesAsync();
    }
}
