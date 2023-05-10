using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ventas.domain.BusinessRules;
using ventas.domain.model;
using ventas.domain.ports.repositories;
using ventas.domain.ports.service.Interfaces;

namespace ventas.domain.ports.service
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task CreateProductAsync(Product product)
		{
			// Validate the product using a business rule validator
			BusinessRulesValidator.ValidateProduct(product);

			// Add the product to the repository
			await _productRepository.AddAsync(product);
		}

		public async Task DeleteProductAsync(int id)
		{
			if (await _productRepository.GetProductById(id) == null)
			{
				throw new ProductoNoEncontradoException(id);
			}

			await _productRepository.DeleteAsync(id);

			return;
		}

		public async Task<List<Product>> GetAllProductsAsync()
		{
			return await _productRepository.GetProducts();
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			return await _productRepository.GetProductById(id) ?? throw new ProductoNoEncontradoException(id);
		}

		public async Task UpdateProductAsync(Product product)
		{
			// Check if product exists in the repository
			var existingProduct = await _productRepository.GetProductById(product.Id) ?? throw new ProductoNoEncontradoException(product.Id);

			// Validate the updated product using a business rule validator
			BusinessRulesValidator.ValidateProduct(product);

			// Update the product in the repository
			existingProduct.Name = product.Name;
			existingProduct.Price = product.Price;
			existingProduct.Stock = product.Stock;
			await _productRepository.UpdateAsync(existingProduct);
		}
	}
}
