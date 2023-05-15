using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Mappers
{
	public static class CategoryMapper
	{
		public static Category ToModel(CategoryEntity categoryEntity)
		{
			
			return new Category
			{
				Id = categoryEntity.Id,
				Name = categoryEntity.Name,
				Products = categoryEntity.Products?.Select(p => p.ToModel()).ToList()

			};
		}

		public static CategoryEntity ToEntity(Category categoryModel)
		{
			return new CategoryEntity
			{
				Id = categoryModel.Id,
				Name = categoryModel.Name,
				Products = categoryModel.Products?.Select(p => ProductMapper.ToEntity(p)).ToList()			};
		}
	}
}
