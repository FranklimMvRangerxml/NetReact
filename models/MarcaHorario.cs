namespace carritonet.Models
{
    public class MarcaHorario
    {
        
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Novedad { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string Accion1 { get; set; } = "trabajo";
        public string Accion2 { get; set; } = "inicio";

        // Relación
        public Usuario? Usuario { get; set; }
    }
}