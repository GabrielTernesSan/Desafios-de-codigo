using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Tables.Mapping
{
    internal class LigaMapping : IEntityTypeConfiguration<LigaDaJustica>
    {
        public void Configure(EntityTypeBuilder<LigaDaJustica> builder)
        {
            builder.ToTable("LigaDaJustica");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.codinome);
        }
    }
}
