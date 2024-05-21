using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EntityTypeConfiguration
{
    /// <summary>
    /// Класс для конфигурации сущности `Entry`
    /// </summary>
    public class EntryConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Id)
                .IsUnique();
            builder.Property(m => m.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(m => m.Content)
                .IsRequired();
            builder.Property(m => m.CreatedBy)
                .HasMaxLength(256)
                .IsRequired();
            builder.Property(m => m.CreatedAt)
                .IsRequired();
            builder.Property(m => m.UpdatedBy)
                .HasMaxLength(256);
        }
    }
}
