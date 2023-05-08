using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Configs
{
	public class ProductConfig : IEntityTypeConfiguration<ProductEntity>
	{ 
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				   .HasMaxLength(50)

				   .IsRequired();

			builder.Property(x => x.Price)
				   .HasColumnType("decimal(18,2)")
				   .IsRequired();

			builder.Property(x => x.Stock)
				   .IsRequired();
		}
	}
}
