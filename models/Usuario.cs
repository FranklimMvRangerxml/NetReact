namespace carritonet.Models
{
    public class Usuario
    {
        
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string ContrasenaHash { get; set; } = string.Empty;
        public string Rol { get; set; } = "empleado";
        public string Codigo { get; set; } = string.Empty;
        public int PlanId { get; set; }
        public int SedeId { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime CreadoEn { get; set; } = DateTime.Now;

        // Relaciones
        public Plan? Plan { get; set; }
        public Sede? Sede { get; set; }
    }
}