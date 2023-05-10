using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.domain.model;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Mappers
{
	public static class ProductMapper
	{
		public static Product ToModel(ProductEntity productEntity)
		{
			return new Product
			{
				Id = productEntity.Id,
				Name = productEntity.Name,
				Price = productEntity.Price,
				Stock = productEntity.Stock
			};
		}

		public static ProductEntity toEntity(Product productModel) {
			return new ProductEntity
			{
				Id = productModel.Id,
				Name = productModel.Name,
				Price = productModel.Price,
				Stock = productModel.Stock
			};
		}
	}
}
