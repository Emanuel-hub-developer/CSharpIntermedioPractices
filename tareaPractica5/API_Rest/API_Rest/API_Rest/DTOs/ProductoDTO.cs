namespace API_Rest.DTOs
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
    }
}
