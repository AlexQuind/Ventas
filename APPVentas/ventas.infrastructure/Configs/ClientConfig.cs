using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Configs
{
	//internal class ClientConfig : IEntityTypeConfiguration<ClientEntity>
	//{
	//	public void Configure(EntityTypeBuilder<ClientEntity> builder)
	//	{
	//			builder.ToTable("Clients");

	//		builder.HasKey(c => c.Id);

	//		builder.Property(c => c.TypeIdentification)
	//			.HasMaxLength(50);

	//		builder.Property(c => c.Document)
	//			.HasMaxLength(50);

	//		builder.Property(c => c.Name)
	//			.HasMaxLength(100)
	//			.IsRequired();

	//		builder.Property(c => c.LastName)
	//			.HasMaxLength(100)
	//			.IsRequired();

	//		builder.Property(c => c.Email)
	//			.HasMaxLength(150);

	//		builder.Property(c => c.Phone)
	//			.HasMaxLength(20);

	//		builder.HasMany(c => c.Sales)
	//			.WithOne(s => s.Client)
	//			.HasForeignKey(s => s.ClienId);
	//	}
	//}
}
