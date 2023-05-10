﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.domain.model
{
	public class Sale
	{
		public int Id { get; set; }
		
		public List<Product> Products { get; set; } = new List<Product>();
		public decimal Total { get; set; }
	}
}
