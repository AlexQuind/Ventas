using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.application.DTOs
{
	public static class  MapDTO
	{
		public static ProductDTO MapProducto(Product product)
		{
			return new ProductDTO
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price
			};
		}
	}
}
