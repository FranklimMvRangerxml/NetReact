namespace carritonet.Models
{
    public class ResetPassword
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string TokenReset { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Code { get; set; } = string.Empty;
        public Usuario? Usuario { get; set; }
    }
}