using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.BusinessRules;
using ventas.domain.model;
using ventas.domain.ports.repositories;
using ventas.domain.ports.service.Interfaces;

namespace ventas.domain.ports.service
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public async Task CreateCategoryAsync(Category category)
		{
			// Add the category to the repository
			await _categoryRepository.AddAsync(category);
		}

		public async Task UpdateCategoryAsync(Category category)
		{
			// Check if category exists in the repository
			var existingCategory = await _categoryRepository.GetCategoryById(category.Id) ??
								   throw new CategoriaNoEncontradaException(category.Id);

			// Validate the updated category using a business rule validator
			//BusinessRulesValidator.ValidateCategory(category);

			// Update the category in the repository
			existingCategory.Name = category.Name;

			await _categoryRepository.UpdateAsync(existingCategory);
		}
	}
}
	