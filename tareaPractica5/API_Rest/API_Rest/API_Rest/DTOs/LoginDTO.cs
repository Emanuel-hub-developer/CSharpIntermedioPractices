
using System.ComponentModel.DataAnnotations;

namespace API_Rest.DTOs

{
    
    public class LoginDTO
    {
        [Required]
        public string Correo {  get; set; }

        [Required]
        public string Clave { get; set; }

    }
}
