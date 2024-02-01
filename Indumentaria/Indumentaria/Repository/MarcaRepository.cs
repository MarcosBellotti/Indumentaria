using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Indumentaria.Repository
{
    public class MarcaRepository : IRepository<Marca>
    {
        private IndumentariaContext _context;
        public MarcaRepository(IndumentariaContext context) { 
            _context = context;
        }
        public async Task<IEnumerable<Marca>> Get()
            => await _context.Marcas.ToListAsync();
        public async Task<Marca> GetById(int id)
            => await _context.Marcas.FindAsync(id);
        public async Task Add(Marca marca)
            => await _context.Marcas.AddAsync(marca);
        public void Update(Marca marca)
        {
            _context.Marcas.Attach(marca);
            _context.Marcas.Entry(marca).State = EntityState.Modified;
        }
        public void Delete(Marca marca)
            => _context.Marcas.Remove(marca);
        public async Task Save()
            => await _context.SaveChangesAsync();
    }
}
}
