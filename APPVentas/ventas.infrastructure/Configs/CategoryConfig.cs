using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Configs
{
	public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
	{
		public void Configure(EntityTypeBuilder<CategoryEntity> builder)
		{
			builder.ToTable("Category");
			builder.HasKey(c => c.Id);

			builder.Property(x => x.Name)
				   .HasMaxLength(50)
				   .IsRequired();

			//una categoría puede tener muchos productos
			builder.HasMany(c => c.Products)
			.WithOne(p => p.Category)
			.HasForeignKey(p => p.CategoryId);
		}
	}
}
