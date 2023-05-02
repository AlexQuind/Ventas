using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.domain.model;
using ventas.infrastructure.adapters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ventas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductoAdapter _productoAdapter;

		public ProductController(IProductoAdapter productoAdapter)
		{
			_productoAdapter = productoAdapter;
		}

		// GET api/<ProductController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var product = _productoAdapter.ObtenerProductoPorId(id);

			if (product == null)
			{
				return NotFound();
			}

			var productModel = new ProductDTO
			{
				Id = product.Id,
				Name = product.Name,
				Price = product.Price
			};

			return Ok(productModel);
		}

		// POST api/<ProductController>
		[HttpPost]
		public IActionResult Post([FromBody] ProductDTO productModel)
		{
			var product = new Product
			{
				Name = productModel.Name,
				Price = productModel.Price
			};

			_productoAdapter.CrearProducto(productModel);

			productModel.Id = product.Id;

			return CreatedAtAction(nameof(Get), new { id = product.Id }, productModel);
		}

	}
}
