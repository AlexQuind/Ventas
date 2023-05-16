using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.application.Mappers;
using ventas.application.UseCases.Interfaces;
using ventas.domain.ports.service;
using ventas.domain.ports.service.Interfaces;

namespace ventas.application.UseCases
{
	public class CategoryUseCase : ICategoryUseCase
	{
		private readonly ICategoryService _categoryService;

		public CategoryUseCase(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public Task CreateCategoryAsync(CategoryDTO categoryDTO)
		{
			var category = CategoryMapper.ToDomain(categoryDTO);
			return _categoryService.CreateCategoryAsync(category);
		}

		public Task UpdateCategoryAsync(CategoryDTO categoryDTO)
		{
			var product = CategoryMapper.ToDomain(categoryDTO);
			return _categoryService.UpdateCategoryAsync(product);
		}
	}
}
