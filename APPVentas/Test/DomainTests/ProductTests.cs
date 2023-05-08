using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ventas.domain.model;

namespace Test.DomainTests
{
	public class ProductTests
	{
		[Fact]
		public void ProductConstructor_ValidParameters_CreatesProductObject()
		{
			// Arrange
			var id = 1;
			var name = "Test Product";
			var price = 9.99m;
			var stock = 4;

			// Act
			var product = new Product(id, name, price,stock);

			// Assert
			Assert.Equals(id, product.Id);
			Assert.Equals(name, product.Name);
			Assert.Equals(price, product.Price);
			Assert.Equals(stock, product.Stock);
		}
	}
}
