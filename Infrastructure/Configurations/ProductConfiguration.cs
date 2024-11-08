using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Name).HasMaxLength(100);

        builder.Property(product => product.Date).IsRequired();

        builder.Property(product => product.Price).IsRequired().HasColumnType("decimal(18, 2)");

        builder.Property(product => product.MarginPercentage).IsRequired().HasColumnType("decimal(18, 2)");
    }
}