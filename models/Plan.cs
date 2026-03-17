namespace carritonet.Models
{
    public class Plan
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = "basic";
        public int MaxDays { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "activo";
    }
}