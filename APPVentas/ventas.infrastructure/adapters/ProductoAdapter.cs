using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;
using ventas.domain.ports.repository;

namespace ventas.infrastructure.adapters
{
	public class ProductoAdapter : IProductRepository
	{

		private List<Product> _productos = new List<Product>
		{
			new Product { Id = 1, Name = "Producto 1", Price = 1000 },
			new Product { Id = 2, Name = "Producto 2", Price = 2000 },
			new Product { Id = 3, Name = "Producto 3", Price = 3000 },
		};
		public void CrearProducto(Product product)
		{
			var ultimoId = _productos.Max(p => p.Id);
			product.Id = ultimoId + 1;

			_productos.Add(product);
		}

		public Product ObtenerProductoPorId(int id)
		{
			return _productos.FirstOrDefault(p => p.Id == id);
		}

		public List<Product> ObtenerTodosLosProductos()
		{
			return _productos;
		}
	}
}
