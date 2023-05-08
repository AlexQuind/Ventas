using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.domain.ports.repositories;
using ventas.infrastructure.DbContexts;
using ventas.infrastructure.Entidades;

namespace ventas.infrastructure.Adapters.Secondary
{
	public class ProductRepository : IProductRepository
	{
		private readonly VentasContext _dbContext;
		private readonly IMapper _mapper;

		public ProductRepository(VentasContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<Product> GetProductById(int id)
		{
			var productEntity = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
			return productEntity == null ? throw new Exception("Producto no encontrado") : _mapper.Map<Product>(productEntity);
		}

		public async Task<List<Product>> GetProducts()
		{
			var productEntities = await _dbContext.Product.ToListAsync();
			return _mapper.Map<List<Product>>(productEntities);
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
			var productEntity = _mapper.Map<ProductEntity>(product);
			await _dbContext.Product.AddAsync(productEntity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			var productSelect = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == product.Id);
			if (productSelect !=null) {
				productSelect.Name = product.Name;
				productSelect.Price = product.Price;
				productSelect.Stock = product.Stock;

				_dbContext.Entry(productSelect).State = EntityState.Modified;
				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
