using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SegundoParcialWF.UI.Consulta
{
	public partial class CCliente : System.Web.UI.Page
	{
		static List<Clientes> lista = new List<Clientes>();
		protected void Page_Load(object sender, EventArgs e)
		{
			DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
			HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
			if (!Page.IsPostBack)
			{
				LlenaReport();
			}

		}

		protected void BuscarButton_Click(object sender, EventArgs e)
		{
			Expression<Func<Clientes, bool>> filtro = x => true;
			RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>();
			int id;
			switch (BuscarPorDropDownList.SelectedIndex)
			{
				case 0://Todo
					filtro = x => true;
					break;
				case 1://ID
					id = Utilitario.Utils.ToInt(FiltroTextBox.Text);
					filtro = c => c.ClienteID == id;
					break;
				case 2:// nombre
					filtro = c => c.Nombre.Contains(FiltroTextBox.Text);
					break;
			}
			DateTime desdeTextBox = Utilitario.Utils.ToFecha(DesdeTextBox.Text);
			DateTime FechaHasta = Utilitario.Utils.ToFecha(HastaTextBox.Text);
			if (fechaCheckBox.Checked) { }
			//lista = repositorio.GetList(filtro).Where(c => c.fecha.Date >= desdeTextBox && c.fecha.Date <= FechaHasta).ToList();
			else
				lista = repositorio.GetList(filtro);
			this.BindGrid(lista);

		}
		private void BindGrid(List<Clientes> lista)
		{
			DatosGridView.DataSource = lista;
			DatosGridView.DataBind();
		}
		protected void FechaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (fechaCheckBox.Checked)
			{
				fechaCheckBox.Visible = true;
				fechaCheckBox.Visible = true;
			}
			else
			{
				fechaCheckBox.Visible = false;
				fechaCheckBox.Visible = false;
			}
		}

		public void LlenaReport()
		{
			ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "Popup", $"ShowReporte('Lista de Tipo');", true);
			ClienteReportViewer.ProcessingMode = ProcessingMode.Local;
			ClienteReportViewer.Reset();
			ClienteReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportTipoAnalisis.rdlc");
			ClienteReportViewer.LocalReport.DataSources.Clear();
			ClienteReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Clientes",Clientes()));
			ClienteReportViewer.LocalReport.Refresh();
		}

		private object Clientes()
		{
			throw new NotImplementedException();
		}
	}
}
