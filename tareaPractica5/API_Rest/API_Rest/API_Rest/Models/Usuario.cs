﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Rest.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
      
        public string? Clave { get; set; }
        [Required]
        public DateTime FechaDeNacimiento { get; set; }
    }
}
