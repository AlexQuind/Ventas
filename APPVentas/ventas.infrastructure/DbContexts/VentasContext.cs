using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure.Configs;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.DbContexts
{
	public class VentasContext : DbContext
	{
		public VentasContext()
		{
		}

		public VentasContext(DbContextOptions<VentasContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseOracle("Data Source=localhost:1521/xe;User ID=ventasQ;Password=123456789");
		}

		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ProductEntity> Product { get; set; }



		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ProductConfig());
			
		}

	}
}
