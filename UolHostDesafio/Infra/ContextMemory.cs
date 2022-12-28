using Infra.Tables;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class ContextMemory : DbContext
    {
        public ContextMemory(DbContextOptions<ContextMemory> options)
          : base(options)
        { }

        public DbSet<Vingador> Vingadores { get; set; }
    }
}
