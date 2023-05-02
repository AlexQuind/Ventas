using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.domain.model
{
	public class Sale
	{
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public List<Product> products { get; set; } = new List<Product>();
		public decimal Total { get; set; }
	}
}
