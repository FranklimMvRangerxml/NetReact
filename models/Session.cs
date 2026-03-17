namespace carritonet.Models
{
    public class Session
    {
    
        public int Id { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public string Ip { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relación
        public Usuario? Usuario { get; set; }
    }
}