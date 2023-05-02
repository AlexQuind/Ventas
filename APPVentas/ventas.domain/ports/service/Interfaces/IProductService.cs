using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.service.Interfaces
{
    public interface IProductService
    {
		Task CreateProductAsync(Product product);
		Task<Product> GetProductByIdAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
		Task UpdateProductAsync(Product product);
		Task DeleteProductAsync(int id);
	}
}
