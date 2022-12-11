using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Sqlite.Config
{
    internal class MyModelConfig : IEntityTypeConfiguration<MyModel>
    {
        public void Configure(EntityTypeBuilder<MyModel> builder)
        {
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(20).IsRequired(true);
        }
    }
}
