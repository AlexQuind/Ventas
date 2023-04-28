using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.ports.repository
{
	public interface IProductRepository
	{
		Product ObtenerProductoPorId(int id);
		List<Product> ObtenerTodosLosProductos();
		void CrearProducto(Product product);
	}
}
