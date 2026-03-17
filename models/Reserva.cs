namespace carritonet.Models
{
    public class Reserva
    {
        
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int NumeroMesa { get; set; }
        public int NumPersonas { get; set; }
        public string Ocasion { get; set; } = "normal";
        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public string Observacion { get; set; } = string.Empty;
        public string Estado { get; set; } = "pendiente";

        // Relación
        public Usuario? Usuario { get; set; }
    }
}