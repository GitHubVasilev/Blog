using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EntityTypeConfiguration
{
    /// <summary>
    /// Класс для конфигурации сущности `Category`
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Id)
                .IsUnique();
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
