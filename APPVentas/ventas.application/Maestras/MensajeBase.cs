using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.application.Maestras
{
	public static class MensajeBase
	{
		public enum satisfactory
		{
			[Description("Guardado Correctamente")]
			Insertado,
			[Description("Actualizado Correctamente")]
			Actualizado,
			[Description("Eliminado Correctamente")]
			Eliminado
		}
	}
}
