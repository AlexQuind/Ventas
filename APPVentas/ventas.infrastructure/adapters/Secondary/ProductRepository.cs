using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.domain.ports.repositories;
using ventas.infrastructure.Context;

namespace ventas.infrastructure.Adapters.Secondary
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductContext _dbContext;
		public ProductRepository(ProductContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Product> GetProductById(int id)
		{
			var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
			if (product == null)
			{
				throw new Exception("Producto no encontrado");
			}
			return product;
		}

		public async Task<IEnumerable<Product>> GetProducts()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
			if (product != null)
			{
				_dbContext.Products.Remove(product);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task AddAsync(Product product)
		{
			await _dbContext.Products.AddAsync(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			_dbContext.Products.Update(product);
			await _dbContext.SaveChangesAsync();
		}
	}
}
