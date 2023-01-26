<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id="clientes-main">
        <h2 id="clientes-title">Clientes</h2>

        <a id="clientes-new-button" class="btn btn-success" href="/Registration">
            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-clipboard2-plus" viewBox="0 0 16 16">
                <path d="M9.5 0a.5.5 0 0 1 .5.5.5.5 0 0 0 .5.5.5.5 0 0 1 .5.5V2a.5.5 0 0 1-.5.5h-5A.5.5 0 0 1 5 2v-.5a.5.5 0 0 1 .5-.5.5.5 0 0 0 .5-.5.5.5 0 0 1 .5-.5h3Z" />
                <path d="M3 2.5a.5.5 0 0 1 .5-.5H4a.5.5 0 0 0 0-1h-.5A1.5 1.5 0 0 0 2 2.5v12A1.5 1.5 0 0 0 3.5 16h9a1.5 1.5 0 0 0 1.5-1.5v-12A1.5 1.5 0 0 0 12.5 1H12a.5.5 0 0 0 0 1h.5a.5.5 0 0 1 .5.5v12a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5v-12Z" />
                <path d="M8.5 6.5a.5.5 0 0 0-1 0V8H6a.5.5 0 0 0 0 1h1.5v1.5a.5.5 0 0 0 1 0V9H10a.5.5 0 0 0 0-1H8.5V6.5Z" />
            </svg>  Novo Cliente
        </a>
    </div>

    <asp:GridView ID="GridView1" class="table table-bordered table-condensed table-responsive table-hover " runat="server" AutoGenerateColumns="false" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="CPF" HeaderText="CPF" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" />
            <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
            <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" />
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:Button ID="infobtn" runat="server" Text="Visualizar" CssClass="btn btn-primary" OnClick="infobtn_Click" />
                    <asp:Button ID="editbtn" runat="server" Text="Editar" CssClass="btn btn-success" OnClick="editbtn_Click" />
                    <asp:Button ID="deletebtn" runat="server" Text="Deletar" CssClass="btn btn-danger" OnClick="deletebtn_Click" />
                </ItemTemplate>
                <ItemStyle Wrap="false" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns> 
    </asp:GridView>

</asp:Content>

