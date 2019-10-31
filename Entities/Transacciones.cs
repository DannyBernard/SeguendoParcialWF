using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Transacciones
	{
		[Key]
		public int TransanccionesID { get; set; }
		public DateTime Fecha  { get; set; }
		public String Tipo { get; set; }
		public decimal Monto { get; set; }

		public Transacciones()
		{
			TransanccionesID = 0;
			Fecha = DateTime.Now;
			Tipo = string.Empty;
			Monto = 0;
		}

		public Transacciones(int transanccionesID, DateTime fecha, string tipo, decimal monto)
		{
			TransanccionesID = transanccionesID;
			Fecha = fecha;
			Tipo = tipo;
			Monto = monto;
		}
	}
}
