using FirstApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Configurations.ProductConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(20).IsRequired();
            builder.Property(b => b.SoldPrice).HasColumnType("decimal(6,2)").IsRequired();
            builder.Property(b => b.CostPrice).HasColumnType("decimal(6,2)").IsRequired();
            builder.Property(b => b.DisplayStatis).HasDefaultValue(true);     

        }
    }
}
