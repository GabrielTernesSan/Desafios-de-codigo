using Infra.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Context : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer("Server=localhost,1433;Database=UolHost;User ID=sa;Password=G@abriel613390;TrustServerCertificate=True;");
    }
}
