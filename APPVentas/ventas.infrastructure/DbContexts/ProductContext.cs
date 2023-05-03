﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.infrastructure.Context
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options)
		{
		}
		public DbSet<Product> Product { get; set; }

    }
}