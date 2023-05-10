using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.domain.model
{
	public class Client
	{
		public int Id { get; set; }
		public string? TypeIdentification { get; set; }
		public string? Document {get; set; }
		public string? Name { get; set; }
		public string? lastName { get; set; }
		public string? Email { get; set; }
		public string? Phone { get; set; }
		public ICollection<Sale>? Sales { get; set; }

	}
}
