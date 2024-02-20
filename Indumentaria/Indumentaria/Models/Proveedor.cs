using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indumentaria.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProveedorId { get; set; }
        public int Cuit { get; set; }
        public string Nombre { get; set; }
        public int NumeroDeCelular { get; set; }

    }
}
