using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indumentaria.Models
{
    public class ProductoPorTalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoPorTalleId { get; set; }
        public int ProductoId { get; set; }
        public int Talle { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }
    }
}
