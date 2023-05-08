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
			BusinessRulesValidator.ValidateProduct(product, productId =>
			{
				return _productRepository.GetProductByName(product.Name) .Result? .Id != productId;
			});
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
			var existingProduct = await _productRepository.GetProductById(product.Id) ?? throw new ArgumentException($"Producto {product} no existe");
			existingProduct.Name = product.Name;
			existingProduct.Price = product.Price;
			existingProduct.Stock = product.Stock;
			BusinessRulesValidator.ValidateProduct(existingProduct, productId =>
			{
				// Comprueba si ya existe un producto con el mismo nombre, pero distinto ID
				var productByName = _productRepository.GetProductByName(product.Name).Result;
				return productByName != null && productByName.Id != productId;
			});

			await _productRepository.UpdateAsync(existingProduct);
		}
	}
}
