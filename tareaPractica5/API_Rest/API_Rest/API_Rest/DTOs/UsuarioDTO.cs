

using System.ComponentModel.DataAnnotations;

namespace API_Rest.DTOs
{
    public class UsuarioDTO
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
        [Required]
        public string Clave { get; set; }
    }
}
