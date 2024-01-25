using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indumentaria.Models
{
    public class Proveedor
    {
        [Key]
        public int Cuit { get; set; }
        public string Nombre { get; set; }
        public int NumeroDeCelular { get; set; }

    }
}
