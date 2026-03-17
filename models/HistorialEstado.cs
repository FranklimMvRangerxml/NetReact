namespace carritonet.Models
{
    public class HistorialEstado
    {
      
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int CambiadoPor { get; set; }
        public string EstadoAnterior { get; set; } = string.Empty;
        public string EstadoNuevo { get; set; } = string.Empty;
        public DateTime CambiadoEn { get; set; } = DateTime.Now;

        // Relaciones
        public Pedido? Pedido { get; set; }
        public Usuario? Usuario { get; set; }
    }
}