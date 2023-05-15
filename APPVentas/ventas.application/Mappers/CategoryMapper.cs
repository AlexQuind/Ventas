using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.domain.model;

namespace ventas.application.Mappers
{
	public static class CategoryMapper
	{
		public static CategoryDTO ToDTO(Category category)
		{
			return new CategoryDTO
			{
				Id = category.Id,
				Name = category.Name,
				Products = category.Products?.Select(p => ProductMapper.ToDTO(p)).ToList()
			};
		}

		public static Category ToDomain(CategoryDTO categoryDTO)
		{
			return new Category
			{
				Id = categoryDTO.Id,
				Name = categoryDTO.Name,
				Products = categoryDTO.Products?.Select(p => ProductMapper.ToDomain(p)).ToList()
			};
		}
	}
}
