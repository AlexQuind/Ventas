using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Configs
{
	//public class SaleConfig : IEntityTypeConfiguration<SaleEntity>
	//{
	//	public void Configure(EntityTypeBuilder<SaleEntity> builder)
	//	{
	//		builder.ToTable(nameof(SaleEntity));
	//		builder.HasKey(s => s.Id);

	//		builder.Property(s => s.Fecha)
	//		.IsRequired();

	//		builder.HasOne(s => s.Client)
	//		.WithMany(c => c.Sales)
	//		.HasForeignKey(s => s.ClienId);

	//		builder.HasMany(s => s.SaleDetails)
	//	   .WithOne(sd => sd.Sale)
	//	   .HasForeignKey(sd => sd.SaleId);
	//	}
	//}
}
