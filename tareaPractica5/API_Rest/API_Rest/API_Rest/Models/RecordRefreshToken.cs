using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models
{
    public class RecordRefreshToken
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHistorialToken { get; set; }

        // Clave foránea que referencia a Usuario
        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }

        [MaxLength(500)]
        public string? Token { get; set; }

        [MaxLength(500)]
        public string? RefreshToken { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaExpiracion { get; set; }


        public bool EsActivo { get; set; } //Descomentar para poder hacer migrations

        public bool IsActive { get; set; }
    }

}

