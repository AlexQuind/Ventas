using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.application.UseCases.Interfaces;
using ventas.domain.model;
using ventas.domain.ports.service.Interfaces;

namespace ventas.application.UseCases	
{
	public class ProductUseCase : IProductUseCase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductUseCase(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		public  Task CreateProductAsync(ProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);
			return _productService.CreateProductAsync(product);
		}

		public async Task<ProductDTO> GetProductByIdAsync(int id)
		{
			var product = await _productService.GetProductByIdAsync(id);
			return _mapper.Map<ProductDTO>(product);
		}

		public Task UpdateProduct(ProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO);
			return _productService.UpdateProductAsync(product);
		}

		public Task DeleteProduct(int id)
		{
			return _productService.DeleteProductAsync(id);
		}

		public async Task<List<ProductDTO>> GetAllProductsAsync()
		{
			var products = await _productService.GetAllProductsAsync();
			return _mapper.Map<List<ProductDTO>>(products);
		}
	}
}
