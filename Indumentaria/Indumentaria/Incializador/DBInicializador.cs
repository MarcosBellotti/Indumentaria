using Indumentaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Indumentaria.Incializador
{
    public class DBInicializador : IDBInicializador
    {
        private readonly IndumentariaContext _context;
        public DBInicializador(IndumentariaContext context)
        {
            _context = context;
        }
        public void Inicializar()
        {
            try
            {
                if(_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate(); //ejecuta las migraciones pendiente
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
