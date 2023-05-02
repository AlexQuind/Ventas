using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.repositories
{
	public interface ISaleRepository
	{
		Task<Sale> GetByIdAsync(int id);
		Task<List<Sale>> GetAllAsync();
		Task<int> AddAsync(Sale sale);
	}
}
