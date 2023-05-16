using Microsoft.AspNetCore.Mvc;
using static ventas.infrastructure.Maestras.MensajeBase;
using ventas.application.DTOs;
using ventas.application.UseCases.Interfaces;
using ventas.application.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ventas.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{

		private readonly ICategoryUseCase _categoryUseCase;

		public CategoryController(ICategoryUseCase categoryUseCase)
		{
			_categoryUseCase = categoryUseCase;
		}
		// POST api/<CategoryController>
		[HttpPost]
		public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
		{
			try
			{
				await _categoryUseCase.CreateCategoryAsync(categoryDTO);
				return Ok(Satisfactory.Insertado.GetEnumDescription());
			}
			catch (Exception ex)
			{
				return StatusCode(500, Error.Insertar.GetEnumDescription() + ", " + ex.Message);
			}
		}

		// PUT api/<CategoryController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateCategory(int id, CategoryDTO category)
		{
			try
			{
				if (id != category.Id)
				{
					throw new ArgumentException(Excepcion.Actualizar.GetEnumDescription());
				}

				await _categoryUseCase.UpdateCategoryAsync(category);

				return Ok(Satisfactory.Actualizado.GetEnumDescription());
			}
			catch (Exception ex)
			{
				throw new Exception(Error.Actualizar.GetEnumDescription(), ex);
			}
		}
	}
}
