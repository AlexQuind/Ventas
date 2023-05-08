using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
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
			//IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
			//IConfigurationRoot root = builder.Build();

			//optionsBuilder.UseSqlServer(root["ConnectionStrings:Financiero"]);

			optionsBuilder.UseSqlServer("Data Source=DEV_Alexander\\SQLEXPRESS;Initial Catalog=DbVentas; Integrated Security=True;TrustServerCertificate=True");
		}

		public DbSet<ProductEntity> Product { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ProductConfig());
		}

	}
}
