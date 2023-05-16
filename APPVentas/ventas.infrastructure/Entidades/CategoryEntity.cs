using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.infrastructure.Entidades
{
	public class CategoryEntity
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public List<ProductEntity>? Products { get; set; }

	}
}
