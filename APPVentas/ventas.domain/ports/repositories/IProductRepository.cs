using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.repositories
{
	public interface IProductRepository
	{
		Task<Product> GetProductById(int id);
		Task<Product> GetProductByName(string name);
		Task<List<Product>> GetProducts();
		Task AddAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(int id);

	}
}
