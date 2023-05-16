using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.BusinessRules;
using ventas.domain.model;
using ventas.domain.ports.repositories;
using ventas.infrastructure.DbContexts;
using ventas.infrastructure.Mappers;

namespace ventas.infrastructure.adapters.Secondary
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly VentasContext _dbContext;

		public CategoryRepository(VentasContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task AddAsync(Category category)
		{
			var categoryEntity = CategoryMapper.ToEntity(category);
			await _dbContext.Categories.AddAsync(categoryEntity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Category?> GetCategoryById(int id)
		{
			var categoryEntity = await _dbContext.Categories.FirstOrDefaultAsync(p => p.Id == id);
			return categoryEntity == null ? throw new ProductoNoEncontradoException(id) : CategoryMapper.ToModel(categoryEntity);
		}

		public async Task UpdateAsync(Category category)
		{
			_dbContext.Entry(category).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
