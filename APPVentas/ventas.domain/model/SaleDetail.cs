using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.domain.model
{
	public class SaleDetail
	{
		public int Id { get; set; }
		public int SaleId { get; set; }
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice { get; set; }
		public decimal Tax { get; set; }
		public decimal Discount { get; set; }
		public decimal ShippingCost { get; set; }

		public Sale? Sale { get; set; }
		public Product? Product { get; set; }
	}
}
