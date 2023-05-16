	using AutoMapper;
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

	namespace ventas.infrastructure.Adapters.Secondary
	{
		public class ProductRepository : IProductRepository
		{
			private readonly VentasContext _dbContext;

			public ProductRepository(VentasContext dbContext)
			{
				_dbContext = dbContext;
			}

			public async Task<Product> GetProductById(int id)
			{
				var productEntity = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
				return productEntity == null ? throw new ProductoNoEncontradoException(id) : ProductMapper.ToModel(productEntity);
			}

			public async Task<List<Product>> GetProducts()
			{
				var productEntities = await _dbContext.Product.ToListAsync();
				return productEntities.Select(pe => ProductMapper.ToModel(pe)).ToList();
			}

			public async Task DeleteAsync(int id)
			{
				var product = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
				if (product != null)
				{
					_dbContext.Product.Remove(product);
					await _dbContext.SaveChangesAsync();
				}
			}

			public async Task AddAsync(Product product)
			{
				var productEntity = ProductMapper.ToEntity(product);
				await _dbContext.Product.AddAsync(productEntity);
				await _dbContext.SaveChangesAsync();
			}

			public async Task UpdateAsync(Product product)
			{
				var productSelect = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == product.Id);
				if (productSelect != null)
				{
					productSelect.Name = product.Name;
					productSelect.Price = product.Price;
					productSelect.Stock = product.Stock;
					productSelect.CategoryId = product.CategoryId;


				_dbContext.Entry(productSelect).State = EntityState.Modified;
					await _dbContext.SaveChangesAsync();
				}
			}
		}
	}
