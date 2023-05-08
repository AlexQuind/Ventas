using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.model;

namespace ventas.domain.BusinessRules
{

	public class ProductoNoEncontradoException : Exception
	{
		public ProductoNoEncontradoException(int id) : base($"El producto con Id {id} no fue encontrado.")
		{
		}
	}
	public class BusinessRulesValidator
	{
		private const string EMPTYNAME = "El nombre del producto no puede estar vacío";
		private const string SHORTNAME = "El nombre del producto debe tener al menos 3 caracteres";
		private const string NEGATIVEPRICE = "El precio del producto debe ser mayor que cero";
		private const string NEGATIVESTOCK = "El stock de productos debe ser mayor o igual a cero";
		private const string DUPLICATENAME = "Ya existe un producto con el mismo nombre";

		public static void ValidateProduct(Product product, Func<int, bool> isProductExists)
		{
			if (string.IsNullOrWhiteSpace(product.Name))
			{
				throw new ArgumentException(EMPTYNAME, nameof(product));
			}

			if (product.Name.Length < 3)
			{
				throw new ArgumentException(SHORTNAME, nameof(product));
			}

			if (product.Price <= 0)
			{
				throw new ArgumentException(NEGATIVEPRICE, nameof(product));
			}

			if (product.Stock < 0)
			{
				throw new ArgumentException(NEGATIVESTOCK, nameof(product));
			}

			if (isProductExists(product.Id))
			{
				throw new ArgumentException(DUPLICATENAME, nameof(product));
			}
		}
	}
}
