using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.application.UseCases.Interfaces;
using ventas.domain.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ventas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductUseCase _productUseCase;

		public ProductController(IProductUseCase productUseCase)
		{
			_productUseCase = productUseCase;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var products = await _productUseCase.GetAllProductsAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDTO>> GetByIdAsync(int id)
		{
			var product = await _productUseCase.GetProductByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return product;
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
		{
			await _productUseCase.CreateProductAsync(productDTO);
			return CreatedAtAction(nameof(GetByIdAsync), new { id = productDTO.Id }, productDTO);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO)
		{
			if (id != productDTO.Id)
			{
				return BadRequest();
			}
			await _productUseCase.UpdateProduct(productDTO);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _productUseCase.DeleteProduct(id);
			return Ok("El Producto ha sido eliminado satisfactoriamente");
		}	
	}
}
