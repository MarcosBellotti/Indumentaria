using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indumentaria.Models
{
    public class TipoDeProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoDeProductoId { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get; set; }
    }
}
