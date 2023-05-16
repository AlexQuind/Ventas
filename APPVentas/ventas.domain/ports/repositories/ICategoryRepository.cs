using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.repositories
{
	public interface ICategoryRepository
	{
		Task AddAsync(Category category);
		Task<Category?> GetCategoryById(int id);
		Task UpdateAsync(Category category);
	}
}
