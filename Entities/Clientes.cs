using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{ [Serializable]
	public class Clientes
	{
		[Key]
		public int ClienteID { get; set; }
		public string Nombre { get; set; }
		public decimal Balance { get; set; }

		public Clientes()
		{
			ClienteID = 0;
			Nombre = string.Empty;
			Balance = 0;
		}

		public Clientes(int clienteID, string nombre, decimal balance)
		{
			ClienteID = clienteID;
			Nombre = nombre;
			Balance = balance;
		}
	}

	
	
}
