using Microsoft.EntityFrameworkCore;
using carritonet.Models;

namespace carritonet.Data
{
    public class AppDbContext : DbContext
    {
        //Solo los modelos que se Tienen aqui son los que se ejecutaran en la Migracion.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<ResetPassword> ResetPasswords { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MarcaHorario> MarcasHorario { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemsPedido { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<HistorialEstado> HistorialEstados { get; set; }
    }
}