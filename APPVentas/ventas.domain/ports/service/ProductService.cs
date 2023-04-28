using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.domain.ports.repository;

namespace ventas.domain.ports.service
{
	public class ProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productoPuerto)
		{
			_productRepository = productoPuerto;
		}

		public List<Product> ObtenerTodosLosProductos()
		{
			return _productRepository.ObtenerTodosLosProductos();
		}

		public Product ObtenerProductoPorId(int id)
		{
			var producto = _productRepository.ObtenerProductoPorId(id);

			if (producto == null)
			{
				throw new Exception($"El producto con el Id {id} no existe.");
			}

			return producto;
		}

		public void CrearProducto(Product product)
		{
			if (string.IsNullOrEmpty(product.Name))
			{
				throw new Exception("El nombre del producto es requerido.");
			}

			if (product.Price <= 0)
			{
				throw new Exception("El precio del producto debe ser mayor que cero.");
			}

			_productRepository.CrearProducto(product);
		}
	}
}
