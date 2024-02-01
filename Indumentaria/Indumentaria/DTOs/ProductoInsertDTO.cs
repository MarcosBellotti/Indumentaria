using Indumentaria.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indumentaria.DTOs
{
    public class ProductoInsertDTO
    {
        public string Nombre { get; set; }
        public int TipoDeProductoId { get; set; }
        public int MarcaId { get; set; }
    }
}
