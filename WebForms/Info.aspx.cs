using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Info : System.Web.UI.Page
{
    private long clienteID
    {
        get => Request.QueryString["ID"] == null ? 0 : (long)Convert.ToDouble(Request.QueryString["ID"]);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            return;

        if (clienteID != 0)
            PopulateClienteFields();

        PopulateDropDownLists();
    }

    public void PopulateClienteFields()
    {
        ServiceReference.ClienteClient service = new ServiceReference.ClienteClient();
        var cliente = service.GetClienteById(clienteID);

        CPF.Text = cliente.CPF;
        Nome.Text = cliente.Nome;
        RG.Text = cliente.RG;
        DataExpedicao.Text = cliente.DataExpedicao?.ToString("yyyy-MM-dd");
        ddOrgaos.SelectedValue = cliente.OrgaoExpedicao;
        ddUFExpedicao.SelectedValue = cliente.UFExpedicao;
        DataNascimento.Text = cliente.DataNascimento.ToString("yyyy-MM-dd");
        ddSexo.SelectedValue = cliente.Sexo;
        ddEstadoCivil.SelectedValue = cliente.EstadoCivil;
        CEP.Text = cliente.CEP;
        Logradouro.Text = cliente.Logradouro;
        Numero.Text = cliente.Numero;
        Complemento.Text = cliente.Complemento;
        Bairro.Text = cliente.Bairro;
        Cidade.Text = cliente.Cidade;
        ddUF.SelectedValue = cliente.UF;
    }

    public void PopulateDropDownLists()
    {
        ddOrgaos.DataSource = GetOrgaosExpedicao();
        ddOrgaos.DataBind();

        ddSexo.DataSource = GetGeneros();
        ddSexo.DataBind();

        ddEstadoCivil.DataSource = GetEstadosCivil();
        ddEstadoCivil.DataBind();

        ddUF.DataSource = GetUFs();
        ddUF.DataBind();

        ddUFExpedicao.DataSource = GetUFs();
        ddUFExpedicao.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (clienteID != 0)
        {
            Response.Redirect("Registration.aspx?ID=" + clienteID);
        }
    }

    public List<ListItem> GetUFs()
    {
        List<ListItem> ufs = new List<ListItem>
        {
            new ListItem { Text = "...", Value = "" },
            new ListItem { Text = "Acre", Value = "AC" },
            new ListItem { Text = "Alagoass", Value = "AL" },
            new ListItem { Text = "Amapá", Value = "AP" },
            new ListItem { Text = "Amazonas", Value = "AM" },
            new ListItem { Text = "Bahia", Value = "BA" },
            new ListItem { Text = "Ceará", Value = "CE" },
            new ListItem { Text = "Espírito Santo", Value = "ES" },
            new ListItem { Text = "Goiás", Value = "GO" },
            new ListItem { Text = "Maranhão", Value = "MA" },
            new ListItem { Text = "Mato Grosso", Value = "MT" },
            new ListItem { Text = "Mato Grosso do Sul", Value = "MS" },
            new ListItem { Text = "Minas Gerais", Value = "MG" },
            new ListItem { Text = "Pará", Value = "PA" },
            new ListItem { Text = "Paraíba", Value = "PB" },
            new ListItem { Text = "Paraná", Value = "PR" },
            new ListItem { Text = "Pernambuco", Value = "PE" },
            new ListItem { Text = "Piauí", Value = "PI" },
            new ListItem { Text = "Rio de Janeiro", Value = "RJ" },
            new ListItem { Text = "Rio Grande do Norte", Value = "RN" },
            new ListItem { Text = "Rio Grande do Sul", Value = "RS" },
            new ListItem { Text = "Rondônia", Value = "RO" },
            new ListItem { Text = "Roraima", Value = "RR" },
            new ListItem { Text = "Santa Catarina", Value = "SC" },
            new ListItem { Text = "São Paulo", Value = "SP" },
            new ListItem { Text = "Sergipe", Value = "SE" },
            new ListItem { Text = "Tocantins", Value = "TO" },
            new ListItem { Text = "Distrito Federal", Value = "DF" }
        };

        return ufs;
    }

    public List<ListItem> GetOrgaosExpedicao()
    {
        List<ListItem> orgaos = new List<ListItem>
        {
            new ListItem { Text = "...", Value = "" },
            new ListItem { Text = "SSP", Value = "SSP" },
            new ListItem { Text = "Cartório Civil", Value = "CC" },
            new ListItem { Text = "Polícia Federal", Value = "PF" },
            new ListItem { Text = "DETRAN", Value = "DETRAN" },
            new ListItem { Text = "Outro", Value = "OUTRO" }
        };

        return orgaos;
    }

    public List<ListItem> GetGeneros()
    {
        List<ListItem> generos = new List<ListItem>
        {
            new ListItem { Text = "...", Value = "" },
            new ListItem { Text = "Masculino", Value = "Masculino" },
            new ListItem { Text = "Feminino", Value = "Feminino" },
            new ListItem { Text = "Outro", Value = "Outro" }
        };

        return generos;
    }

    public List<ListItem> GetEstadosCivil()
    {
        List<ListItem> generos = new List<ListItem>
        {
            new ListItem { Text = "...", Value = "" },
            new ListItem { Text = "Solteiro", Value = "Solteiro" },
            new ListItem { Text = "Casado", Value = "Casado" },
            new ListItem { Text = "Separado", Value = "Separado" },
            new ListItem { Text = "Divorciado", Value = "Divorciado" },
            new ListItem { Text = "Viúvo", Value = "Viúvo" },
        };

        return generos;
    }
}