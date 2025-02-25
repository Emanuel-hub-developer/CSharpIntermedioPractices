using System.ComponentModel.DataAnnotations;

namespace API_Rest.DTOs
{
    public class RefreshTokenDTO
    {
        public string? RefreshToken { get; set; }   

        public string? Token { get; set; }
    }
}
