using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
			ValidateProduct(product);

			await _productRepository.AddAsync(product);
		}

		public async Task DeleteProductAsync(int id)
		{
			var existingProduct = await _productRepository.GetProductById(id);

			if (existingProduct == null)
			{
				throw new Exception("Producto no Encontrado");
			}

			await _productRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<Product>> GetAllProductsAsync()
		{
			return await _productRepository.GetProducts();
		}

		public async Task<Product> GetProductByIdAsync(int id)
		{
			var product = await _productRepository.GetProductById(id);

			if (product == null)
			{
				throw new Exception("Producto no encontrado");
			}

			return product;
		}

		public async Task UpdateProductAsync(Product product)
		{
			var existingProduct = await _productRepository.GetProductById(product.Id);
			if (existingProduct == null)
			{
				throw new ArgumentException("Producto no encontrado", nameof(product));
			}

			ValidateProduct(product);

			await _productRepository.UpdateAsync(product);
		}

		private void ValidateProduct(Product product)
		{
			if (string.IsNullOrEmpty(product.Name))
			{
				throw new ArgumentException("El nombre del producto no puede estar vacío", nameof(product));
			}

			if (product.Name.Length < 3)
			{
				throw new ArgumentException("El nombre del producto debe tener al menos 3 caracteres.");
			}

			if (product.Price <= 0)
			{
				throw new ArgumentException("El precio del producto debe ser mayor que cero", nameof(product));
			}

			if (product.Stock < 0)
			{
				throw new ArgumentException("El stock de productos debe ser mayor o igual a cero", nameof(product));
			}
		}
	}
}

