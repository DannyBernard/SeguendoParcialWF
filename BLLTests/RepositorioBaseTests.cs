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

			Transacciones transacciones = new Transacciones();
			transacciones.Fecha = DateTime.Now;
			transacciones.Tipo = "Deuda";
			transacciones.Monto = 2000;

			RepositorioBase<Transacciones> repositori = new RepositorioBase<Transacciones>();

			Assert.IsTrue(repositori.Guardar(transacciones));
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

			Transacciones transacciones = new Transacciones();

			transacciones.TransanccionesID = 1;
			transacciones.Fecha = DateTime.Now;
			transacciones.Tipo = "Tarjeta";
			transacciones.Monto = 400;

			RepositorioBase<Transacciones> repositorioBase1 = new RepositorioBase<Transacciones>();
			Assert.IsTrue(repositorioBase1.Modificar(transacciones));
		}

		[TestMethod()]
		public void EliminarTest()
		{
			Clientes clientes = new Clientes();
			RepositorioBase<Clientes> repositorioBase = new RepositorioBase<Clientes>();
			clientes.ClienteID = 1;
			Assert.AreEqual(true, repositorioBase.Eliminar(clientes.ClienteID));

			Transacciones transacciones = new Transacciones();
			RepositorioBase<Transacciones> repositorioBase1 = new RepositorioBase<Transacciones>();
			transacciones.TransanccionesID = 1;
			Assert.AreEqual(true, repositorioBase1.Eliminar(transacciones.TransanccionesID));
		}
	}
}