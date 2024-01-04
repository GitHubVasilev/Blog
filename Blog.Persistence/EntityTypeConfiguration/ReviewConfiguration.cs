using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistence.EntityTypeConfiguration
{
    /// <summary>
    /// Класс для конфигурации сущности `Review`
    /// </summary>
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Id)
                .IsUnique();
            builder.Property(m => m.Content)
                .HasMaxLength(1024)
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
