using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Tables.Mapping
{
    public class VingadorMapping : IEntityTypeConfiguration<Vingador>
    {
        public void Configure(EntityTypeBuilder<Vingador> builder)
        {
            builder.ToTable("Vingadores");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.codinome);
        }
    }
}
