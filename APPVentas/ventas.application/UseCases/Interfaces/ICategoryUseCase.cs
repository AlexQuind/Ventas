using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;

namespace ventas.application.UseCases.Interfaces
{
	public interface ICategoryUseCase
	{
		Task CreateCategoryAsync(CategoryDTO category);
		Task UpdateCategoryAsync(CategoryDTO category);
	}
}
