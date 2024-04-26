using Poker.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Poker
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Mesa_Poker> Mesa_Pokers { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=RAILSON-PC;Database=Poker;Trusted_Connection=True;TrustServerCertificate=True");
            optionsBuilder.UseInMemoryDatabase("EmMemoria");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(u => u.UserId);
            builder.Entity<Mesa_Poker>().HasKey(p => p.TableId);
            builder.Entity<Mesa>().HasKey(p => p.id_mesa);
        }
    }
}
