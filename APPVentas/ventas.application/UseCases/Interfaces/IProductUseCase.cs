using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.DTOs;
using ventas.domain.model;

namespace ventas.application.UseCases.Interfaces
{
    public interface IProductUseCase
    {
		Task CreateProductAsync(ProductDTO product);
		Task<ProductDTO> GetProductByIdAsync(int id);
		Task<List<ProductDTO>> GetAllProductsAsync();
		Task UpdateProduct(ProductDTO product);
		Task DeleteProduct(int id);
	}
}
