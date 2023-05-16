﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.infrastructure.Entidades
{
	public class ProductEntity
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public int CategoryId { get; set; }
		public	CategoryEntity? Category { get; set; }
	}
}
