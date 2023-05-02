using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.application.DTOs
{
	public class SaleDTO
	{
		public int Id { get; set; }
		public DateTime Fecha { get; set; }
		public List<ProductDTO> Productos { get; set; } = new List<ProductDTO>();
		public decimal Total { get; set; }
	}
}
