using Microsoft.EntityFrameworkCore;
using FiadoCheck_API.Models;

namespace FiadoCheck_API.Context
{
    public class FiadoCheckDbContext : DbContext
    {
        public FiadoCheckDbContext(DbContextOptions<FiadoCheckDbContext> options) : base(options)
        {
        }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<deudas> deudas { get; set; }
        public DbSet<notificaciones> notificaciones { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<usuarios> usuarios { get; set; }


    }
}
