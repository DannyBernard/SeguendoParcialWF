using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLL.Tests
{
	[TestClass()]
	public class RepositorioBaseTests
	{
		[TestMethod()]
		public void GuardarTest()
		{
			Clientes cliente = new Clientes();

			cliente.Nombre = "Danny Benard";
			cliente.Balance = 2020;

			RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();

			Assert.IsTrue(repositorio.Guardar(cliente));
		}

		[TestMethod()]
		public void ModificarTest()
		{
			Clientes clientes = new Clientes();
			clientes.ClienteID = 1;
			clientes.Nombre = "Jan";
			clientes.Balance = 4000;

			RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
			Assert.IsTrue(repositorioBase.Modificar(clientes));
		}

		[TestMethod()]
		public void EliminarTest()
		{
			Clientes clientes = new Clientes();
			RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
			clientes.ClienteID = 1;
			Assert.AreEqual(true, repositorioBase.Eliminar(clientes.ClienteID));
		}
	}
}