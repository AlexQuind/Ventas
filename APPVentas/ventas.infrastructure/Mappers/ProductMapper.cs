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
		public static Product ToModel(this ProductEntity productEntity)
		{
			return new Product
			{
				Id = productEntity.Id,
				Name = productEntity.Name,
				Price = productEntity.Price,
				Stock = productEntity.Stock,
				CategoryId = productEntity.CategoryId,
				Category = productEntity.Category != null ? CategoryMapper.ToModel(productEntity.Category) : null
			};
		}

		public static ProductEntity ToEntity(Product productModel) {
			return new ProductEntity
			{
				Id = productModel.Id,
				Name = productModel.Name,
				Price = productModel.Price,
				Stock = productModel.Stock,
				CategoryId = productModel.CategoryId,
				Category = productModel.Category != null ? CategoryMapper.ToEntity(productModel.Category) : null
			};
		}
	}
}
