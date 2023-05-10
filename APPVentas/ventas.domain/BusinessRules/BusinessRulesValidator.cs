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
		const decimal ZERO = 0m;
		//Constantes para Producto
		private const int PRODUCTO_CARACTERES_MINIMO = 3;
		private const string EMPTYNAME = "El nombre del producto no puede estar vacío";
		private const string SHORTNAME = "El nombre del producto debe tener al menos 3 caracteres";
		private const string NEGATIVEPRICE = "El precio del producto debe ser mayor que cero";
		private const string NEGATIVESTOCK = "El stock de productos debe ser mayor o igual a cero";

		///Constantes VentaDetalle
		const string INVALID_QUANTITY_ERROR = "La cantidad de productos vendidos debe ser mayor a cero.";
		const string INVALID_UNIT_PRICE_ERROR = "El precio unitario del producto debe ser mayor a cero.";
		const string INVALID_TAX_ERROR = "El impuesto aplicado a la venta debe ser mayor a cero.";
		const string INVALID_DISCOUNT_ERROR = "El descuento aplicado a la venta debe ser mayor o igual a cero y menor o igual al precio total de la venta.";
		const string INVALID_SHIPPING_COST_ERROR = "El costo de envío debe ser mayor o igual a cero.";


		public static void ValidateProduct(Product product)

		{
			if (string.IsNullOrWhiteSpace(product.Name))
			{
				throw new ArgumentException(EMPTYNAME, nameof(product));
			}

			if (product.Name.Length < PRODUCTO_CARACTERES_MINIMO)
			{
				throw new ArgumentException(SHORTNAME, nameof(product));
			}

			if (product.Price <= ZERO)
			{
				throw new ArgumentException(NEGATIVEPRICE, nameof(product));
			}

			if (product.Stock < ZERO)
			{
				throw new ArgumentException(NEGATIVESTOCK, nameof(product));
			}
		}

		public void CalculateTotalPrice(SaleDetail saleDetail)
		{
			decimal totalPrice = saleDetail.Quantity * saleDetail.UnitPrice;

			// Verificar que la cantidad de productos vendidos sea válida
			if (saleDetail.Quantity <= ZERO)
			{
				throw new ArgumentOutOfRangeException(nameof(saleDetail), INVALID_QUANTITY_ERROR);
			}

			// Verificar que el precio unitario del producto sea válido
			if (saleDetail.UnitPrice <= ZERO)
			{
				throw new ArgumentOutOfRangeException(nameof(saleDetail), INVALID_UNIT_PRICE_ERROR);
			}


			// Verificar que el impuesto aplicado a la venta sea válido
			if (saleDetail.Tax <= ZERO)
			{
				throw new ArgumentOutOfRangeException(nameof(saleDetail), INVALID_TAX_ERROR);
			}

			// Verificar que el descuento aplicado a la venta sea válido
			if (saleDetail.Discount < ZERO || saleDetail.Discount > totalPrice)
			{
				throw new ArgumentOutOfRangeException(nameof(saleDetail), INVALID_DISCOUNT_ERROR);
			}

			// Verificar que el costo de envío sea válido
			if (saleDetail.ShippingCost < ZERO)
			{
				throw new ArgumentOutOfRangeException(nameof(saleDetail), INVALID_SHIPPING_COST_ERROR);
			}

			totalPrice = totalPrice + saleDetail.Tax - saleDetail.Discount + saleDetail.ShippingCost;

			saleDetail.TotalPrice = totalPrice;
		}
	}
}
