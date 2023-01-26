using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Clientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            PopulateGrid();
    }

    public void PopulateGrid()
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        dt.Columns.AddRange(new System.Data.DataColumn[5] {
                new System.Data.DataColumn("CPF"),
                new System.Data.DataColumn("Nome"),
                new System.Data.DataColumn("DataNascimento"),
                new System.Data.DataColumn("Sexo"),
                new System.Data.DataColumn("EstadoCivil")});


        ServiceReference.ClienteClient service = new ServiceReference.ClienteClient();

        GridView1.DataSource = service.GetAll();
        GridView1.DataBind();
        GridView1.UseAccessibleHeader = true;
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void deletebtn_Click(object sender, EventArgs e)
    {
        Button btnDel = sender as Button;
        GridViewRow gRow = btnDel.NamingContainer as GridViewRow;
        long? clienteId = GridView1.DataKeys[gRow.RowIndex]["Id"] as long?;

        ServiceReference.ClienteClient service = new ServiceReference.ClienteClient();

        service.DeleteClienteById((long)clienteId);
        PopulateGrid();
    }

    protected void editbtn_Click(object sender, EventArgs e)
    {
        Button btnDel = sender as Button;
        GridViewRow gRow = btnDel.NamingContainer as GridViewRow;
        long? clienteId = GridView1.DataKeys[gRow.RowIndex]["Id"] as long?;

        if (clienteId != null)
        {
            Response.Redirect("Registration.aspx?ID=" + clienteId);
        }
    }

    protected void infobtn_Click(object sender, EventArgs e)
    {
        Button btnDel = sender as Button;
        GridViewRow gRow = btnDel.NamingContainer as GridViewRow;
        long? clienteId = GridView1.DataKeys[gRow.RowIndex]["Id"] as long?;

        if (clienteId != null)
        {
            Response.Redirect("Info.aspx?ID=" + clienteId);
        }
    }
}