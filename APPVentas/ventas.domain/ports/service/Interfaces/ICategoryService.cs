using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.service.Interfaces
{
	public interface ICategoryService
	{
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
	}
}
