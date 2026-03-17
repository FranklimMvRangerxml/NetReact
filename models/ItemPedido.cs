namespace carritonet.Models
{
    public class ItemPedido
    {
       
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string CodigoPedido { get; set; } = string.Empty;
        public float PrecioUnitario { get; set; }

        // Relaciones
        public Pedido? Pedido { get; set; }
        public Producto? Producto { get; set; }
    }
}