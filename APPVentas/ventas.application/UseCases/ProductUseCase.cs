using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.application.Mappers;
using ventas.application.UseCases.Interfaces;
using ventas.domain.model;
using ventas.domain.ports.service.Interfaces;

namespace ventas.application.UseCases	
{
	public class ProductUseCase : IProductUseCase
	{
		private readonly IProductService _productService;

		public ProductUseCase(IProductService productService)
		{
			_productService = productService;
		}

		public  Task CreateProductAsync(ProductDTO productDTO)
		{
			var product = ProductMapper.ToDomain(productDTO);
			return _productService.CreateProductAsync(product);
		}

		public async Task<ProductDTO> GetProductByIdAsync(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);
			return ProductMapper.ToDTO(product);
		}

		public Task UpdateProduct(ProductDTO productDTO)
		{
			var product = ProductMapper.ToDomain(productDTO);
			return _productService.UpdateProductAsync(product);
		}

		public Task DeleteProduct(int id)
		{
			return _productService.DeleteProductAsync(id);
		}

		public async Task<List<ProductDTO>> GetAllProductsAsync()
		{
			var products = await _productService.GetAllProductsAsync();
			return products.Select(pe => ProductMapper.ToDTO(pe)).ToList();
		}
	}
}
