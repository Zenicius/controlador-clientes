<%@ Page Title="Informações" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Info.aspx.cs" Inherits="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="clientes-reg-title">
        <h2>Informações do Cliente</h2>
    </div>

    <div class="clientes-form">
        <fieldset disabled>
        <div class="row">
        <div class="form-group col-md-3">
            <label for="CPF">CPF</label>
            <asp:TextBox ID="CPF" runat="server" CssClass="form-control" MaxLength="11"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="Nome">Nome</label>
            <asp:TextBox ID="Nome" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="RG">RG</label>
            <asp:TextBox ID="RG" runat="server" CssClass="form-control" MaxLength="9"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="DataExpedicao">Data de Expedição</label>
            <asp:TextBox ID="DataExpedicao" runat="server" CssClass="form-control" type="date"></asp:TextBox>
        </div>
        <div class="form-group col-md-3">
            <label for="ddOrgaos">Orgão de Expedição</label>
            <asp:DropDownList ID="ddOrgaos" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group col-md-3">
            <label for="UFExpedicao">UF Expedição</label>
            <asp:DropDownList ID="ddUFExpedicao" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="DataNascimento">Data de Nascimento</label>
            <asp:TextBox ID="DataNascimento" runat="server" CssClass="form-control" type="date"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="ddSexo">Sexo</label>
            <asp:DropDownList ID="ddSexo" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group col-md-3">
            <label for="ddEstadoCivil">Estado Civil</label>
            <asp:DropDownList ID="ddEstadoCivil" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <h3 class="clientes-reg-address">Endereço</h3>

    <div class="row">
        <div class="form-group col-md-2">
            <label for="CEP">CEP</label>
            <asp:TextBox ID="CEP" runat="server" CssClass="form-control" MaxLength="8"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="Logradouro">Logradouro</label>
            <asp:TextBox ID="Logradouro" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-1">
            <label for="Numero">Número</label>
            <asp:TextBox ID="Numero" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="Complemento">Complemento</label>
            <asp:TextBox ID="Complemento" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="Bairro">Bairro</label>
            <asp:TextBox ID="Bairro" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="form-group col-md-3">
            <label for="Cidade">Cidade</label>
            <asp:TextBox ID="Cidade" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group col-md-3">
            <label for="ddUF">UF</label>
            <asp:DropDownList ID="ddUF" DataValueField="Value" DataTextField="Text" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    </fieldset>

    <asp:Button type="submit" ID="btnSubmit" class="btn btn-success" runat="server" Text="Editar" OnClick="btnSubmit_Click"/>
    </div>

   

</asp:Content>

