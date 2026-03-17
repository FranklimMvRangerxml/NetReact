namespace carritonet.Models
{
    public class Pedido
    {
        
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; } = "en_sede";
        public string Estado { get; set; } = "verificacion";
        public string ListadoProductosArray { get; set; } = string.Empty;
        public string UrlComprobante { get; set; } = string.Empty;
        public string EstadoPago { get; set; } = "pendiente";
        public int SedeId { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.Now;

        // Relaciones
        public Usuario? Usuario { get; set; }
        public Sede? Sede { get; set; }
    }
}