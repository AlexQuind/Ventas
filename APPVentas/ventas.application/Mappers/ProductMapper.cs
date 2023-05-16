using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.domain.model;

namespace ventas.application.Mappers
{
	public static class ProductMapper
	{
		public static ProductDTO ToDTO(Product productDomain)
		{
			return new ProductDTO
			{
				Id = productDomain.Id,
				Name = productDomain.Name,
				Price = productDomain.Price,
				Stock = productDomain.Stock,
				CategoryId = productDomain.CategoryId
			};
		}
		public static Product ToDomain(ProductDTO productDTO)
		{
			return new Product
			{
				Id = productDTO.Id,
				Name = productDTO.Name,
				Price = productDTO.Price,
				Stock = productDTO.Stock,
				CategoryId = productDTO.CategoryId
			};
		}
	}
}
