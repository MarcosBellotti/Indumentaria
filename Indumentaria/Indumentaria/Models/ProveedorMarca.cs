using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indumentaria.Models
{
    public class ProveedorMarca
    {
        public int ProveedorCuit { get; set; }
        [ForeignKey("ProveedorCuit")]
        public virtual Proveedor Proveedor { get; set; }
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }
    }
}
