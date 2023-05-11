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
	public class SaleDetailConfig : IEntityTypeConfiguration<SaleDetailEntity>
	{
		public void Configure(EntityTypeBuilder<SaleDetailEntity> builder)
		{
			builder.ToTable("SaleDetail");
			builder.HasKey(x => x.Id);
		}
	}
}
