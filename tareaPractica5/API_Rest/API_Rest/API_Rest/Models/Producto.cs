using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string? Nombre  { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public int Stock {  get; set; }


        [ForeignKey("Proveedor")]
        public int? idProveedor { get; set; }
        public Proveedor Proveedor { get; set; }


        [ForeignKey("Categoria")]
        public int? idCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
