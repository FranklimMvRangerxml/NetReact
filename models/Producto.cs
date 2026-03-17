namespace carritonet.Models
{
    public class Producto
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public float Precio { get; set; }
        public string UrlImagen { get; set; } = string.Empty;
        public string Categoria { get; set; } = "otros";
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}