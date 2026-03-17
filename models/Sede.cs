namespace carritonet.Models
{
    public class Sede
    {
        
        public int Id { get; set; }
        public int UsuarioSede { get; set; }
        public string Img { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "activo";
    }
}