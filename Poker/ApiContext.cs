
using Microsoft.EntityFrameworkCore;

namespace Poker.Entities
{
    public class ApiContext : DbContext
    {
        public ApiContext()
          : base(new DbContextOptionsBuilder<ApiContext>().UseInMemoryDatabase(databaseName: "EmMemoria").Options)
        {
            
        }

        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<User> Users { get; set; }

    }
}