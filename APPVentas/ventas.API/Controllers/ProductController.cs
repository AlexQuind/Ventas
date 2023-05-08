using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.application.UseCases.Interfaces;
using ventas.infrastructure.Maestras;
using static ventas.infrastructure.Maestras.MensajeBase;

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
			try
			{
				await _productUseCase.CreateProductAsync(productDTO);
				return Ok(Satisfactory.Insertado.GetEnumDescription());
			}
			catch (Exception ex)
			{
				return StatusCode(500,Error.Insertar.GetEnumDescription() + ex.Message);
			}
		}

		[HttpPut("{id}")]

		public async Task<IActionResult> UpdateProduct(int id, ProductDTO product)
		{
			try
			{
				if (id != product.Id)
				{
					throw new ArgumentException(Excepcion.Actualizar.GetEnumDescription());
				}

				await _productUseCase.UpdateProduct(product);

				return Ok(Satisfactory.Actualizado.GetEnumDescription());
			}
			catch (Exception ex)
			{
				throw new Exception(Error.Actualizar.GetEnumDescription(), ex);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			await _productUseCase.DeleteProduct(id);
			return Ok(Satisfactory.Eliminado.GetEnumDescription());
		}	
	}
}
