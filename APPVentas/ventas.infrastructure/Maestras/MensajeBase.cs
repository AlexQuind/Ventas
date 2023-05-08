using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ventas.infrastructure.Maestras
{
	public static class MensajeBase
	{
		public enum Satisfactory
		{
			[Description("Guardado Correctamente")]
			Insertado,
			[Description("Actualizado Correctamente")]
			Actualizado,
			[Description("Eliminado Correctamente")]
			Eliminado
		}


		public enum Error
		{
			[Description("No se pudo insertar, verifique que los datos estén correctos o comuníquese con el área de TI")]
			Insertar,
			[Description("No se pudo actualizar, verifique que los datos estén correctos o comuníquese con el área de TI")]
			Actualizar,
			[Description("No se pudo eliminar, verifique que los datos estén correctos o comuníquese con el área de TI")]
			Eliminar
		}

		public enum Excepcion
		{
			[Description("El ID del producto proporcionado no coincide con el ID de la ruta.")]
			Actualizar
		}

		public static string GetEnumDescription(this Enum value)
		{
			return value.GetType().GetMember(value.ToString()).FirstOrDefault()?.GetCustomAttributes(false).OfType<DescriptionAttribute>()
				.FirstOrDefault()?.Description?? value.ToString();
		}
	}
}
