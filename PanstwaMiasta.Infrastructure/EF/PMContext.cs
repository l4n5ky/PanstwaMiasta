using Microsoft.EntityFrameworkCore;
using PanstwaMiasta.Core.Models;

namespace PanstwaMiasta.Infrastructure.EF
{
    public class PMContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        //public DbSet<Room> Rooms { get; set; }

        public PMContext(DbContextOptions<PMContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PanstwaMiasta;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
